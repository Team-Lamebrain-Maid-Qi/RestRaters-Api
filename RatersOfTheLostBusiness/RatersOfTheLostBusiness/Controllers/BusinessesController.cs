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
    public class BusinessesController : ControllerBase
    {
        private readonly BusinessDbContext _context;

        public BusinessesController(BusinessDbContext context)
        {
            _context = context;
        }

        // GET: api/Businesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Business>>> Getbusinesses()
        {
            return await _context.businesses.ToListAsync();
        }

        // GET: api/Businesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Business>> GetBusiness(int id)
        {
            var business = await _context.businesses.FindAsync(id);

            if (business == null)
            {
                return NotFound();
            }

            return business;
        }

        // PUT: api/Businesses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusiness(int id, Business business)
        {
            if (id != business.Id)
            {
                return BadRequest();
            }

            _context.Entry(business).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(id))
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

        // POST: api/Businesses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Business>> PostBusiness(Business business)
        {
            _context.businesses.Add(business);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusiness", new { id = business.Id }, business);
        }

        // DELETE: api/Businesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(int id)
        {
            var business = await _context.businesses.FindAsync(id);
            if (business == null)
            {
                return NotFound();
            }

            _context.businesses.Remove(business);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusinessExists(int id)
        {
            return _context.businesses.Any(e => e.Id == id);
        }
    }
}
