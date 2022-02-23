using MongoDB.Driver;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using tournament.Models;
using tournament.Controllers;

namespace tournament.Services;
public class TournamentService : ITournamentService
{
    private readonly ITournamentRepository _tournamentRepository;

    public TournamentService(ITournamentRepository tournamentRepository)
    {
        _tournamentRepository = tournamentRepository;
    }
    public Task CreateAsync(Tournament newTournament)
    {
        return _tournamentRepository.CreateAsync(newTournament);
    }

    public Task<List<Tournament>> GetAsync()
    {
        return _tournamentRepository.GetAsync();
    }

    public Task<Tournament?> GetAsync(string id)
    {
        return _tournamentRepository.GetAsync(id);
    }

    public Task RemoveAsync(string id)
    {
        return _tournamentRepository.RemoveAsync(id);
    }

    public Task UpdateAsync(string id, Tournament updatedTournament)
    {
        return _tournamentRepository.UpdateAsync(id, updatedTournament);
    }

    public async Task<Tournament> UpdateTournamentPlayers(string id, List<Tournament.Player> players) {
        var tournament = await GetAsync(id);
        if (tournament is null)
        {
            return null;
        }
        for (int s = 0; s < tournament.Rounds[0].Count; s++) {
            for (int h = 0; h < tournament.Rounds[0][s].Players.Count; h++) {
                var p = players.Find(x => x.Id == tournament.Rounds[0][s].Players[h].Id);
                if (p != null) {
                    tournament.Rounds[0][s].Players[h].name = p.name;
                }
            }
        }
        
        await UpdateAsync(id, tournament);

        return tournament;
    }
}