using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Models.User;
using TimedAssignment.Services.Post;
using TimedAssignment.Services.User;
using Microsoft.AspNetCore.Authorization;
using TimedAssignment.Models.Post;

namespace TimedAssignment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IUserService userService, IPostService postService)
        {
            _postService = postService;
        }
    

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] PostCreate request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Task<bool> task = _postService.CreatePostAsync(request);
        var registerResult = await task;
        if (registerResult)
        {
            return Ok("Post submitted.");
        }
        return BadRequest("Post could not be created.");
    }
    }
}
