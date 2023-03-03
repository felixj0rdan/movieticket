using System;
using MovieTicketApi.Models;

namespace MovieTicketApi.Repositories
{
	public interface IMovieRepository
	{
        public List<MovieModel> GetAll();
        public MovieModel GetById(string id);
        public void Add(MovieModel movie);
        public void Delete(String id);
        public void Update(MovieModel movie, string id);
        public MovieModel GetByName(string name);

    }
}

