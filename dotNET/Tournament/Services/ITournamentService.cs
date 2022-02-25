using Microsoft.AspNetCore.Mvc;
using tournament.Models;

namespace tournament.Services;

public interface ITournamentService
{
    Task CreateAsync(Tournament newTournament);
    Task<List<Tournament>> GetAsync();
    Task<Tournament> GetAsync(string id);
    Task RemoveAsync(string id);
    Task UpdateAsync(string id, Tournament updatedTournament);
    Task<Tournament> UpdateTournamentPlayers(string id, List<Tournament.Player> players);
    Task<Tournament> ResetTournament(string id);
}
