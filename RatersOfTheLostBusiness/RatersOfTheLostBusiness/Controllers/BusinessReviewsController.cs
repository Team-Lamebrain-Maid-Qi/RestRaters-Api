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
    public class BusinessReviewsController : ControllerBase
    {
        private readonly IBusinessReview _businessReview;

        public BusinessReviewsController(IBusinessReview br)
        {
            _businessReview = br;
        }

        // GET: api/BusinessReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessReviewDto>>> GetbusinessReviews()
        {
            var list = await _businessReview.GetBusinessReviews();
            return Ok(list);
        }

        // GET: api/BusinessReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessReviewDto>> GetBusinessReview(int id)
        {
            BusinessReviewDto businessReview = await _businessReview.GetBusinessReview(id);

            return businessReview;
        }

        // PUT: api/BusinessReviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessReview(int ReviewerId, int BusinessId, BusinessReview businessReview)
        {
            if (ReviewerId != businessReview.ReviewerId || BusinessId != businessReview.BusinessId)
            {
                return BadRequest();
            }
            var updatedBusinessReview = await _businessReview.UpdatedBusinessReview(ReviewerId, BusinessId, businessReview);
            return Ok(updatedBusinessReview);
           
        }

        // POST: api/BusinessReviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<BusinessReview>> PostBusinessReview(BusinessReview businessReview)
        {
            await _businessReview.Create(businessReview);

            return CreatedAtAction("GetBusinessReview", new { id = businessReview.BusinessId }, businessReview);
        }

        // DELETE: api/BusinessReviews/5
        [Authorize(Roles = "administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinessReview(int id)
        {
            await _businessReview.Delete(id);

            return NoContent();
        }

        /* private bool BusinessReviewExists(int id)
        {
            return _context.businessReviews.Any(e => e.BusinessId == id);
        }*/
    }
}
