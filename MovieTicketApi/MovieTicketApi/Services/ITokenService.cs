using System;
using System.Security.Claims;
using System.Security.Principal;
using MovieTicketApi.Models;

namespace MovieTicketApi.Services
{
	public interface ITokenService
	{
        public string Generate(UserModel user);
        public UserModel Authenticate(LoginModel loginData);
        //public UserModel GetCurrentUser();

    }
}

