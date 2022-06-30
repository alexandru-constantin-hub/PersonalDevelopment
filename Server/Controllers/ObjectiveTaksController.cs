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
    public class ObjectiveTaksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ObjectiveTaksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ObjectiveTaks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjectiveTak>>> GetObjectiveTaks()
        {
          if (_context.ObjectiveTaks == null)
          {
              return NotFound();
          }
            return await _context.ObjectiveTaks.Where(a => a.UserId == HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)).Include(t => t.Tak).Include(o=>o.Objective).ToListAsync();
        }

        // GET: api/ObjectiveTaks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjectiveTak>> GetObjectiveTak(int id)
        {
          if (_context.ObjectiveTaks == null)
          {
              return NotFound();
          }
            var objectiveTak = await _context.ObjectiveTaks.FindAsync(id);

            if (objectiveTak == null)
            {
                return NotFound();
            }

            return objectiveTak;
        }

        // PUT: api/ObjectiveTaks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjectiveTak(int id, ObjectiveTak objectiveTak)
        {
            if (id != objectiveTak.ID)
            {
                return BadRequest();
            }

            _context.Entry(objectiveTak).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectiveTakExists(id))
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

        // POST: api/ObjectiveTaks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ObjectiveTak>> PostObjectiveTak(ObjectiveTak objectiveTak)
        {
          if (_context.ObjectiveTaks == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ObjectiveTaks'  is null.");
          }
            _context.ObjectiveTaks.Add(objectiveTak);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjectiveTak", new { id = objectiveTak.ID }, objectiveTak);
        }

        // DELETE: api/ObjectiveTaks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjectiveTak(int id)
        {
            if (_context.ObjectiveTaks == null)
            {
                return NotFound();
            }
            var objectiveTak = await _context.ObjectiveTaks.FindAsync(id);
            if (objectiveTak == null)
            {
                return NotFound();
            }

            _context.ObjectiveTaks.Remove(objectiveTak);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjectiveTakExists(int id)
        {
            return (_context.ObjectiveTaks?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
