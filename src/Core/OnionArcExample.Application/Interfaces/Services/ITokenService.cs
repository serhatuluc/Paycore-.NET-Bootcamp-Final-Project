
using System.Threading.Tasks;

namespace OnionArcExample.Application
{
    public interface ITokenService
    {
        Task<BaseResponse<TokenResponse>> GenerateToken(TokenRequest tokenRequest);
    }
}
