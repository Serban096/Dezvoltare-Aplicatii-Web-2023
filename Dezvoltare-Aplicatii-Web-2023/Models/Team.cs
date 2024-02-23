using Proiect.Models.Base;

namespace Proiect.Models
{
    public class Team : BaseEntity
    {
        public string? Name { get; set; }

        public string? City { get; set; }

        public ICollection<TeamsCompetitions>? TeamsCompetitions { get; set; }

        public Stadium? Stadium { get; set; }

        public ICollection<Player>? Players { get; set; }
    }
}
