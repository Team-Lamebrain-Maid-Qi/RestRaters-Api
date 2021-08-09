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
            base.OnModelCreating(modelBuilder);
            //id, name, city, state, address, phone, type
            modelBuilder.Entity<Business>().HasData(
                new Business
                {
                    Id = 1,
                    Name = "Twilio",
                    Address = "375 Beale Street Suite 300",
                    City = "San Franciso",
                    State = "CA",
                    PhoneNumber = "844-814-4627",
                    Type = "Software Service"
                }
            );
           // modelBuilder.Entity<R>



            modelBuilder.Entity<BusinessReview>().HasKey(
                businessReview => new { businessReview.BusinessId, businessReview.ReviewerId }
                );

        }
    }
}
