using System.Security.Claims;

namespace STREAMUSEAPI.Extensions
{
    public static class ClaimExtension
    {
        public static string GetClaimValue(this ClaimsPrincipal user, string type)
            => user.Claims.First(x => x.Type == type).Value;
    }
}
