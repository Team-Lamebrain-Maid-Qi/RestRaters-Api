using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Models
{
    public class BusinessReview
    {
        [Column(TypeName = "decimal(6,2)")]
        public decimal Rating { get; set; }
        public string Review { get; set; }
        public int BusinessId { get; set; }
        public int ReviewerId { get; set; }
        public Business business { get; set; } // Nav stuff
        public Reviewer reviewer { get; set; } // Nav stuff

        // Rating, Review, busId, Revid
    }
}
