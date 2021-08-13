using RatersOfTheLostBusiness.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RatersOfTheLostBusiness.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestProject1
{
    public abstract class MockTest
    {
        public readonly BusinessDbContext _context;
        private readonly SqliteConnection _connection;

        public MockTest() 
        {
            _connection = new SqliteConnection("FileName=:memory:");
            _connection.Open();
            var options = new DbContextOptionsBuilder<BusinessDbContext>().UseSqlite(_connection).Options;
            _context = new BusinessDbContext(options);
            _context.Database.EnsureCreated();
        }

        public async Task<Business> CanPost()
        {
           var b = new Business { Id = 5, Name = "TobbyLobby", Address = "1 Main St", City = "Kansas City", State = "KA", PhoneNumber = "555-555-5555", Type = "Store" };
           var business = _context.businesses.Add(b);
           await _context.SaveChangesAsync();
           return b;
        }
    }
}
