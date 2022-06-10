using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalDevelopment.Server.Data;
using PersonalDevelopment.Shared.Models;

namespace PersonalDevelopment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> GetValue()
        {
          if (_context.Value == null)
          {
              return NotFound();
          }
            return await _context.Value
                .Where(a => a.UserId == HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier))
                .ToListAsync();
        }

        // GET: api/Values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> GetValue(int id)
        {
          if (_context.Value == null)
          {
              return NotFound();
          }
            var value = await _context.Value.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            return value;
        }

        // PUT: api/Values/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutValue(int id, Value value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }

            _context.Entry(value).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValueExists(id))
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

        // POST: api/Values
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Value>> PostValue(Value value)
        {
            value.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (_context.Value == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Value'  is null.");
          }
            _context.Value.Add(value);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetValue", new { id = value.Id }, value);
        }

        // DELETE: api/Values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteValue(int id)
        {
            if (_context.Value == null)
            {
                return NotFound();
            }
            var value = await _context.Value.FindAsync(id);
            if (value == null)
            {
                return NotFound();
            }

            _context.Value.Remove(value);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ValueExists(int id)
        {
            return (_context.Value?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        
    }
}
