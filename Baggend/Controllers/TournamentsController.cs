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
        public async Task<ActionResult<List<Tournament>>> Get()
        {
            return _tournamentService.Get();
        }

        // GET: api/Tournaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> Get(long id)
        {
            var tournamentItem = _tournamentService.Get(id.ToString());

            if (tournamentItem == null)
            {
                return NotFound();
            }

            return tournamentItem;
        }

        // PUT: api/Tournaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Tournament tournamentItem)
        {
            var tournament = _tournamentService.Get(id.ToString());

            if (tournament == null)
            {
                return NotFound();
            }

            _tournamentService.Update(id.ToString(), tournamentItem);

            return NoContent();
        }
        /*
        [
            [
                {
                    id: ""
                    matches: [
                        "player1"
                        "player2"
                    ]
                    winner: ""
                }
            ]
        ]


        */
        // POST: api/Tournaments
        [HttpPost]
        public async Task<ActionResult<Tournament>> Create(Tournament tournamentItem)
        {
            
            _tournamentService.Create(tournamentItem);

            return CreatedAtAction(nameof(Get), new { id = tournamentItem.Id }, tournamentItem);
        }

        // DELETE: api/Tournaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var tournament = _tournamentService.Get(id.ToString());
            if (tournament == null)
            {
                return NotFound();
            }

            _tournamentService.Remove(tournament.Id.ToString());

            return NoContent();
        }

        private bool TournamentItemExists(long id)
        {
            return _tournamentService.Get().Any(e => e.Id == id);
        }
    }
}
