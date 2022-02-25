using Microsoft.AspNetCore.Mvc;
using tournament.Models;

namespace tournament.Services;

public interface ITournamentRepository
{
    Task CreateAsync(Tournament newTournament);
    Task<List<Tournament>> GetAsync();
    Task<Tournament> GetAsync(string id);
    Task RemoveAsync(string id);
    Task UpdateAsync(string id, Tournament updatedTournament);

}
