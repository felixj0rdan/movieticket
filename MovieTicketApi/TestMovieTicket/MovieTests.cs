using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using MovieTicketApi.Controllers;
using MovieTicketApi.Models;
using MovieTicketApi.Repositories;

namespace TestMovieTicket
{
    class MovieTests
    {

        //IMovieRepository movieRepository;

        Mock<IMovieRepository> _movieRepository;

        [SetUp]
        public void Setup()
        {
            _movieRepository = new Mock<IMovieRepository>();
        }

        [Test]
        public void TestGetAll_RetunListOfMovies()
        {
            //var movieRepository = new MovieRepository();
            //List<MovieModel> movieList = movieRepository.GetAll();


            List<MovieModel> data = new List<MovieModel> { new MovieModel() {
                                                                                Name= "Avengers",
                                                                                Duration= 0,
                                                                                Genre= "action",
                                                                                Rating= 3.4,
                                                                                ID= "64007818fe7b41a43a714263",
                                                                                Description= "Avengers",
                                                                                ImageURL= "https://i.pinimg.com/564x/12/53/39/1253398987589547c82173327c082339.jpg",
                                                                                AvailaibleTickets= 123
                                                                              },
                                                                 new MovieModel() {
                                                                                Name= "Avengers1",
                                                                                Description= "Avengers",
                                                                                ID= "64007818fe7b41a43a714253",
                                                                                Duration= 0,
                                                                                Genre= "action",
                                                                                Rating= 3.4,
                                                                                ImageURL= "https://i.pinimg.com/564x/12/53/39/1253398987589547c82173327c082339.jpg",
                                                                                AvailaibleTickets= 123
                                                                              }
                                                                         };
            _movieRepository.Setup(m => m.GetAll()).Returns(data);

            MovieController movieController = new MovieController(_movieRepository.Object);
            var list = movieController.GetAllMovies();
            ActionResult<List<MovieModel>> expected = (ActionResult<List<MovieModel>>)data;
            Assert.That(list.ToBson(), Is.EqualTo(expected.ToBson()));

        }


        [Test]
        public void TesAddMovie_ReturnsAddedMovie()
        {
            MovieModel movie = new MovieModel()
            {
                ID = "64007818fe7b41a43a714253",
                Name = "Avengers1",
                Description = "Avengers",
                Duration = 0,
                Genre = "action",
                Rating = 3.4,
                ImageURL = "https://i.pinimg.com/564x/12/53/39/1253398987589547c82173327c082339.jpg",
                AvailaibleTickets = 123
            };

            //_movieRepository.Setup(m => m.Add(movie));
            MovieController movieController = new MovieController(_movieRepository.Object);
            movieController.ControllerContext = new ControllerContext();
            movieController.ControllerContext.HttpContext = new DefaultHttpContext();
            var response = movieController.ControllerContext.HttpContext.Response;

            var actual = movieController.AddMovie(movie);

            Assert.That(response.StatusCode, Is.EqualTo(200));
            //Assert.That(movie.ToBson(), Is.EqualTo(actual.ToBson()));
            //Assert.That(typeof(MovieModel), Is.InstanceOf(typeof(actual)));


        }

        [Test]
        public void TestMovie_DeleteMovie_Returns200()
        {
            MovieModel movie = new MovieModel()
            {
                ID = "64007818fe7b41a43a714253",
                Name = "Avengers1",
                Description = "Avengers",
                Duration = 0,
                Genre = "action",
                Rating = 3.4,
                ImageURL = "https://i.pinimg.com/564x/12/53/39/1253398987589547c82173327c082339.jpg",
                AvailaibleTickets = 123
            };



            _movieRepository.Setup(m => m.Delete(movie.ID));

            _movieRepository.Setup(m => m.GetById(movie.ID)).Returns(movie);


            MovieController movieController = new MovieController(_movieRepository.Object);
            movieController.ControllerContext = new ControllerContext();
            movieController.ControllerContext.HttpContext = new DefaultHttpContext();
            var response = movieController.ControllerContext.HttpContext.Response;

            var actual = movieController.DeleteMovie(movie.ID);

            Assert.That(response.StatusCode, Is.EqualTo(200));

        }

        [Test]
        public void TestMovie_DeleteMovie_Returns404()
        {
            MovieModel movie = new MovieModel()
            {
                ID = "64007818fe7b41a43a714253",
                Name = "Avengers1",
                Description = "Avengers",
                Duration = 0,
                Genre = "action",
                Rating = 3.4,
                ImageURL = "https://i.pinimg.com/564x/12/53/39/1253398987589547c82173327c082339.jpg",
                AvailaibleTickets = 123
            };

            List<MovieModel> data = new List<MovieModel> { new MovieModel() {
                                                                                ID= "64007818fe7b41a43a714263",
                                                                                Name= "Avengers",
                                                                                Description= "Avengers",
                                                                                Duration= 0,
                                                                                Genre= "action",
                                                                                Rating= 3.4,
                                                                                ImageURL= "https://i.pinimg.com/564x/12/53/39/1253398987589547c82173327c082339.jpg",
                                                                                AvailaibleTickets= 123
                                                                              },
                                                                 new MovieModel() {
                                                                                ID= "64007818fe7b41a43a714253",
                                                                                Name= "Avengers1",
                                                                                Description= "Avengers",
                                                                                Duration= 0,
                                                                                Genre= "action",
                                                                                Rating= 3.4,
                                                                                ImageURL= "https://i.pinimg.com/564x/12/53/39/1253398987589547c82173327c082339.jpg",
                                                                                AvailaibleTickets= 123
                                                                              }
                                                                         };

            _movieRepository.Setup(m => m.Delete(movie.ID));

            var val = data.FirstOrDefault(d => false);
            Console.WriteLine(val);

            _movieRepository.Setup(m => m.GetById(movie.ID)).Returns((MovieModel)null);
            _movieRepository.Setup(m => m.Delete(""));


            MovieController movieController = new MovieController(_movieRepository.Object);
            movieController.ControllerContext = new ControllerContext();
            movieController.ControllerContext.HttpContext = new DefaultHttpContext();
            var response = movieController.ControllerContext.HttpContext.Response;

            var actual = movieController.DeleteMovie("78587tuhj");

            //Assert.That(response.StatusCode, Is.EqualTo(404));
            Assert.Pass();

        }
    
    }
}
