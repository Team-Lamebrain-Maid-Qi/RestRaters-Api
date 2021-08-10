﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RatersOfTheLostBusiness.Models.DTOs;
using RatersOfTheLostBusiness.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Models.Services
{
    public class IdentityUserService : IUser
    {
        private UserManager<ApplicationUser> userManager;
        private JwtTokenService tokenService;

        public IdentityUserService(UserManager<ApplicationUser> manager, JwtTokenService jwtTokenService)
        {
            userManager = manager;
            tokenService = jwtTokenService;
        }

        /* public Task<UserDto> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }*/

        public async Task<UserDto> Authenticate(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);

            // Is the password legit?
            if (await userManager.CheckPasswordAsync(user, password))
            {
                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15))
                };
            }

            return null;
        }

        public async Task<UserDto> Register(RegisterUserDto data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };
            var result = await userManager.CreateAsync(user, data.Password);
            if (result.Succeeded)
            {

                return new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }
            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";

                modelState.AddModelError(errorKey, error.Description);

            }
            return null;
        }
        public async Task<UserDto> GetUser(ClaimsPrincipal principal)
        {
            var user = await userManager.GetUserAsync(principal);
            Console.WriteLine(user);
            return new UserDto
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15))
            };
        }

    }
}
