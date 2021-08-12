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
    public class BusinessService : IBusiness
    {

        private readonly BusinessDbContext _context;
        public BusinessService(BusinessDbContext context)
        {
            _context = context;
        }
        public async Task<Business> Create(Business business)
        {
            _context.Entry(business).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return business;
        }

        public async Task<BusinessDto> GetBusiness(int id) // async
        {
            //id, name, address, city, state, phone, type
            // reviwerId, businessId, Rating, rating
            return await _context.businesses
                .Select(business => new BusinessDto
                {
                    Id = business.Id,
                    Name = business.Name,
                    Address = business.Address,
                    City = business.City,
                    State = business.State,
                    PhoneNumber = business.PhoneNumber,
                    Type = business.Type,
                    /*Reviewers = business.BusinessReviews
                        .Select(t => new BusinessReviewDto
                        {
                            ReviewerId = t.reviewer.Id,
                            BusinessId = t.business.Id,
                            Rating = t.Rating,
                            Review = t.Review
                        }).ToList()*/
                }).FirstOrDefaultAsync(s => s.Id == id);
        }

        //GET BUSINESS BY NAME
        public async Task<BusinessSmsDto> GetBusinessByName(string name)
        {
            return await _context.businesses
                .Select(b => new BusinessSmsDto
                {
                    Name = b.Name,
                    Address = b.Address,
                    //ADD MAYBE: CUMULATIVE RATING
                    Review = b.BusinessReviews
                    .Select(br => new BusinessReviewDto
                    {
                        Rating = br.Rating,
                        Review = br.Review
                    }).ToString()
                }).FirstOrDefaultAsync(b => b.Name == name);
        }
        public async Task<List<BusinessDto>> GetBusinesses() // async
        {
            return await _context.businesses
                .Select(business => new BusinessDto
                {
                    Id = business.Id,
                    Name = business.Name,
                    Address = business.Address,
                    City = business.City,
                    State = business.State,
                    PhoneNumber = business.PhoneNumber,
                    Type = business.Type,
                    /*Reviewers = business.BusinessReviews
                        .Select(t => new BusinessReviewDto
                        {
                            ReviewerId = t.reviewer.Id,
                            BusinessId = t.business.Id,
                            Rating = t.Rating,
                            Review = t.Review
                        }).ToList()*/
                }).ToListAsync();
        }
        public async Task<Business> UpdateBusiness(int id, Business business)
        {
            _context.Entry(business).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return business;
        }
        public async Task Delete(int id)
        {
            Business business = await _context.businesses.FindAsync(id);
            _context.Entry(business).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
