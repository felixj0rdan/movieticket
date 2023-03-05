using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MovieTicketApi.Models;
using MovieTicketApi.Repositories;

namespace MovieTicketApi.Controllers
{
	[ApiController]
	[Route("movie")]
    [EnableCors("Policy")]
	public class MovieController : ControllerBase
	{
		IMovieRepository movieRepository;
		public MovieController(IMovieRepository _movieRepository)
		{
			movieRepository = _movieRepository;
		}

		[HttpPost("add")]
		[Authorize]
        //public ActionResult<MovieModel> AddMovie([FromForm]IFormFile image)

        public ActionResult<MovieModel> AddMovie([FromBody] MovieModel movie)

        {
            //UserModel currentUser = GetCurrentUser();

            //MovieModel movie = new MovieModel();
            //movie.Name = "";


            if (movieRepository.GetByName(movie.Name) != null)
			{
				return BadRequest(new { message = "movie already exists" });
			}
			movieRepository.Add(movie);
			return Ok(movie);
		}

        [HttpGet("get-all")]
        public ActionResult<List<MovieModel>> GetAllMovies()
        {
            return movieRepository.GetAll();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteMovie(string id)
        {
            var movie = movieRepository.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            movieRepository.Delete(id);

            return Ok();
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



//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.
//    eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2N.
//    sYWltcy9uYW1laWRlbnRpZmllciI6ImZl...
