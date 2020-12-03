using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using APISkillMatrix.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SharedObjects.Common;
using SharedObjects.StoreProcedures;
using SharedObjects.ValueObjects;
using SharedObjects.ViewModels;

namespace APISkillMatrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Authorize(Roles = "Admin")]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public AccountController(ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [AllowAnonymous]

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateUserViewModel model)
        {
            IdentityUser user = new IdentityUser();
            user.Email = model.Email;
            user.UserName = model.UserName;

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(new ResponseResult(200));
            }
            else
            {
                List<string> notfications = new List<string>();
                foreach (var item in result.Errors)
                {
                    notfications.Add(item.Description);
                }
                return BadRequest(new ResponseResult(400, notfications));
            }
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            
            if (user == null)
            {
                return NotFound(new ResponseResult(404));
            }
            else
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    // start create claims
                    List<Claim> infomationClaim = new List<Claim>()
                    {
                        new Claim("Name", user.UserName),
                        new Claim("Email", user.Email),
                        new Claim("UserId", user.Id)

                    };
                    // create the calimIdentity to store these claims
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(infomationClaim);


                    var roles = (await userManager.GetRolesAsync(user)).ToList();

                    List<Claim> rolesClaim = new List<Claim>();
                    foreach (var item in roles)
                    {
                        rolesClaim.Add(new Claim(ClaimTypes.Role, item));
                    }

                    claimsIdentity.AddClaims(rolesClaim);


                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken
                    (
                        configuration["Jwt:Issuer"],
                        configuration["Jwt:Audience"],
                        claimsIdentity.Claims,
                        expires: DateTime.UtcNow.AddDays(1),
                        signingCredentials: signIn);
                    string strToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(new ResponseResult(200, strToken));
                }
                else
                {
                    return NotFound(new ResponseResult(404));
                }
            }
        }



    }
}
