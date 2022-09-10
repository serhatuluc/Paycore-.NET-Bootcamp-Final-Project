﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnionArcExample.Application.Interfaces.Repositories;
using OnionArcExample.Domain;
using Serilog;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnionArcExample.Application
{

    public class TokenService : ITokenService
    {
        protected readonly IAccountRepository accountRepository;
        private readonly JwtConfig jwtConfig;

        public TokenService(IOptionsMonitor<JwtConfig> jwtConfig, IAccountRepository accountRepository)
        {
            this.jwtConfig = jwtConfig.CurrentValue;
            this.accountRepository = accountRepository;
           
        }

        public async Task<BaseResponse<TokenResponse>> GenerateToken(TokenRequest tokenRequest)
        {
            try
            {
                if (tokenRequest is null)
                {
                    return new BaseResponse<TokenResponse>("Please enter valid informations.");
                }

                var accounts = await accountRepository.GetAll(x => x.UserName.Equals(tokenRequest.UserName));
                var account = accounts.FirstOrDefault();
                if (account is null)
                {
                    return new BaseResponse<TokenResponse>("Please validate your informations that you provided.");
                }

                if (!account.Password.Equals(tokenRequest.Password))
                {
                    return new BaseResponse<TokenResponse>("Please validate your informations that you provided.");
                }

                DateTime now = DateTime.UtcNow;
                string token = GetToken(account, now);

                account.LastActivity = now;

                await accountRepository.Update(account);

                TokenResponse tokenResponse = new TokenResponse
                {
                    AccessToken = token,
                    ExpireTime = now.AddMinutes(jwtConfig.AccessTokenExpiration),
                    Role = account.Role,
                    UserName = account.UserName,
                    SessionTimeInSecond = jwtConfig.AccessTokenExpiration * 60
                };

                return new BaseResponse<TokenResponse>(tokenResponse);
            }
            catch (Exception ex)
            {
                Log.Error("GenerateToken :", ex);
                return new BaseResponse<TokenResponse>("GenerateToken Error");
            }
        }
        private string GetToken(Account account, DateTime date)
        {
            Claim[] claims = GetClaims(account);
            byte[] secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                shouldAddAudienceClaim ? jwtConfig.Audience : string.Empty,
                claims,
                expires: date.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }

        private Claim[] GetClaims(Account account)
        {
            var claims = new[]
         {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.UserName),
                new Claim(ClaimTypes.Role, account.Role),
                new Claim("AccountId", account.Id.ToString()),
                new Claim("Email",account.Email)
            };
            return claims;
        }
    }
}
