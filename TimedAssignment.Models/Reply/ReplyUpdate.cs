using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Reply
{
    public class ReplyUpdate
    {
        
        [Required]
        [MinLength
            (2, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength
            (100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string Text { get; set; }
        [Required]
        public int ParentCommentId { get; set; }
        [Required]
        [MaxLength
            (8000, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public int AuthorId { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}