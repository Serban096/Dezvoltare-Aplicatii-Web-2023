using Proiect.Models;

namespace Proiect.Helpers.Jwt
{
    public interface IJwt
    {
        public string GenerateJwtToken(User user);
        public Guid? GetUserId(string? token);
    }
}
