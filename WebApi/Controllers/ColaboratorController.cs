using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboratorController : ControllerBase
    {
        private readonly ColaboratorContext _context;

        public ColaboratorController(ColaboratorContext context)
        {
            _context = context;
        }

        // GET: api/Colaborator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaborator>>> GetColaborator()
        {
            return await _context.Colaborator.ToListAsync();
        }

        // GET: api/Colaborator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colaborator>> GetColaborator(long id)
        {
            var colaborator = await _context.Colaborator.FindAsync(id);

            if (colaborator == null)
            {
                return NotFound();
            }

            return colaborator;
        }

        // PUT: api/Colaborator/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColaborator(long id, Colaborator colaborator)
        {
            if (id != colaborator.Id)
            {
                return BadRequest();
            }

            _context.Entry(colaborator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaboratorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(colaborator);
        }

        // POST: api/Colaborator
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Colaborator>> PostColaborator(Colaborator colaborator)
        {
            _context.Colaborator.Add(colaborator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColaborator", new { id = colaborator.Id }, colaborator);
        }

        // DELETE: api/Colaborator/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColaborator(long id)
        {
            var colaborator = await _context.Colaborator.FindAsync(id);
            if (colaborator == null)
            {
                return NotFound();
            }

            _context.Colaborator.Remove(colaborator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColaboratorExists(long id)
        {
            return _context.Colaborator.Any(e => e.Id == id);
        }
    }
}
