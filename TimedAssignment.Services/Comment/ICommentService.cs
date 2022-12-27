using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models.Comment;

namespace TimedAssignment.Services.Comment
{
    public interface ICommentService
    {
        public Task<bool> CreateCommentAsync(CommentCreate newComment);
        public Task<List<CommentListItem>> GetCommentsByPostIdAsync(int Id);
    }
}