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
    public class BiathlonistsController : ControllerBase
    {
        private readonly BiathlonAPIContext _context;

        public BiathlonistsController(BiathlonAPIContext context)
        {
            _context = context;
        }

        // GET: api/Biathlonists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Biathlonist>>> GetBiathlonists()
        {
          if (_context.Biathlonists == null)
          {
              return NotFound();
          }
            return await _context.Biathlonists.ToListAsync();
        }

        // GET: api/Biathlonists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Biathlonist>> GetBiathlonist(int id)
        {
          if (_context.Biathlonists == null)
          {
              return NotFound();
          }
            var biathlonist = await _context.Biathlonists.FindAsync(id);

            if (biathlonist == null)
            {
                return NotFound();
            }

            return biathlonist;
        }

        // PUT: api/Biathlonists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBiathlonist(int id, Biathlonist biathlonist)
        {
            if (id != biathlonist.Id)
            {
                return BadRequest();
            }

            _context.Entry(biathlonist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BiathlonistExists(id))
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

        // POST: api/Biathlonists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Biathlonist>> PostBiathlonist(Biathlonist biathlonist)
        {
          if (_context.Biathlonists == null)
          {
              return Problem("Entity set 'BiathlonAPIContext.Biathlonists'  is null.");
          }
            _context.Biathlonists.Add(biathlonist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBiathlonist", new { id = biathlonist.Id }, biathlonist);
        }

        // DELETE: api/Biathlonists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBiathlonist(int id)
        {
            if (_context.Biathlonists == null)
            {
                return NotFound();
            }
            var biathlonist = await _context.Biathlonists.FindAsync(id);
            if (biathlonist == null)
            {
                return NotFound();
            }

            _context.Biathlonists.Remove(biathlonist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BiathlonistExists(int id)
        {
            return (_context.Biathlonists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
