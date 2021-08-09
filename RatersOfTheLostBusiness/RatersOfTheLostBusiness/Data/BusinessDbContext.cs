using Microsoft.EntityFrameworkCore;
using RatersOfTheLostBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Data
{
    public class BusinessDbContext : DbContext
    {
        public DbSet<Business> businesses { get; set; }
        public DbSet<Reviewer> reviewers { get; set; }

        public DbSet<BusinessReview> businessReviews { get; set; }

        public BusinessDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessReview>().HasKey(
                businessReview => new { businessReview.BusinessId, businessReview.ReviewerId }
                );
        }
    }
}
