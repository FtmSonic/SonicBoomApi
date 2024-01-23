using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SonicBoomDto;
using Nethereum.Signer;

namespace SonicBoomApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private IConfiguration _config;
        private readonly IMemoryCache _cache;
        private readonly ILogger<AccountController> _logger;
        private const string message = "Welcome to Sonic Boom, sign this message to authenticate {0}";
        private const string cacheConnectionKey = "GetConnection_{0}";

        public AccountController(ILogger<AccountController> logger, IConfiguration config, IMemoryCache cache)
        {
            _logger = logger;
            _config = config;
            _cache = cache;
        }



        [AllowAnonymous]
        [HttpGet("RequestConnection")]
        public MessageDto RequestConnection(string account)
        {
            var connectDto = RequestEntry(account);

            return new MessageDto { Account = connectDto.Account, Message = string.Format(message, connectDto.Nonce) };
        }

        [AllowAnonymous]
        [HttpPost("CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] LoginDto login)
        {
            var user = await Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user.Address);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }

        private ConnectionDto CheckEntry(string account)
        {
            return GetCacheConnection(account);
        }

        private ConnectionDto RequestEntry(string account)
        {
            return GetCacheConnection(account);
        }

        private ConnectionDto GetCacheConnection(string account)
        {
            var key = string.Format(cacheConnectionKey, account);
            return _cache.GetOrCreate(key, (entry) =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3);
                var test = new ConnectionDto();
                return new ConnectionDto { Account = account, DateTime = DateTime.Now, Nonce = Guid.NewGuid() };
            });
        }

        private void ResetCache(string account)
        {
            var key = string.Format(cacheConnectionKey, account);
            _cache.Remove(cacheConnectionKey);
        }

        private string BuildToken(string account)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Name, account),
            new Claim(JwtRegisteredClaimNames.Email, account),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
             new Claim(JwtRegisteredClaimNames.Iss, _config["Jwt:Issuer"]),
              new Claim(JwtRegisteredClaimNames.Aud, _config["Jwt:Audience"])
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
             claims: claims,
             issuer: _config["Jwt:Issuer"],
             audience: _config["Jwt:Audience"],
              expires: DateTime.Now.AddMinutes(90),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<AccountDto> Authenticate(LoginDto login)
        {
            // TODO: This method will authenticate the user recovering his Ethereum address through underlaying offline ecrecover method.

            var connectDto = CheckEntry(login.Signer);
            var messageDto = string.Format(message, connectDto.Nonce);

            // delete from cache to revoke reuse
            ResetCache(login.Signer);

            if (messageDto != login.Message)
            {
                _cache.Remove(cacheConnectionKey);
                throw new Exception("Authentification expired retry");
            }


            var messageToVerify = string.Format(message, connectDto.Nonce);
            AccountDto user = null;

            var signer = new EthereumMessageSigner();
            var account = signer.EncodeUTF8AndEcRecover(messageToVerify, login.Signature);

            if (account.ToLower().Equals(login.Signer.ToLower()))
            {
                // read user from DB or create a new one
                // for now we fake a new user
                user = new AccountDto { Address = account, RecoveryEmail = string.Empty };
            }
            else
            {
                throw new Exception("Impossible to valid your auth, signature incorrect");
            }

            return user;
        }
    }
}
