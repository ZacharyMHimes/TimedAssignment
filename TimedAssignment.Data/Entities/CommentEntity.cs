using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TimedAssignment.Data.Entities
{
    public class CommentEntity
    {
        // Comment class
        // int Id
        [Key]
        public int Id { get; set; }
        // string Text
        [Required]
        public string Text { get; set; }


        // (virtual list of Replies)
        public List<ReplyEntity>? Replies { get; set; }
        
        // (Foreign Key to Post via Id w/ virtual Post)
        [Required]
        [ForeignKey(nameof(ParentPost))]
        public int PostId { get; set; }
        public PostEntity ParentPost { get; set; }
        
        [Required]
        public DateTimeOffset CreatedUTC { get; set; }
        public DateTimeOffset? ModifiedUTC { get; set; }
        
        // Guid AuthorId
        [Required]
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public UserEntity Author {get; set;}

    }
}