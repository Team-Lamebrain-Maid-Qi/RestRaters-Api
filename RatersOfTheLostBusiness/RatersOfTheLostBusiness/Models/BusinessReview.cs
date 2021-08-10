using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Models
{
    public class BusinessReview
    {
        public int Rating { get; set; }
        public string Review { get; set; }
        public int BusinessId { get; set; }
        public int ReviewerId { get; set; }
        public Business business { get; set; }
        public Reviewer reviewer { get; set; }
    }
}
