using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ValueObjectiveTaksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValueObjectiveTaksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ValueObjectiveTaks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValueObjectiveTak>>> GetValueObjectiveTaks()
        {
          if (_context.ValueObjectiveTaks == null)
          {
              return NotFound();
          }  
            return await _context.ValueObjectiveTaks.Include(v=>v.Value).Include(o=>o.Objective).Include(t=>t.Tak).ToListAsync();
        }

        // GET: api/ValueObjectiveTaks/Objective/Id
        [HttpGet("Objective/{id:int}")]
        public async Task<ActionResult<IEnumerable<ValueObjectiveTak>>> GetObjective(int id)
        {
            Console.WriteLine(id);
            if (_context.ValueObjectiveTaks == null)
            {
                return NotFound();
            }
            return  await _context.ValueObjectiveTaks.Where(x => x.ObjectiveID == id).Include(v => v.Value).Include(o => o.Objective).Include(t => t.Tak).ToListAsync();
            
        }

        // GET: api/ValueObjectiveTaks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ValueObjectiveTak>> GetValueObjectiveTak(int id)
        {
          if (_context.ValueObjectiveTaks == null)
          {
              return NotFound();
          }
            var valueObjectiveTak = await _context.ValueObjectiveTaks.FindAsync(id);

            if (valueObjectiveTak == null)
            {
                return NotFound();
            }

            return valueObjectiveTak;
        }

        

        // PUT: api/ValueObjectiveTaks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValueObjectiveTak(int id, ValueObjectiveTak valueObjectiveTak)
        {
            if (id != valueObjectiveTak.Id)
            {
                return BadRequest();
            }

            _context.Entry(valueObjectiveTak).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValueObjectiveTakExists(id))
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

        // POST: api/ValueObjectiveTaks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ValueObjectiveTak>> PostValueObjectiveTak(ValueObjectiveTak valueObjectiveTak)
        {
          if (_context.ValueObjectiveTaks == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ValueObjectiveTaks'  is null.");
          }
            _context.ValueObjectiveTaks.Add(valueObjectiveTak);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetValueObjectiveTak", new { id = valueObjectiveTak.Id }, valueObjectiveTak);
        }

        // DELETE: api/ValueObjectiveTaks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValueObjectiveTak(int id)
        {
            if (_context.ValueObjectiveTaks == null)
            {
                return NotFound();
            }
            var valueObjectiveTak = await _context.ValueObjectiveTaks.FindAsync(id);
            if (valueObjectiveTak == null)
            {
                return NotFound();
            }

            _context.ValueObjectiveTaks.Remove(valueObjectiveTak);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ValueObjectiveTakExists(int id)
        {
            return (_context.ValueObjectiveTaks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
