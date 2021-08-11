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
    public class BusinessesController : ControllerBase
    {
        private readonly IBusiness _business;
        public BusinessesController(IBusiness b)
        {
            _business = b;
        }

        // GET: api/Businesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessDto>>> Getbusinesses()
        {
            var list = await _business.GetBusinesses();
            return Ok(list);
        }

        // GET: api/Businesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessDto>> GetBusiness(int id)
        {
            BusinessDto business = await _business.GetBusiness(id);
            return business;
        }

        // PUT: api/Businesses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusiness(int id, Business business)
        {
            if (id != business.Id)
            {
                return BadRequest();
            }
            var updatedBusiness = await _business.UpdateBusiness(id, business);
            return Ok(updatedBusiness);
        }

        // POST: api/Businesses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Business>> PostBusiness(Business business)
        {
            await _business.Create(business);
            return CreatedAtAction("GetBusiness", new { id = business.Id }, business);
        }

        // DELETE: api/Businesses/5
        [Authorize(Roles = "administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(int id)
        {
            await _business.Delete(id);
            return NoContent();
        }

        /* private bool BusinessExists(int id)
        {
            return _business.Any(e => e.Id == id);
        } */
    }
}
