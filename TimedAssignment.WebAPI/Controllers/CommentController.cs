using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Models.Comment;
using TimedAssignment.Services.Comment;

namespace TimedAssignment.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var succeeded = await _commentService.CreateCommentAsync(model);

            if (succeeded)
                return Ok("Comment successfully created");
            
            return BadRequest("Failed to create comment");

        }
        [HttpGet]
        [Route("{postId}")]
        public async Task<IActionResult> GetCommentsByPostId([FromRoute] int postId)
        {
            var comments = await _commentService.GetCommentsByPostIdAsync(postId);

            return Ok(comments);
        }
    }
}