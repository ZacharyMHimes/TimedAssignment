using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
                AuthorId = request.AuthorId ,
                CreatedUTC = DateTimeOffset.Now
            };

            _dbContext.Comment.Add(commentEntity);
            
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }
        //Read
        public async Task<List<CommentListItem>> GetCommentsByPostIdAsync(int postId)
        {
            var comments = await _dbContext.Comment
                .Where( commentEntity => commentEntity.PostId == postId)
                .Select( commentEntity => new CommentListItem {
                    Id = commentEntity.Id,
                    ParentPostId = commentEntity.PostId,
                    AuthorId = commentEntity.AuthorId,
                    AuthorUsername = commentEntity.Author.Username,
                    Text = commentEntity.Text,
                    CreatedUTC = commentEntity.CreatedUTC,
                    ModifiedUTC = commentEntity.ModifiedUTC 
                } )
                .ToListAsync();
            
            return comments;

        }
        //Update
        //Delete
    }
}