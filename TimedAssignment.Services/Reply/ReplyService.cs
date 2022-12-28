using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data;
using TimedAssignment.Data.Entities;
using TimedAssignment.Models.Reply;

namespace TimedAssignment.Services.Reply
{
    public class ReplyService : IReplyService
    {
        private readonly ApplicationDbContext _context;
        private int? _userId;
        private object _dbContext;

        public ReplyService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
            if (!validId)
                throw new Exception("Attempted to build Reply Service without User Id claim.");

            _dbContext = context;

        public async Task<bool> CreateReplyAsync(ReplyCreate request)
        {
            var replyEntity = new ReplyEntity 
            {
                Text = request.Text,
                CreatedUtc = DateTimeOffset.Now,
                ParentCommentId = request.ParentCommentId,
                AuthorId = _userId, 
            };

            _dbContext.Reply.Add(replyEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<ReplyListItem>> GetAllRepliesAsync()
        {
            var replies = await _context.Replies
                .Where(entity => entity.AuthorId == _userId)
                .Select(entity => new ReplyListItem
                {
                AuthorId = entity.AuthorId,
                Text = entity.Text,
                CreatedUtc = entity.CreatedUtc
            })
            .ToListAsync();

            return replies;
        }

        public async Task<ReplyDetail> GetReplyIdAsync(int replyId)
        {
            var replyEntity = await _dbContext.Reply.FirstOrDefaultAsync(e =>
            e.Id == replyId && e.AuthorId == _userId);

            return replyEntity is null ? null : new ReplyDetail
            {
                AuthorId = replyEntity.AuthorId,
                Text = replyEntity.Text,
                ParentCommentId = replyEntity.ParentCommentId,
                CreatedUtc = replyEntity.CreatedUtc,
                ModifiedUtc = replyEntity.ModifiedUtc
            };
        }

        public async Task<bool> UpdateReplyAsync(ReplyUpdate request)
        {
            var replyEntity = await _dbContext.Reply.FindAsync(request.AuthorId);

            if (replyEntity?.AuthorId != _userId)
                return false;

            replyEntity.Text = request.Text;
            replyEntity.ParentCommentId = request.ParentCommentId;
            replyEntity.ModifiedUtc = DateTimeOffset.Now;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteReplyAsync(int replyId)
        {
            var replyEntity = await _dbContext.Reply.FindAsync(replyId);

            if (replyEntity?.AuthorId != _userId)
                return false;
            
            _dbContext.Reply.Remove(replyEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        } 
    }
}