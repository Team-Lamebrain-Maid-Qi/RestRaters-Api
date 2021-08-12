using RatersOfTheLostBusiness.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatersOfTheLostBusiness.Models;

namespace TestProject1
{
    public abstract class MockTest
    {
        public readonly BusinessDbContext _context;

        public async Task<Business> CanPost()
        {
           var b = new Business { Id = 5, Name = "TobbyLobby", Address = "1 Main St", City = "Kansas City", State = "KA", PhoneNumber = "555-555-5555", Type = "Store" };
           var business = _context.businesses.Add(b);
           await _context.SaveChangesAsync();
           return b;
        }
    }
}
