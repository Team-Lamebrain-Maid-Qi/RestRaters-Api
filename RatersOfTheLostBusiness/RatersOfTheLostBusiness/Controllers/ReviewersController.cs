using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RatersOfTheLostBusiness.Data;
using RatersOfTheLostBusiness.Models;
using RatersOfTheLostBusiness.Models.DTOs;
using RatersOfTheLostBusiness.Models.Interfaces;

namespace RatersOfTheLostBusiness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewersController : ControllerBase
    {
        private readonly IReviewer _reviewer;

        public ReviewersController(IReviewer r)
        {
            _reviewer = r;
        }

        // GET: api/Reviewers // Multi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewerDto>>> Getreviewers()
        {
            var list = await _reviewer.GetReviewers();
            return Ok(list);
        }

        // GET: api/Reviewers/5 // Single
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewerDto>> GetReviewer(int id)
        {
            ReviewerDto reviewer = await _reviewer.GetReviewer(id);
            return reviewer;
        }

        // PUT: api/Reviewers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReviewer(int id, Reviewer reviewer) // Maybe Dto?
        {
            if (id != reviewer.Id)
            {
                return BadRequest();
            }
            var updatedReviewer = await _reviewer.UpdateReviewers(id, reviewer);
            return Ok(updatedReviewer);
        }

        // POST: api/Reviewers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ReviewerDto>> PostReviewer(Reviewer reviewer)
        {
            await _reviewer.Create(reviewer);

            return CreatedAtAction("GetReviewer", new { id = reviewer.Id }, reviewer);
        }

        // DELETE: api/Reviewers/5
        [Authorize(Roles = "administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewer(int id)
        {
            await _reviewer.Delete(id);

            return NoContent();
        }

       /* private bool ReviewerExists(int id)
        {
            return _context.reviewers.Any(e => e.Id == id);
        }
       */
    }
}
