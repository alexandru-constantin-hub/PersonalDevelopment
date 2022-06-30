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
    public class ValueObjectivesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValueObjectivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ValueObjectives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValueObjective>>> GetValueObjective()
        {
          if (_context.ValueObjective == null)
          {
              return NotFound();
          }
            return await _context.ValueObjective.Where(a => a.UserId == HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)).Include(o=>o.Objective).ToListAsync();
        }

        // GET: api/ValueObjectives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ValueObjective>> GetValueObjective(int id)
        {
          if (_context.ValueObjective == null)
          {
              return NotFound();
          }
            var valueObjective = await _context.ValueObjective.FindAsync(id);

            if (valueObjective == null)
            {
                return NotFound();
            }

            return valueObjective;
        }

        // PUT: api/ValueObjectives/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValueObjective(int id, ValueObjective valueObjective)
        {
            if (id != valueObjective.ID)
            {
                return BadRequest();
            }

            _context.Entry(valueObjective).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValueObjectiveExists(id))
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

        // POST: api/ValueObjectives
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ValueObjective>> PostValueObjective(ValueObjective valueObjective)
        {
            valueObjective.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (_context.ValueObjective == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ValueObjective'  is null.");
          }
            _context.ValueObjective.Add(valueObjective);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetValueObjective", new { id = valueObjective.ID }, valueObjective);
        }

        // DELETE: api/ValueObjectives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValueObjective(int id)
        {
            if (_context.ValueObjective == null)
            {
                return NotFound();
            }
            var valueObjective = await _context.ValueObjective.FindAsync(id);
            if (valueObjective == null)
            {
                return NotFound();
            }

            _context.ValueObjective.Remove(valueObjective);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ValueObjectiveExists(int id)
        {
            return (_context.ValueObjective?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
