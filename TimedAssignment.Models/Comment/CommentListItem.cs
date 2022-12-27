using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Comment
{
    public class CommentListItem
    {
        public int Id {get; set;}
        public int ParentPostId {get; set;}
        public string Text {get;set;}
        public int AuthorId {get; set;}
        public DateTimeOffset CreatedUTC {get;set}
        public DateTimeOffset? ModifiedUTC {get; set;}

    }
}