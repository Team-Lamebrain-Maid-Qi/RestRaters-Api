using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string Type { get; set; }

        // Navigation goes here
        public List<BusinessReview> BusinessReviews { get; set; }
    }
}
