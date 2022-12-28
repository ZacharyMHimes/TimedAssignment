using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data.Entities;

namespace TimedAssignment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
        {
        } 
        public DbSet<UserEntity> User {get; set;}
        public DbSet<PostEntity> Post {get; set;}  
        public DbSet<CommentEntity> Comment {get; set;}
        public DbSet<ReplyEntity> Reply {get; set;}
        public IEnumerable<object> Replies { get; set; }
    }
}