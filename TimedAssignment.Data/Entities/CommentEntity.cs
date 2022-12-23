using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int Id {get; set;}
        // string Text
        [Required]
        public string Text {get; set;}
        // Guid AuthorId
        [Required]
        public int AuthorId {get; set;}
        // (virtual list of Replies)
        // (Foreign Key to Post via Id w/ virtual Post)
    }
}