using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data;
using TimedAssignment.Data.Entities;
using TimedAssignment.Models.Comment;

namespace TimedAssignment.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly int _userId;
        public CommentService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
            if (!validId)
                throw new Exception("Attempted to build Comment Service without User Id claim.");

            _dbContext = context;
        }
        // [Authorize]
        //Create
        public async Task<bool> CreateCommentAsync(CommentCreate request)
        {
            if (_userId != request.AuthorId)
                return false;

            var commentEntity = new CommentEntity {
                Text = request.Text,
                PostId = request.ParentPostId,
                AuthorId = request.AuthorId,
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
                .Where( commentEntity => commentEntity.PostId == postId )
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