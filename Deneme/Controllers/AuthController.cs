using App.Core;
using App.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration _configuration;
        private ITokenService _tokenService;
        private readonly NewsDBContext _context;
        private readonly ILogger<AuthController> _logger;

        
        public AuthController(IConfiguration config, NewsDBContext context, ITokenService tokenService, ILogger<AuthController> logger)
        {
            _configuration = config;
            _tokenService = tokenService;
            _context = context;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginToken model)
        {

            Writer getUser = await _tokenService.AuthenticateUser(model);


            Writer writer = getUser;


            if (writer != null)
            {


                if (writer.WriterStatus == 2)
                {
                    return StatusCode(StatusCodes.Status423Locked);
                }

                var claimsIdentity = new[]
                {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Issuer"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("WriterId", writer.WriterId.ToString()),

                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claimsIdentity, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                return Ok(new 
                {
                    id = writer.WriterId.ToString(),
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                });
            }

                _logger.LogError("Unauthorized");
                return Unauthorized();
   
            //if (model == null)
            //{
            //    return BadRequest("Invalid client request");
            //}
            //if (model.UserName == "test" && model.Password == "1233")
            //{
            //    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@2410"));
            //    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            //    var tokenOptions = new JwtSecurityToken(
            //        issuer: "CodeMaze",
            //        audience: "https://localhost:5001",
            //        claims: new List<Claim>(),
            //        expires: DateTime.Now.AddMinutes(5),
            //        signingCredentials: signinCredentials
            //    );
            //    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            //    return Ok(new { Token = tokenString });
            //}
            //else
            //{
            //    return Unauthorized();
            //}
        }
    }
}
