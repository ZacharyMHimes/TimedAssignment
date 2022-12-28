using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Reply
{
    public class ReplyListItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedUtc {get; set;}
        public object AuthorId { get; set; }
    }
}