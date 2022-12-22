using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Models.User;
using TimedAssignment.Services.Post;
using TimedAssignment.Services.User;

namespace TimedAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        public PostController(IUserService userService, IPostService postService)
        {
            _userService = userService;
            _postService = postService;
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] UserRegister model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var registerResult = await _service.CreatePostAsync(model)
        if (registerResult)
        {
            return Ok("User was registered.");
        }
    }
}
