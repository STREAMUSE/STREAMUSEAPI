using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using STREAMUSEAPI.Extensions;
using STREAMUSEAPI.Models;
using STREAMUSEAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace STREAMUSEAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly STREAMUSEDbContext context;
        private readonly IDistributedCache cache;

        public UserController(STREAMUSEDbContext context, IDistributedCache cache)
        {
            this.context = context;
            this.cache = cache;
        }

        private static DistributedCacheEntryOptions CacheOption => new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
        };

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<string>> SingIn(UserDTO user)
        {
            if (await context.Users.FirstOrDefaultAsync(u => u.Username == user.Username
                && u.Password == AuthOption.HashPassword(user.Password)) is not User loginUser)
            {
                Log.Warning("Username or password uncorrected");
                return BadRequest();
            }
            return Ok(GenerateToken(loginUser));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SingUp(UserDTO user)
        {
            if (await context.Users.FirstOrDefaultAsync(u => u.Username == user.Username) != null)
            {
                Log.Warning("User already exist");
                return BadRequest();
            }
            await context.Users.AddAsync(new User
            {
                Username = user.Username,
                Password = AuthOption.HashPassword(user.Password)
            });
            await context.SaveChangesAsync();
            Log.Information("User added");
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetById(long id)
        {
            string key = $"{nameof(User)}{id}";
            string? cacheUser = await cache.GetStringAsync(key);
            User? user;

            if (!string.IsNullOrEmpty(cacheUser))
            {
                user = JsonSerializer.Deserialize<User>(cacheUser);
                Log.Information($"{key} get from cache");
            }
            else if ((user = await context.Users.FindAsync(id)) == null)
            {
                Log.Warning("User doesn't exist");
                return BadRequest();
            }
            Log.Information($"{key} get from db");

            cacheUser = JsonSerializer.Serialize(user);
            await cache.SetStringAsync(key, cacheUser, CacheOption);
            Log.Information($"{key} added to cache");
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetByUsername(string username)
        {
            return Ok(await context.Users.Select(u => new User
            {
                Id = u.Id,
                Username = u.Username
            }).Where(u => u.Id != long.Parse(User.GetClaimValue(nameof(Models.User.Id)))
                && u.Username.Contains(username)).ToListAsync());
        }

        private string GenerateToken(in User user)
        {
            Log.Information($"Creating token for {nameof(User)}: {user.Username}");

            var claims = new List<Claim>
            {
                new(nameof(user.Id), $"{user.Id}"),
                new(nameof(user.Username), $"{user.Username}")
            };
            Log.Information($"Claims:\n{nameof(user.Id)}: {user.Id}\n"
                + $"{nameof(user.Username)}: {user.Username}\n"
                + $"created");

            var jwt = new JwtSecurityToken(
                issuer: AuthOption.ISSUER,
                audience: AuthOption.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(1)),
                signingCredentials: new SigningCredentials(AuthOption.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));

            Log.Information($"Token: {jwt} created");
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }


    }
}
