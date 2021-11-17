namespace baggend.Models {
    public class TournamentDatabaseSettings : ITournamentDatabaseSettings {
        public string TournamentsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface ITournamentDatabaseSettings {
        string TournamentsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}