using Proiect.Models.Base;

namespace Proiect.Models
{
    public enum Type
    {
        League,
        Cup
    }
    public class Competition : BaseEntity
    {
        public int NoOfTeams { get; set; }

        public int YearFounded { get; set; }

        public Type CompType { get; set; }

        public ICollection<TeamsCompetitions>? TeamsCompetitions { get; set; }
    }
}
