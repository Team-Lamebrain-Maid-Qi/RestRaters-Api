using System;
using Xunit;
using RatersOfTheLostBusiness;
using RatersOfTheLostBusiness.Data;
using RatersOfTheLostBusiness.Controllers;
using RatersOfTheLostBusiness.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace TestProject1
{
    public class UnitTest1 : MockTest
    {

        [Fact]
        public async Task CanPostBusiness()
        {
            var business = await CanPost();
            var service = new BusinessService(_context);
            var result = await service.GetBusiness(3);

            Assert.Equal(3, result.Id);
        }
    }
}
