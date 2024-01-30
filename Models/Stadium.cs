using Proiect.Models.Base;

namespace Proiect.Models
{
    public class Stadium : BaseEntity
    {
        public int NoOfSeats {  get; set; }

        public string? Location { get; set; }

        public Team? Team {  get; set; }

        public Guid TeamId { get; set; }
    }
}
