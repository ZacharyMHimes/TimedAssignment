using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models.User;

namespace TimedAssignment.Services.User
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserRegister model);
        Task<UserDetail> GetUserByIdAsync(int userId); 
    }
}