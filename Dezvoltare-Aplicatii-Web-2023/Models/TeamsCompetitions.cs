namespace Proiect.Models
{
    public class TeamsCompetitions
    {
        public Guid TeamId { get; set; }
        public Team? Team { get; set; }

        public Guid CompetitionId { get; set; }
        public Competition? Competition { get; set; }
    }
}
