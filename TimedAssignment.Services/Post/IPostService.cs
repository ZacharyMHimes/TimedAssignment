using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models.Post;

namespace TimedAssignment.Services.Post
{
    public interface IPostService
    {
        public Task<bool> CreatePostAsync(PostCreate request);
        public Task<IEnumerable<PostListItem>> GetAllPostsAsync();
    }
}