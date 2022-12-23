using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Comment
{
    public class CommentCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "{0} must be at least {1} characters long")]
        [MaxLength(8000, ErrorMessage = "{0} can be no more than {1} characters long")]
        public string Text {get; set;}
        [Required]
        public int AuthorId {get; set;}
        [Required]
        public int ParentPostId {get; set;}
    }
}