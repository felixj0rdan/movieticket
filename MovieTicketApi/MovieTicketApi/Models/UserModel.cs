using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieTicketApi.Models
{
	public class UserModel
	{
        [BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

		[BsonElement("username")]
        public string Username { get; set; }

		[BsonElement("password")]
        public string Password { get; set; }

		[BsonElement("isAdmin")]
        public bool IsAdmin { get; set; }

        public UserModel()
		{
		}
	}
}

