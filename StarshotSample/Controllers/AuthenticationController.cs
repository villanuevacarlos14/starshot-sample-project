using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Starshot.DTO;
using Starshot.Service;
using Starshot.Web.Models;

namespace Starshot.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AuthenticationController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthModel request)
        {
            var account = await _userService.GetUser(request.UserName, request.Password);

            if (account == null)
                return Unauthorized(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = this.BuildUserToken(account);

            var token = tokenHandler.CreateToken(tokenDescriptor);


            //add generic response later.
            return Ok(new
            {
                Token = tokenHandler.WriteToken(token),
                UserName = account.UserName
            });
        }


        private SecurityTokenDescriptor BuildUserToken(UserDTO user)
        {
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(StarshotClaims.UserId, user.Id.ToString()),
                    new Claim(StarshotClaims.Username, user.UserName)
                }),
                Expires = DateTime.Now.AddDays(7),
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this._configuration["Authentication:Jwt:Key"])), SecurityAlgorithms.HmacSha256Signature)
            };
        }

    }
}
