using BackEndAuthApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace BackEndAuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel user)
        {
            if(user is null)
            {
                return BadRequest("Invalid Client Details");
            }
            if(user.UserName is "rahman" && user.Password is "admin")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ArRahman@786"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, "Operator")
                    }; 

                var tokenOptions = new JwtSecurityToken(
                    issuer : "https://localhost:5001",
                    audience : "https://localhost:5001",
                    claims : claims,
                    expires : DateTime.Now.AddMinutes(15),
                    signingCredentials : signingCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new {Token = tokenString});
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
