using System.ComponentModel.DataAnnotations;

namespace Proiect.Models.DTOs.UserDTO
{
    public class UserLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
