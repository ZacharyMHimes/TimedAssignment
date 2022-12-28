using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimedAssignment.Models.Reply;
using TimedAssignment.Services.Reply;

namespace TimedAssignment.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyService _replyService;
        public ReplyController(IReplyService replyService)
        {
            _replyService = replyService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReply([FromBody] ReplyCreate request)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            if (await _replyService.CreateReplyAsync(request))
            return Ok("Reply created successfully.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReplies()
        {
            var replies = await _replyService.GetAllRepliesAsync();
            return Ok();
        }

        [HttpGet("{replyId:int}")]
        public async Task<IActionResult> GetReplyById([FromRoute] int replyId)
        {
            var detail = await _replyService.GetReplyIdAsync(replyId);

            return detail is not null
            ? Ok(detail)
            : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReplyById([FromBody] ReplyUpdate request)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);

            return await _replyService.UpdateReplyAsync(request)
            ? Ok("Reply updated successfully.")
            : BadRequest("Reply could not be updated.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReply([FromRoute] int replyId)
        {
            return await _replyService.DeleteReplyAsync(replyId)
            ? Ok($"Reply {replyId} was deleted successfully.")
            : BadRequest($"Reply {replyId} could not be deleted.");
        }
    }
}