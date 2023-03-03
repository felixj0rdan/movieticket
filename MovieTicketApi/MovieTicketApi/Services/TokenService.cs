using System;
using Microsoft.IdentityModel.Tokens;
using MovieTicketApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MovieTicketApi.Repositories;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;

namespace MovieTicketApi.Services
{
	public class TokenService :  ITokenService
	{
        private IConfiguration config;
        IUserRepository userRepository;

        public TokenService(IConfiguration _config, IUserRepository _userRepository )
        {
            config = _config;
            userRepository = _userRepository;
        }

        public string Generate(UserModel user)
        {
            //throw new NotImplementedException();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username ),
                new Claim(ClaimTypes.Authentication, user.ID )
            };

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserModel Authenticate(LoginModel loginData)
        {
            //throw new NotImplementedException();

            //var currentUser = UserConstants.users.FirstOrDefault(u => u.Username == userLogin.Username && u.Password == userLogin.Password);
            //var currentUser = userRepository.GetAll().FirstOrDefault(u => u.Username == userLogin.Username && u.Password == userLogin.Password);

            UserModel admin = userRepository.GetByUsername(loginData.Username);

            if (admin == null || admin.Password != loginData.Password)
            {
                return null;
            }
            return admin;
        }

        
    }
}

