using Microsoft.EntityFrameworkCore;
using RatersOfTheLostBusiness.Data;
using RatersOfTheLostBusiness.Models.DTOs;
using RatersOfTheLostBusiness.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Models.Services
{
    public class ReviewerService : IReviewer
    {
        public BusinessDbContext _context;
        public ReviewerService(BusinessDbContext context)
        {
            _context = context;
        }
        public async Task<Reviewer> Create(Reviewer reviewer)
        {
            _context.Entry(reviewer).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return reviewer;
        }

        public async Task<ReviewerDto> GetReviewer(int id)
        {

            // Id, First, Last, Email, PhoneNumber
            return await _context.reviewers
                .Select(reviewers => new ReviewerDto
                {
                    Id = reviewers.Id,
                    First = reviewers.First,
                    Last = reviewers.Last,
                    Email = reviewers.Email,
                    PhoneNumber = reviewers.PhoneNumber,
                    UserName = reviewers.UserName,
                    Reviewers = reviewers.BusinessReviews
                        .Select(t => new BusinessReviewDto
                        {
                            ReviewerId = t.reviewer.Id,
                            BusinessId = t.business.Id,
                            Rating = t.Rating,
                            Review = t.Review
                        }).ToList()
                }).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<ReviewerDto>> GetReviewers()
        {
            return await _context.reviewers
                .Select(reviewers => new ReviewerDto
                {
                    Id = reviewers.Id,
                    First = reviewers.First,
                    Last = reviewers.Last,
                    Email = reviewers.Email,
                    PhoneNumber = reviewers.PhoneNumber,
                    UserName = reviewers.UserName,
                    Reviewers = reviewers.BusinessReviews
                        .Select(t => new BusinessReviewDto
                        {
                            ReviewerId = t.reviewer.Id,
                            BusinessId = t.business.Id,
                            Rating = t.Rating,
                            Review = t.Review,
                            Name = t.business.Name,
                        }).ToList()
                }).ToListAsync();
        }

        public async Task<Reviewer> UpdateReviewers(int id, Reviewer reviewer)
        {
            _context.Entry(reviewer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return reviewer;
        }
        public async Task Delete(int id)
        {
            ReviewerDto reviewer = await GetReviewer(id);
            _context.Entry(reviewer).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        // add review to business
        // remove review from business
    }
}
