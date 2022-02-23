using MongoDB.Driver;
using tournament.Models;
using Microsoft.Extensions.Options;

namespace tournament.Services;

public class TournamentRepository : ITournamentRepository
{
    private readonly IMongoCollection<Tournament> _tournaments;

    public TournamentRepository(IOptions<TournamentDatabaseSettings> tournamentDatabaseSettings, IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(tournamentDatabaseSettings.Value.DatabaseName);

        _tournaments = database.GetCollection<Tournament>(tournamentDatabaseSettings.Value.TournamentsCollectionName);
    }

    public async Task<List<Tournament>> GetAsync()
    {
        return await _tournaments.Find(tournament => true).ToListAsync();
    }

    public async Task<Tournament?> GetAsync(string id)
    {
        return await _tournaments.Find(tournament => tournament.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Tournament newTournament)
    {
        await _tournaments.InsertOneAsync(newTournament);
    }


    public async Task UpdateAsync(string id, Tournament updatedTournament)
    {
        await _tournaments.ReplaceOneAsync(tournament => tournament.Id == id, updatedTournament);
    }

    public async Task RemoveAsync(string id)
    {
        await _tournaments.DeleteOneAsync(tournament => tournament.Id == id);
    }
}
