using System;
using System.Collections;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MovieTicketApi.Models;

namespace MovieTicketApi.Repositories
{
	public class MovieRepository : IMovieRepository
	{
        private readonly IMongoCollection<MovieModel> movieCollection;

        public MovieRepository(IOptions<MongoDBSettings> mongoDBSettings)
        {
            //          MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            //          IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            //          movieCollection = database.GetCollection<MovieModel>(mongoDBSettings.Value.MovieCollection);

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://felix:Fc0xr78vUeqUnvcr@cluster0.cfqmsap.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("movietickets");
            movieCollection = database.GetCollection<MovieModel>("movies");
        }

        public void Add(MovieModel movie)
        {
            try
            {
                //MovieModel movie = new MovieModel();

                movie.ID = ObjectId.GenerateNewId().ToString();
                //movie.Name = movieDto.Name;
                //movie.Description = movieDto.Description;
                //movie.Duration = movieDto.Duration;
                //movie.Genre = movieDto.Genre;
                //movie.AvailaibleTickets = movieDto.AvailaibleTickets;
                //movie.Rating = movieDto.Rating;



                //using (var ms = new MemoryStream())
                //{
                //    var image = movieDto.Image;

                //    image.CopyTo(ms);
                //    var fileBytes = ms.ToArray();

                //    movie.Image = fileBytes;
                //}

                movieCollection.InsertOne(movie);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Delete(string id)
        {
            //throw new NotImplementedException();
            movieCollection.DeleteOne(m => m.ID == id);
        }

        public List<MovieModel> GetAll()
        {
            //throw new NotImplementedException();
            return movieCollection.Find(_ => true).ToList();
        }

        public MovieModel GetById(string id)
        {
            //throw new NotImplementedException();
            return movieCollection.Find(m => m.ID == id).FirstOrDefault();
        }

        public MovieModel GetByName(string name)
        {
            //throw new NotImplementedException();
            return movieCollection.Find(m => m.Name == name).FirstOrDefault();
        }

        [Obsolete]
        public void Update(MovieModel movie, string id)
        {
            //throw new NotImplementedException();
            movieCollection.ReplaceOne<MovieModel>(x => x.ID == id, movie, new UpdateOptions
            {
                IsUpsert = true
            });
        }

        private byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
            }

            return bytes;
        }
    }
}

