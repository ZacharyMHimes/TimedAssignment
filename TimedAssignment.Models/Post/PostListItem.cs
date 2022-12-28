using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Post
{
    public class PostListItem
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Text {get;set;}
        public int AuthorId {get; set;}
        public DateTimeOffset CreatedUtc {get;set;}
        public DateTimeOffset? ModifiedUtc {get; set;}
    }
}