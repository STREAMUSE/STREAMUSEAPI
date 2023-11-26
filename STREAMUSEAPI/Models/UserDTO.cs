using System.ComponentModel.DataAnnotations;

namespace STREAMUSEAPI.Models
{
    public class UserDTO
    {
        [Required]
        [MaxLength(25)]
        public string Username { get; set; }

        [Required]
        [MaxLength(25)]
        public string Password { get; set; }

        public UserDTO(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
