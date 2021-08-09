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

        public Task<ReviewerDto> GetReviewer(int id)
        {
            throw new NotImplementedException(); // LINQ-stuff here
        }

        public Task<List<ReviewerDto>> GetReviewers()
        {
            throw new NotImplementedException(); // LINQ-stuff here
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
