using System.ComponentModel.DataAnnotations;

namespace Proiect.Models.DTOs.UserDTO
{
    public class UserLoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
