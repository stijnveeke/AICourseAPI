using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AICourseAPI.Data;
using AICourseAPI.Models;

namespace AICourseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IterationsController : ControllerBase
    {
        private readonly AICourseAPIContext _context;

        public IterationsController(AICourseAPIContext context)
        {
            _context = context;
        }

        // GET: api/Iterations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Iteration>>> GetIteration()
        {
            return await _context.Iteration.ToListAsync();
        }

        // GET: api/Iterations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Iteration>> GetIteration(int id)
        {
            var iteration = await _context.Iteration.FindAsync(id);

            if (iteration == null)
            {
                return NotFound();
            }

            return iteration;
        }

        // PUT: api/Iterations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIteration(int id, Iteration iteration)
        {
            if (id != iteration.Id)
            {
                return BadRequest();
            }

            _context.Entry(iteration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IterationExists(id))
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

        // POST: api/Iterations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Iteration>> PostIteration(Iteration iteration)
        {
            _context.Iteration.Add(iteration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIteration", new { id = iteration.Id }, iteration);
        }

        // DELETE: api/Iterations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIteration(int id)
        {
            var iteration = await _context.Iteration.FindAsync(id);
            if (iteration == null)
            {
                return NotFound();
            }

            _context.Iteration.Remove(iteration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IterationExists(int id)
        {
            return _context.Iteration.Any(e => e.Id == id);
        }
    }
}
