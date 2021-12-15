namespace tournament.Models;
public class TournamentDatabaseSettings : ITournamentDatabaseSettings {
    public string TournamentsCollectionName { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}
public interface ITournamentDatabaseSettings {
    string TournamentsCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}