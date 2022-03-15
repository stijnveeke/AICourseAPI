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
    public class LearningOutcomesController : ControllerBase
    {
        private readonly AICourseAPIContext _context;

        public LearningOutcomesController(AICourseAPIContext context)
        {
            _context = context;
        }

        // GET: api/LearningOutcomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LearningOutcome>>> GetLearningOutcome()
        {
            return await _context.LearningOutcome.ToListAsync();
        }

        // GET: api/LearningOutcomes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LearningOutcome>> GetLearningOutcome(int id)
        {
            var learningOutcome = await _context.LearningOutcome.FindAsync(id);

            if (learningOutcome == null)
            {
                return NotFound();
            }

            return learningOutcome;
        }

        // PUT: api/LearningOutcomes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLearningOutcome(int id, LearningOutcome learningOutcome)
        {
            if (id != learningOutcome.Id)
            {
                return BadRequest();
            }

            _context.Entry(learningOutcome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearningOutcomeExists(id))
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

        // POST: api/LearningOutcomes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LearningOutcome>> PostLearningOutcome(LearningOutcome learningOutcome)
        {
            _context.LearningOutcome.Add(learningOutcome);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLearningOutcome", new { id = learningOutcome.Id }, learningOutcome);
        }

        // DELETE: api/LearningOutcomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLearningOutcome(int id)
        {
            var learningOutcome = await _context.LearningOutcome.FindAsync(id);
            if (learningOutcome == null)
            {
                return NotFound();
            }

            _context.LearningOutcome.Remove(learningOutcome);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LearningOutcomeExists(int id)
        {
            return _context.LearningOutcome.Any(e => e.Id == id);
        }
    }
}
