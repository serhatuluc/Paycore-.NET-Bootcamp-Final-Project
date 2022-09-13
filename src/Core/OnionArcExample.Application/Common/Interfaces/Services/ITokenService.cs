using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application.Common.Interfaces.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> GenerateToken(TokenRequest tokenRequest);
    }
}
