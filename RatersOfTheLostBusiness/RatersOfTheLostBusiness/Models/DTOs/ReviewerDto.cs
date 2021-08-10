using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Models.DTOs
{
    public class ReviewerDto
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
        public IList<string> Roles { get; set; }
        public string UserName { get; set; }

        // Navigation goes here
        public List<BusinessReviewDto> Reviewers { get; set; }
    }
}
