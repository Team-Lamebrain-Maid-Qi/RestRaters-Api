using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RatersOfTheLostBusiness.Models.DTOs;
using RatersOfTheLostBusiness.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatersOfTheLostBusiness.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUser userService;

        public UsersController(IUser service)
        {
            userService = service;
        }

        // Routes
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterUserDto data)
        {
            var user = await userService.Register(data, this.ModelState);
            if (ModelState.IsValid)
            {
                return user;
            }

            return BadRequest(new ValidationProblemDetails(ModelState));

            // We're gonna need to let people know if their password sucks or email is invalid...
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto data)
        {
            var user = await userService.Login(data.Username, data.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }
      
    }
}
