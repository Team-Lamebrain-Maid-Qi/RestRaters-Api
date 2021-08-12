﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Models.DTOs
{
    public class BusinessSmsDto
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Review { get; set; }

        public BusinessReviewDto ReviewSms { get; set; }
    }
}
