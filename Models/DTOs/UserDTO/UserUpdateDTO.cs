using System.ComponentModel.DataAnnotations;

namespace Proiect.Models.DTOs.UserDTO
{
    public class UserUpdateDTO
    {
        [Required]
        public Guid Id { get; set; } 

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
