namespace baggend.Models
{
    public class TournamentItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        
        public string? Status { get; set; }
        public bool IsComplete { get; set; }
    }
}