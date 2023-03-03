using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MovieTicketApi.Models;
using MovieTicketApi.Repositories;
using MovieTicketApi.Services;

namespace MovieTicketApi.Controllers
{
	[ApiController]
	[Route("admin")]
    [EnableCors("Policy")]

    public class UserController : ControllerBase
	{
		IUserRepository userRepository;
		ITokenService tokenService; 
		public UserController(IUserRepository _userRepository, ITokenService _tokenService)
		{
			userRepository = _userRepository;
			tokenService = _tokenService;
		}

		[HttpPost("create")]
		public ActionResult AddAdmin([FromBody]UserModel admin)
		{
			try
			{
                userRepository.Add(admin);
				return Ok(new  { message = "success", status = 200 });
            }
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				return StatusCode(500);
			}
        }

		[HttpGet("check")]
		[Authorize]
		public ActionResult Check()
		{
            ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;

            UserModel currentUser = GetCurrentUser();

            return Ok("success");
		}

        [HttpPost("login")]
        public ActionResult AdminLogin([FromBody] LoginModel loginData)
        {
            try
            {
				//userRepository.Add(admin);
				//UserModel admin = userRepository.GetByUsername(loginData.Username);

				//if(admin == null || !admin.IsAdmin)
				//{
				//	return BadRequest("Invalid Credentials");
				//}

				//if(admin.Password != loginData.Password)
				//{
				//	return BadRequest("Invalid Credetials");
				//            }

				UserModel admin = tokenService.Authenticate(loginData);

				if(admin == null)
				{
					return BadRequest("Invalid credentials");
				}

				var token = tokenService.Generate(admin);

                return Ok(new { message = "success", status = 200, token = token });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value,
                    ID = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Authentication)?.Value,
                    //Username = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value,

                };
            }

            return null;
        }
    }
}

