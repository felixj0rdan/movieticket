using Moq;
using MovieTicketApi.Controllers;
using MovieTicketApi.Models;
using MovieTicketApi.Repositories;
using MovieTicketApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMovieTicket
{
    class UserTests
    {
        Mock<ITokenService> tokenService;
        Mock<IUserRepository> userRepository;

        [SetUp]
        public void Setup()
        {
            tokenService = new Mock<ITokenService>();
            userRepository = new Mock<IUserRepository>();
        }

        [Test]
        public void TestUser_Login_ReturnsToken()
        {
            UserModel user = new UserModel()
            {
                ID = ""
            } ;

            UserController userController = new UserController(userRepository.Object, tokenService.Object);
            tokenService.Setup(t => t.GenerateToken()).Returns("")
            Assert.Pass();
        }
    }
}
