using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatersOfTheLostBusiness.Data;
using RatersOfTheLostBusiness.Models;

namespace RatersOfTheLostBusiness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewersController : ControllerBase
    {
        private readonly BusinessDbContext _context;

        public ReviewersController(BusinessDbContext context)
        {
            _context = context;
        }

        // GET: api/Reviewers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reviewer>>> Getreviewers()
        {
            return await _context.reviewers.ToListAsync();
        }

        // GET: api/Reviewers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reviewer>> GetReviewer(int id)
        {
            var reviewer = await _context.reviewers.FindAsync(id);

            if (reviewer == null)
            {
                return NotFound();
            }

            return reviewer;
        }

        // PUT: api/Reviewers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviewer(int id, Reviewer reviewer)
        {
            if (id != reviewer.Id)
            {
                return BadRequest();
            }

            _context.Entry(reviewer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewerExists(id))
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

        // POST: api/Reviewers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reviewer>> PostReviewer(Reviewer reviewer)
        {
            _context.reviewers.Add(reviewer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReviewer", new { id = reviewer.Id }, reviewer);
        }

        // DELETE: api/Reviewers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewer(int id)
        {
            var reviewer = await _context.reviewers.FindAsync(id);
            if (reviewer == null)
            {
                return NotFound();
            }

            _context.reviewers.Remove(reviewer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReviewerExists(int id)
        {
            return _context.reviewers.Any(e => e.Id == id);
        }
    }
}
