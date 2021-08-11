using RatersOfTheLostBusiness.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Models.Interfaces
{
    public interface IBusiness
    {
        // Create
        Task<Business> Create(Business business);

        // Get All
        Task<List<BusinessDto>> GetBusinesses();

        // Get One by ID
        Task<BusinessDto> GetBusiness(int id);


        //GET BUSINESS BY NAME
        Task<BusinessSmsDto> GetBusinessByName(string name);

        // Update
        Task<Business> UpdateBusiness(int id, Business business);

        // Delete
        Task Delete(int id);
    }
}
