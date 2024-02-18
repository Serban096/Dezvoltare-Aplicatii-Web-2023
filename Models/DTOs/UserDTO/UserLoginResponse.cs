namespace Proiect.Models.DTOs.UserDTO
{
    public class UserLoginResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }


        public UserLoginResponse(User user)
        {
            Id = user.Id;
            UserName = user.Username;
        }
    }
}
