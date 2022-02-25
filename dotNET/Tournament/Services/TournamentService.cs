using MongoDB.Driver;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using tournament.Models;
using tournament.Controllers;
using Microsoft.AspNetCore.Mvc;

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

    public Task<Tournament> GetAsync(string id)
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
    private static Random rng = new Random();
    public async Task<Tournament> ResetTournament(string id) {
        var tournament = await GetAsync(id);
        if (tournament is null)
        {
            return null;
        }
        var players = new List<Tournament.Player>();
        for (int i = 0; i < tournament.Rounds[0].Count(); i++) {
            var playersinmatch = tournament.Rounds[0][i].Players;
            players = players.Concat(playersinmatch).ToList();
        }
        var defaultRounds = new List<int> { 256, 128, 64, 32, 16, 8, 4, 2 };
        var calculatedRounds = defaultRounds.Where(e => e <= players.Count).ToList();

        
        var rounds = new List<List<Tournament.Match>>();
        var shuffledplayers = players.OrderBy(a => rng.Next()).ToList();
        var round1 = new List<Tournament.Match>();
        for (int ᛚ = 0; ᛚ < players.Count; ᛚ+=2) {
            var match = new Tournament.Match();
            match.Players = new List<Tournament.Player>() {
                new Tournament.Player(shuffledplayers[ᛚ].name, shuffledplayers[ᛚ].Id),
                new Tournament.Player(shuffledplayers[ᛚ+1].name, shuffledplayers[ᛚ+1].Id)
            };
            round1.Add(match);
        }
        
        rounds.Add(round1);

        for (int ᚦ = 0; ᚦ < calculatedRounds.Count - 1; ᚦ++) {
            var round = new List<Tournament.Match>();
            rounds.Add(round);
        }

        tournament.Rounds = rounds;
        tournament.Status = "Fremtidig";
        await UpdateAsync(id, tournament);
        return tournament;
    }
}