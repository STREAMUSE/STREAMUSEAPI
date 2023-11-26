using Microsoft.AspNetCore.Mvc;

namespace STREAMUSEAPI.Consts
{
    public class Error
    {
        public const string USER_DOESNT_EXIST = "This user doesn't exist";
        public const string USER_EXIST = "This user already exist";

        public static readonly ObjectResult DB_CONNECTION_FAILED = new("Database connection failed")
        {
            StatusCode = StatusCodes.Status503ServiceUnavailable,
        };

        public static readonly ObjectResult TOKEN_TERMINATED = new("Token terminated")
        {
            StatusCode = StatusCodes.Status401Unauthorized,
        };

        public static readonly ObjectResult SERVER_ERROR = new("Server error")
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };
    }
}
