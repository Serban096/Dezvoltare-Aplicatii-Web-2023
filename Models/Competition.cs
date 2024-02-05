using Proiect.Models.Base;

namespace Proiect.Models
{
    public class Competition : BaseEntity
    {
        public int NoOfTeams { get; set; }

        public int YearFounded { get; set; }

        public ICollection<TeamsCompetitions>? TeamsCompetitions { get; set; }
    }
}
