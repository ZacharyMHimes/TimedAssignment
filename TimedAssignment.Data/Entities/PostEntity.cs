using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TimedAssignment.Data.Entities
{
    public class PostEntity
    {
        [Required]
        public int Id;
        [Required]
        [MinLength
            (2, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength
            (100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string Title;
        [Required]
        [MaxLength
            (8000, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string? Text;
        public List<CommentEntity>? Comments {get; set;}
        Guid AuthorId {get; set;}
    }
}