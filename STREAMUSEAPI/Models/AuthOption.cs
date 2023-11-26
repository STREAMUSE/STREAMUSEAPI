using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace STREAMUSEAPI.Models
{
    public class AuthOption
    {
        public const string ISSUER = "STREAMUSEAPI";
        public const string AUDIENCE = "Client";
        private const string KEY = "STREAMUSEAPI";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
            => new(SHA256.HashData(Encoding.UTF8.GetBytes(KEY)));
    }
}
