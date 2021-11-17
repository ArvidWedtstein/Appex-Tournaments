using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using baggend.Models;

namespace baggend.Controllers
{
    // api/Tournaments
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly TournamentContext _context;

        public TournamentsController(TournamentContext context)
        {
            _context = context;
        }

        // GET: api/Tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentItem>>> GetTournamentItems()
        {
            return await _context.TournamentItems.ToListAsync();
        }

        // GET: api/Tournaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentItem>> GetTournamentItem(long id)
        {
            var tournamentItem = await _context.TournamentItems.FindAsync(id);

            if (tournamentItem == null)
            {
                return NotFound();
            }

            return tournamentItem;
        }

        // PUT: api/Tournaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournamentItem(long id, TournamentItem tournamentItem)
        {
            if (id != tournamentItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(tournamentItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tournaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TournamentItem>> PostTournamentItem(TournamentItem tournamentItem)
        {
            _context.TournamentItems.Add(tournamentItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTournamentItem), new { id = tournamentItem.Id }, tournamentItem);
        }

        // DELETE: api/Tournaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournamentItem(long id)
        {
            var tournamentItem = await _context.TournamentItems.FindAsync(id);
            if (tournamentItem == null)
            {
                return NotFound();
            }

            _context.TournamentItems.Remove(tournamentItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TournamentItemExists(long id)
        {
            return _context.TournamentItems.Any(e => e.Id == id);
        }
    }
}
