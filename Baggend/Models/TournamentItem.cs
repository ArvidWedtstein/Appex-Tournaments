namespace baggend.Models
{
    public class TournamentItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public string[] Players { get; set; }
        public bool IsComplete { get; set; }
    }
}