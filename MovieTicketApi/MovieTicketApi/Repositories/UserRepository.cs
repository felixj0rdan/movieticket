using System;
using System.Collections;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MovieTicketApi.Models;

namespace MovieTicketApi.Repositories
{ 
	public class UserRepository : IUserRepository
	{
        private readonly IMongoCollection<UserModel> usersCollection;

        public UserRepository(IOptions<MongoDBSettings> mongoDBSettings)
        {
            //MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            //IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            //usersCollection = database.GetCollection<UserModel>(mongoDBSettings.Value.UserCollection);


            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://felix:Fc0xr78vUeqUnvcr@cluster0.cfqmsap.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("movietickets");
            usersCollection = database.GetCollection<UserModel>("users");


        }

        public void Add(UserModel user)
        {
            try
            {
                user.ID = ObjectId.GenerateNewId().ToString();
                usersCollection.InsertOne(user);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        } 

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(string id)
        {
            //throw new NotImplementedException();

            return usersCollection.Find(u => u.ID == id).FirstOrDefault();
        }

        public UserModel GetByUsername(string name)
        {
            //throw new NotImplementedException();

            return usersCollection.Find(u => u.Username == name).FirstOrDefault();
        }

        public void Update(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}

