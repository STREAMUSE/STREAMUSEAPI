using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace STREAMUSEAPI.Services
{
    public class AuthOption
    {
        public const string ISSUER = "STREAMUSEAPI";
        public const string AUDIENCE = "Client";
        private const string KEY = "STREAMUSEAPI";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
            => new(SHA256.HashData(Encoding.UTF8.GetBytes(KEY)));

        public static string HashPassword(in string password)
            => Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
    }
}
