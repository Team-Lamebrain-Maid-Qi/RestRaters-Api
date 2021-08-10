using Microsoft.AspNetCore.Mvc.ModelBinding;
using RatersOfTheLostBusiness.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDto> Register(RegisterUserDto data, ModelStateDictionary modelState);
        //public Task<UserDto> Authenticate(string username, string password);
        public Task<UserDto> Authenticate(string username, string password);

        public Task<UserDto> GetUser(ClaimsPrincipal principal);
    }
}
