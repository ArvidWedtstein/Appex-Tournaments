using MongoDB.Driver;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using tournament.Models;
using Microsoft.Extensions.Options;
using tournament.Controllers;

namespace tournament.Services;
public class TournamentService
{
    private readonly IMongoCollection<Tournament> _tournaments;
    public TournamentService(IOptions<TournamentDatabaseSettings> tournamentDatabaseSettings)
    {
        var client = new MongoClient(tournamentDatabaseSettings.Value.ConnectionString);
        var database = client.GetDatabase(tournamentDatabaseSettings.Value.DatabaseName);

        _tournaments = database.GetCollection<Tournament>(tournamentDatabaseSettings.Value.TournamentsCollectionName);
    }

    public async Task<List<Tournament>> GetAsync() {

        return await _tournaments.Find(tournament => true).ToListAsync();
    }

    public async Task<Tournament?> GetAsync(string id) {
        return await _tournaments.Find(tournament => tournament.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task CreateAsync(Tournament newTournament) {
        await _tournaments.InsertOneAsync(newTournament);
    }
        
    
    public async Task UpdateAsync(string id, Tournament updatedTournament) {
        await _tournaments.ReplaceOneAsync(tournament => tournament.Id == id, updatedTournament);
    }

    /*public async Task MatchWinAsync(string id, Tournament data, Tournament.Match rounds) {
        await _tournaments.UpdateOneAsync(tournament => tournament.Id == id, data);
        
        //await _tournaments.FindOneAndUpdateAsync( id, new { Rounds = rounds});
    }*/

    public async Task RemoveAsync(string id) {
        await _tournaments.DeleteOneAsync(tournament => tournament.Id == id);
    }
}