using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Models.DTOs
{
    public class ReviewerDto
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
        public IList<string> Roles { get; set; }

        // Navigation goes here
    }
}
