using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RatersOfTheLostBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Data
{

    public class BusinessDbContext : IdentityDbContext<ApplicationUser>
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
            // Id, First, Last, Email, PhoneNumber
            modelBuilder.Entity<Reviewer>().HasData(
                new Reviewer
                {
                    Id = 1,
                    First = "John",
                    Last = "Stewart",
                    Email = "JS191@example.com",
                    PhoneNumber = "555-555-1221",
                    UserName = "BestGreenLatern"
                }
            );
            // Rating, Review, busId, Revid
            modelBuilder.Entity<BusinessReview>().HasData(
                new BusinessReview
                {
                    Rating = 1,
                    Review = "Terrible",
                    BusinessId = 1,
                    ReviewerId = 1
                }
            );
            // Joint Table Key
            modelBuilder.Entity<BusinessReview>().HasKey(
                businessReview => new { businessReview.BusinessId, businessReview.ReviewerId }
                );
            SeedRole(modelBuilder, "Administrator", "create", "update", "delete");
            SeedRole(modelBuilder, "Editor", "create", "update");
            SeedRole(modelBuilder, "Writer", "create");
        }
        private int nextId = 1;
        public void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);

            var roleClaims = permissions.Select(permission =>
                new IdentityRoleClaim<string>
                {
                    Id = nextId++,
                    RoleId = role.Id,
                    ClaimType = "permissions",
                    ClaimValue = permission
                }
            ).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }
    }
}
