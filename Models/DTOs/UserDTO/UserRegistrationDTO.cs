using System.ComponentModel.DataAnnotations;

namespace Proiect.Models.DTOs.UserDTO
{
    public class UserRegistrationDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
