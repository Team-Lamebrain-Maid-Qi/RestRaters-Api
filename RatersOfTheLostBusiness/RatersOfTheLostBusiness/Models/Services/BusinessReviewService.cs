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
        public async Task<BusinessReviewDto> GetBusinessReview(int id) // async
        {

            // BusinessId, ReviewId, Review and Rating - 
            // Id, Name, Address, Citym State, PhoneNumber, Type - Business
            // Id, First, Last, Email, PhoneNumber, UserName - Reviewer
            return await _context.businessReviews
                .Select(businessReview => new BusinessReviewDto
                {
                    BusinessId = businessReview.BusinessId,
                    ReviewerId = businessReview.ReviewerId,
                    Review = businessReview.Review,
                    Rating = businessReview.Rating,
                    reviewer = new ReviewerDto
                    {
                        Id = businessReview.reviewer.Id,
                        UserName = businessReview.reviewer.UserName,
                    },
                    business = new BusinessDto
                    {
                        Id = businessReview.business.Id,
                        Name = businessReview.business.Name,
                        City = businessReview.business.City,
                        State = businessReview.business.State,
                        Address = businessReview.business.Address,
                        PhoneNumber = businessReview.business.PhoneNumber,
                        Type = businessReview.business.Type
                    }
                }).FirstOrDefaultAsync();

        }
        public async Task<List<BusinessReviewDto>> GetBusinessReviews() // async
        {
            return await _context.businessReviews
                .Select(businessReview => new BusinessReviewDto
                {
                    BusinessId = businessReview.BusinessId,
                    ReviewerId = businessReview.ReviewerId,
                    Review = businessReview.Review,
                    Rating = businessReview.Rating,
                    reviewer = new ReviewerDto
                    {
                        Id = businessReview.reviewer.Id,
                        UserName = businessReview.reviewer.UserName,
                    },
                    business = new BusinessDto
                    {
                        Id = businessReview.business.Id,
                        Name = businessReview.business.Name,
                        City = businessReview.business.City,
                        State = businessReview.business.State,
                        Address = businessReview.business.Address,
                        PhoneNumber = businessReview.business.PhoneNumber,
                        Type = businessReview.business.Type
                    }
                }).ToListAsync();
        }
        public async Task<BusinessReview> UpdatedBusinessReview(int ReviewerId, int BusinessId, BusinessReview businessReview) // Probably needs to be connected to reviewer
        {
            _context.Entry(businessReview).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return businessReview;
        }
        public async Task Delete(int id)
        {
            BusinessReviewDto businessreview = await GetBusinessReview(id);
            _context.Entry(businessreview).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
