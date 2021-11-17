using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using baggend.Models;
using baggend.Services;

namespace baggend.Controllers
{
    // api/Tournaments
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly TournamentService _tournamentService;

        public TournamentsController(TournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        // GET: api/Tournaments
        [HttpGet]
        public async Task<ActionResult<List<Tournament>>> Get() => _tournamentService.Get();

        // GET: api/Tournaments/5
        [HttpGet("{id:length(24)}", Name = "GetTournament")]
        public async Task<ActionResult<Tournament>> Get(string id)
        {
            var tournamentItem = _tournamentService.Get(id);

            if (tournamentItem == null)
            {
                return NotFound();
            }

            return tournamentItem;
        }

        // PUT: api/Tournaments/5
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Tournament tournamentItem)
        {
            var tournament = _tournamentService.Get(id);

            if (tournament == null)
            {
                return NotFound();
            }

            _tournamentService.Update(id, tournamentItem);

            return NoContent();
        }
        
        // POST: api/Tournaments
        [HttpPost]
        public async Task<ActionResult<Tournament>> Create(Tournament tournamentItem)
        {
            
            _tournamentService.Create(tournamentItem);

            return CreatedAtRoute("GetTournament", new { id = tournamentItem.Id }, tournamentItem);
        }

        // DELETE: api/Tournaments/5
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var tournament = _tournamentService.Get(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _tournamentService.Remove(tournament.Id);

            return NoContent();
        }
    }
}
