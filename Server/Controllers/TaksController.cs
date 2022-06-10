using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalDevelopment.Server.Data;
using PersonalDevelopment.Shared.Models;

namespace PersonalDevelopment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Taks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tak>>> GetTaks()
        {
          if (_context.Taks == null)
          {
              return NotFound();
          }
            return await _context.Taks
                .Where(a => a.UserId == HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
                .ToListAsync();
        }

        // GET: api/Taks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tak>> GetTak(int id)
        {
          if (_context.Taks == null)
          {
              return NotFound();
          }
            var tak = await _context.Taks.FindAsync(id);

            if (tak == null)
            {
                return NotFound();
            }

            return tak;
        }

        // PUT: api/Taks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTak(int id, Tak tak)
        {
            if (id != tak.Id)
            {
                return BadRequest();
            }

            _context.Entry(tak).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TakExists(id))
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

        // POST: api/Taks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tak>> PostTak(Tak tak)
        {

            tak.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (_context.Taks == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Taks'  is null.");
          }
            _context.Taks.Add(tak);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTak", new { id = tak.Id }, tak);
        }

        // DELETE: api/Taks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTak(int id)
        {
            if (_context.Taks == null)
            {
                return NotFound();
            }
            var tak = await _context.Taks.FindAsync(id);
            if (tak == null)
            {
                return NotFound();
            }

            _context.Taks.Remove(tak);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TakExists(int id)
        {
            return (_context.Taks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
