using Proiect.Models.Base;

namespace Proiect.Models
{
    public class Player : BaseEntity
    {
        public string? Name {  get; set; }

        public int Age { get; set; }

        public string? Position { get; set; }

        public Team? Team { get; set; }

        public Guid TeamId { get; set; }

    }
}
