using Microsoft.AspNetCore.Mvc;
using OnionArcExample.Application;
using OnionArcExample.Application.Common.Interfaces.Services;
using System.Threading.Tasks;

namespace OnionArcExample.WebAPI
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public TokenController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }


        [HttpPost("Login")]
        public async Task<TokenResponse> Login([FromBody] TokenRequest request)
        {
            var response = await tokenService.GenerateToken(request);
            return response;
        }

    }
 }
