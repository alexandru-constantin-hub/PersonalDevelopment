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
    public class ObjectivesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ObjectivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Objectives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objective>>> GetObjectives()
        {
          if (_context.Objectives == null)
          {
              return NotFound();
          }
            return await _context.Objectives
                .Where(a => a.UserId == HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
                .ToListAsync();
        }

        // GET: api/Objectives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Objective>> GetObjective(int id)
        {
          if (_context.Objectives == null)
          {
              return NotFound();
          }
            var objective = await _context.Objectives.FindAsync(id);

            if (objective == null)
            {
                return NotFound();
            }

            return objective;
        }

        // PUT: api/Objectives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjective(int id, Objective objective)
        {
            if (id != objective.Id)
            {
                return BadRequest();
            }

            _context.Entry(objective).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectiveExists(id))
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

        // POST: api/Objectives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Objective>> PostObjective(Objective objective)
        {
            objective.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (_context.Objectives == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Objectives'  is null.");
          }
            _context.Objectives.Add(objective);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjective", new { id = objective.Id }, objective);
        }

        // DELETE: api/Objectives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjective(int id)
        {
            if (_context.Objectives == null)
            {
                return NotFound();
            }
            var objective = await _context.Objectives.FindAsync(id);
            if (objective == null)
            {
                return NotFound();
            }

            _context.Objectives.Remove(objective);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjectiveExists(int id)
        {
            return (_context.Objectives?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
