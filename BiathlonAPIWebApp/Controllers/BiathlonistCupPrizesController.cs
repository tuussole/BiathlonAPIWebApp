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
    public class BiathlonistCupPrizesController : ControllerBase
    {
        private readonly BiathlonAPIContext _context;

        public BiathlonistCupPrizesController(BiathlonAPIContext context)
        {
            _context = context;
        }

        // GET: api/BiathlonistCupPrizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BiathlonistCupPrize>>> GetBiathlonistCupPrizes()
        {
          if (_context.BiathlonistCupPrizes == null)
          {
              return NotFound();
          }
            return await _context.BiathlonistCupPrizes.ToListAsync();
        }

        // GET: api/BiathlonistCupPrizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BiathlonistCupPrize>> GetBiathlonistCupPrize(int id)
        {
          if (_context.BiathlonistCupPrizes == null)
          {
              return NotFound();
          }
            var biathlonistCupPrize = await _context.BiathlonistCupPrizes.FindAsync(id);

            if (biathlonistCupPrize == null)
            {
                return NotFound();
            }

            return biathlonistCupPrize;
        }

        // PUT: api/BiathlonistCupPrizes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBiathlonistCupPrize(int id, BiathlonistCupPrize biathlonistCupPrize)
        {
            if (id != biathlonistCupPrize.Id)
            {
                return BadRequest();
            }

            _context.Entry(biathlonistCupPrize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BiathlonistCupPrizeExists(id))
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

        // POST: api/BiathlonistCupPrizes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BiathlonistCupPrize>> PostBiathlonistCupPrize(BiathlonistCupPrize biathlonistCupPrize)
        {
          if (_context.BiathlonistCupPrizes == null)
          {
              return Problem("Entity set 'BiathlonAPIContext.BiathlonistCupPrizes'  is null.");
          }
            _context.BiathlonistCupPrizes.Add(biathlonistCupPrize);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBiathlonistCupPrize", new { id = biathlonistCupPrize.Id }, biathlonistCupPrize);
        }

        // DELETE: api/BiathlonistCupPrizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBiathlonistCupPrize(int id)
        {
            if (_context.BiathlonistCupPrizes == null)
            {
                return NotFound();
            }
            var biathlonistCupPrize = await _context.BiathlonistCupPrizes.FindAsync(id);
            if (biathlonistCupPrize == null)
            {
                return NotFound();
            }

            _context.BiathlonistCupPrizes.Remove(biathlonistCupPrize);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BiathlonistCupPrizeExists(int id)
        {
            return (_context.BiathlonistCupPrizes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
