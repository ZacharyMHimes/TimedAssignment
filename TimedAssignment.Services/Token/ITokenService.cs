using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models.Token;

namespace TimedAssignment.Services.Token
{
    public interface ITokenService
    {
        Task<TokenResponse> GetTokenAsync(TokenRequest model);
    }
}