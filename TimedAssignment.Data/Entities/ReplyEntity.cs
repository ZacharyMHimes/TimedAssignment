using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Data.Entities
{

    public class ReplyEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc {get; set;}
        [Required]
        [ForeignKey(nameof(ParentComment))]
        public int ParentCommentId { get; set; }
        public CommentEntity ParentComment { get; set; }
        [Required]
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public UserEntity Author { get; set; }
    }
}