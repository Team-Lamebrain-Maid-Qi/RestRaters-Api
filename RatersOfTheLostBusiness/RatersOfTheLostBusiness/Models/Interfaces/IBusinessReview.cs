using RatersOfTheLostBusiness.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Models.Interfaces
{
    public interface IBusinessReview
    {
        // Create
        Task<BusinessReview> Create(BusinessReview business);
        // Get All
        Task<List<BusinessReviewDto>> GetBusinessReviews();
        // Get one by ID
        Task<BusinessReviewDto> GetBusinessReview(int id);
        // Update
        Task<BusinessReview> UpdatedBusinessReview(int ReviewerId, int BusinessId, BusinessReview businessReview); // Probably needs to connected to business and *reviewer
        // Delete
        Task Delete(int id);
    }
}
