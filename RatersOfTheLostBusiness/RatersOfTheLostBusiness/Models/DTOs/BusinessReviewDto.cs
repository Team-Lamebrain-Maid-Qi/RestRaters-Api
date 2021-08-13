using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Models.DTOs
{
    public class BusinessReviewDto
    {
        // CK-FK ReviewerId
   
        public BusinessDto business { get; set; }
        public ReviewerDto reviewer { get; set; }
        public int Id { get; set; }
        public decimal Rating { get; set; }
        public string Review { get; set; }
        public int BusinessId { get; set; }
        public int ReviewerId { get; set; }
    }
}
