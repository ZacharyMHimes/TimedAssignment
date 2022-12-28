using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Data;
using TimedAssignment.Data.Entities;
using TimedAssignment.Models.Post;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace TimedAssignment.Services.Post
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;
        private readonly int _userId;
        public PostService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
            if(!validId)
                throw new Exception("Attempted to build NoteService without User Id claim.");

            _context = context;   
        }
        public async Task<bool> CreatePostAsync(PostCreate request)
        {
            var entity = new PostEntity
            {
                Title = request.Title,
                Text = request.Text
            };

            _context.Post.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }
        public async Task<IEnumerable<PostListItem>> GetAllPostsAsync()
        {
            var posts = await _context.Post
                .Where(entity => entity.AuthorId == _userId)
                .Select(entity => new PostListItem
                {
                    Id = entity.Id,
                    Title = entity.Title,
                    CreatedUtc = entity.CreatedUtc
                })
                .ToListAsync();
            
                return posts;
        }
    }
}