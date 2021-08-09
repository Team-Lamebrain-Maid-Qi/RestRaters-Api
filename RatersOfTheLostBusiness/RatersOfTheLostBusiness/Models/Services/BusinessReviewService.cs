using RatersOfTheLostBusiness.Data;
using Microsoft.EntityFrameworkCore;
using RatersOfTheLostBusiness.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RatersOfTheLostBusiness.Models.DTOs;

namespace RatersOfTheLostBusiness.Models.Services
{
    public class BusinessReviewService : IBusinessReview
    {
        private BusinessDbContext _context;
        public BusinessReviewService(BusinessDbContext context)
        {
            _context = context;
        }
        public async Task<BusinessReview> Create(BusinessReview businessreview)
        {
            _context.Entry(businessreview).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return businessreview;
        }
        public Task<BusinessReviewDto> GetBusinessReview(int id) // async
        {
            throw new NotImplementedException(); // LINQ-stuff here
        }
        public Task<List<BusinessReviewDto>> GetBusinessReviews() // async
        {
            throw new NotImplementedException(); // LINQ-stuff here
        }
        public async Task<BusinessReview> UpdatedBusinessReview(int id, BusinessReview businessreview) // Probably needs to be connected to reviewer
        {
            _context.Entry(businessreview).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return businessreview;
        }
        public async Task Delete(int id)
        {
            BusinessReviewDto businessreview = await GetBusinessReview(id);
            _context.Entry(businessreview).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
