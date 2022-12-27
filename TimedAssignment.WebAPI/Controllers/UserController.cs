using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Models.Token;
using TimedAssignment.Models.User;
using TimedAssignment.Services.Post;
using TimedAssignment.Services.Token;
using TimedAssignment.Services.User;

namespace TimedAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        
    [HttpPost("~/api/Token")]
    public async Task<IActionResult> Token([FromBody] TokenRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var tokenResponse = await _tokenService.GetTokenAsync(request);
            if (tokenResponse is null)
                return BadRequest("Invalid username or password.");

            return Ok(tokenResponse);
        }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegister model)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest(ModelState);  
        }

        var registerResult = await _userService.RegisterUserAsync(model);
        if(registerResult)
        {
            return Ok("User was registered.");
        }
        
        return BadRequest("User could not be registered.");
    }
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetById([FromRoute] int userId)
    {
        var userDetail = await _userService.GetUserByIdAsync(userId);

        if(userDetail is null)
        {
            return NotFound();
        }
        return Ok(userDetail);
    }
    }
}
