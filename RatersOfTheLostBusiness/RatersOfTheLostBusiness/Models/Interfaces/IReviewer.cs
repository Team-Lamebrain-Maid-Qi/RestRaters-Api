using RatersOfTheLostBusiness.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Models.Interfaces
{
    public interface IReviewer
    {
        // Create
        Task<Reviewer> Create(Reviewer reviewer);

        // Get All
        Task<List<ReviewerDto>> GetReviewers();

        // Get One by ID
        Task<ReviewerDto> GetReviewer(int id);

        // Update
        Task<Reviewer> UpdateReviewers(int id, Reviewer reviewer);

        // Delete
        Task Delete(int id);
    }
}
