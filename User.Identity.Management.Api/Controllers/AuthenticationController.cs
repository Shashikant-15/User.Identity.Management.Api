using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Identity.Management.Api.Models;
using User.Identity.Management.Api.Models.Authentication.SignUp;

namespace User.Identity.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterUser registerUser, string role)
        {
            // check uer exist
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExist != null) 
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response {Status= "Error",Message= "User already exists!" });

            }

            // ass user to db
            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.UserName
            };
            var result= await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                return StatusCode(StatusCodes.Status201Created,
                    new Response { Status= "Sucess", Message= "User Created Successfully"});
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User Failed to Create" });
            }
            // assign a role in next.....

        }
    }
}
