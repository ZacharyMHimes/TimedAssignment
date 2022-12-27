using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Reply
{
    public class ReplyDetail
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedUtc {get; set;}
        public DateTimeOffset? ModifiedUtc {get; set;}
    }
}