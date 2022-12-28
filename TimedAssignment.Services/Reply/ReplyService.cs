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

        public ReplyService(ApplicationDbContext context)
            {
                _context = context;
            }
        public async Task<bool> CreateReplyAsync(ReplyCreate request)
        {
            var replyEntity = new ReplyEntity 
            {
                Text = request.Text,
                CreatedUtc = DateTimeOffset.Now,
                ParentCommentId = request.ParentCommentId,
                AuthorId = _userId, 
            };

            _context.Reply.Add(replyEntity);

            var numberOfChanges = await _context.SaveChangesAsync();
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
            var replyEntity = await _context.Reply.FirstOrDefaultAsync(e =>
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
            var replyEntity = await _context.Reply.FindAsync(request.AuthorId);

            if (replyEntity?.AuthorId != _userId)
                return false;

            replyEntity.Text = request.Text;
            replyEntity.ParentCommentId = request.ParentCommentId;
            replyEntity.ModifiedUtc = DateTimeOffset.Now;

            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteReplyAsync(int replyId)
        {
            var replyEntity = await _context.Reply.FindAsync(replyId);

            if (replyEntity?.AuthorId != _userId)
                return false;
            
            _context.Reply.Remove(replyEntity);
            return await _context.SaveChangesAsync() == 1;
        } 
    }
}