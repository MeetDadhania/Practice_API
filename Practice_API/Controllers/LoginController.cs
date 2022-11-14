using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model.DBModels;
using Model.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Practice_API.Controllers
{

    /// <summary>
    /// Creating controller for generating JWT token
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DemoApiContext _demoApiContext;
        public LoginController(DemoApiContext demoApiContext,IConfiguration config)
        {
            _demoApiContext = demoApiContext;
            _config = config;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLogin">Enter the UserName and Password</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login([FromBody] UserLogin userLogin)
        {
            //Check userLogin for Authentication
            var user = Authenticate(userLogin);

            if (user != null)
            {
                //Generate Token if user is Aythenticated
                var token = GenerateToken(user);
                return Ok(token);
            }

            //return NotFound if User not Authenticated
            return NotFound("user not found");
        }

        // To generate token
        private string GenerateToken(EmployeeDetail user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        //To authenticate user
        private EmployeeDetail Authenticate(UserLogin userLogin)
        {
            //check if userLogin details match with database entries
            EmployeeDetail currentUser = _demoApiContext.EmployeeDetails.FirstOrDefault(x => x.Name.ToLower() == userLogin.Username.ToLower());
            
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }
}
