﻿using Microsoft.EntityFrameworkCore;
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

        private BusinessDbContext _context;
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
        public Task<BusinessDto> GetBusiness(int id) // async
        {
            throw new NotImplementedException(); // LINQ-stuff here
        }
        public Task<List<BusinessDto>> GetBusinesses() // async
        {
            throw new NotImplementedException(); // LINQ-stuff here
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
