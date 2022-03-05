using AuthJwt.Generates;
using Module.Query.User.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Module.Query.User.Business.Rule
{
    public interface IGenerateJwtTokenRule
    {
        Task<string?> Token(AuthUserHashPasswordResponseDTO authUserHashPasswordResponseDTO);
    }

    public class GenerateJwtTokenRule : IGenerateJwtTokenRule
    {
        private readonly IGenerateJwtToken? generateJwtToken = null;
        private readonly string? secreatKey = null;

        public GenerateJwtTokenRule(IGenerateJwtToken generateJwtToken, string? secretKey)
        {
            this.generateJwtToken = generateJwtToken;
            this.secreatKey = secretKey;
        }

        async Task<string?> IGenerateJwtTokenRule.Token(AuthUserHashPasswordResponseDTO authUserHashPasswordResponseDTO)
        {
            try
            {
                List<Claim> claims = new List<Claim>(); ;
                claims.Add(new Claim(ClaimTypes.Name, Convert.ToString(authUserHashPasswordResponseDTO?.UserIdentity)!));

                return await generateJwtToken?.CreateJwtTokenAsync(secreatKey, claims?.ToArray(), DateTime.Now.AddDays(1))!;
            }
            catch
            {
                throw;
            }
        }
    }
}