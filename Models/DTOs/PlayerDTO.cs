namespace Proiect.Models.DTOs
{
    public class PlayerDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Position { get; set; }

        public Guid teamId { get; set; }
    }
}
