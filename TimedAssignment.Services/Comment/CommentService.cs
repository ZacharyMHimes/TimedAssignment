using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Data;
using TimedAssignment.Data.Entities;
using TimedAssignment.Models.Comment;

namespace TimedAssignment.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _dbContext;
        public CommentService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        //Create
        public async Task<bool> CreateCommentAsync(CommentCreate request)
        {
            var commentEntity = new CommentEntity {
                Text = request.Text,
                PostId = request.ParentPostId,
                AuthorId = request.AuthorId
            };

            _dbContext.Comment.Add(commentEntity);
            
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }
        //Read
        //Update
        //Delete
    }
}