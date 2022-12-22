using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Data.Entities
{
    public class UserEntity
    {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public string? FirstName { get; set; } //Leaving User First and Last Nullable (?)
    public string? LastName { get; set; } //solves some issues with non-nullable fields in SQL Db later on. -zmh
    [Required]
    public DateTime DateCreated { get; set; }
    }
}