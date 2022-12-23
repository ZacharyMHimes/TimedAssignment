using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimedAssignment.Data.Entities
{
    public class PostEntity
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public string Title {get; set;}
        public string? Text {get; set;}
        [Required]
        public DateTimeOffset CreatedUtc {get; set;}
        public List<CommentEntity>? Comments {get; set;}
        //Author Foreign Key Code
        [Required]
        [ForeignKey (nameof(Author))]
        int AuthorId {get; set;}
        [Required]
        public UserEntity Author {get; set;}
    }
}