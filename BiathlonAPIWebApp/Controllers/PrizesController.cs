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
    public class PrizesController : ControllerBase
    {
        private readonly BiathlonAPIContext _context;

        public PrizesController(BiathlonAPIContext context)
        {
            _context = context;
        }

        // GET: api/Prizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prize>>> GetPrizes()
        {
          if (_context.Prizes == null)
          {
              return NotFound();
          }
            return await _context.Prizes.ToListAsync();
        }

        // GET: api/Prizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prize>> GetPrize(int id)
        {
          if (_context.Prizes == null)
          {
              return NotFound();
          }
            var prize = await _context.Prizes.FindAsync(id);

            if (prize == null)
            {
                return NotFound();
            }

            return prize;
        }

        // PUT: api/Prizes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrize(int id, Prize prize)
        {
            if (id != prize.Id)
            {
                return BadRequest();
            }

            _context.Entry(prize).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrizeExists(id))
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

        // POST: api/Prizes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prize>> PostPrize(Prize prize)
        {
          if (_context.Prizes == null)
          {
              return Problem("Entity set 'BiathlonAPIContext.Prizes'  is null.");
          }
            _context.Prizes.Add(prize);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrize", new { id = prize.Id }, prize);
        }

        // DELETE: api/Prizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrize(int id)
        {
            if (_context.Prizes == null)
            {
                return NotFound();
            }
            var prize = await _context.Prizes.FindAsync(id);
            if (prize == null)
            {
                return NotFound();
            }

            _context.Prizes.Remove(prize);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrizeExists(int id)
        {
            return (_context.Prizes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
