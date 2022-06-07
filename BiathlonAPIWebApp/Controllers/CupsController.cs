using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BiathlonAPIWebApp.Models;

namespace BiathlonAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupsController : ControllerBase
    {
        private readonly BiathlonAPIContext _context;

        public CupsController(BiathlonAPIContext context)
        {
            _context = context;
        }

        // GET: api/Cups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cup>>> GetCups()
        {
          if (_context.Cups == null)
          {
              return NotFound();
          }
            return await _context.Cups.ToListAsync();
        }

        // GET: api/Cups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cup>> GetCup(int id)
        {
          if (_context.Cups == null)
          {
              return NotFound();
          }
            var cup = await _context.Cups.FindAsync(id);

            if (cup == null)
            {
                return NotFound();
            }

            return cup;
        }

        // PUT: api/Cups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCup(int id, Cup cup)
        {
            if (id != cup.Id)
            {
                return BadRequest();
            }

            _context.Entry(cup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CupExists(id))
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

        // POST: api/Cups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cup>> PostCup(Cup cup)
        {
          if (_context.Cups == null)
          {
              return Problem("Entity set 'BiathlonAPIContext.Cups'  is null.");
          }
            _context.Cups.Add(cup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCup", new { id = cup.Id }, cup);
        }

        // DELETE: api/Cups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCup(int id)
        {
            if (_context.Cups == null)
            {
                return NotFound();
            }
            var cup = await _context.Cups.FindAsync(id);
            if (cup == null)
            {
                return NotFound();
            }

            _context.Cups.Remove(cup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CupExists(int id)
        {
            return (_context.Cups?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
