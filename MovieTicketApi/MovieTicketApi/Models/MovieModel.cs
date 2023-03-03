using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieTicketApi.Models
{
	public class MovieModel 
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

		[BsonElement("name")]
		public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

		[BsonElement("duration")]
        public int Duration { get; set; }

		[BsonElement("genre")]
        public string Genre { get; set; }

		[BsonElement("rating")]
        public double Rating { get; set; }

		[BsonElement("imgUrl")]
        public string ImageURL { get; set; }

		[BsonElement("availableTickets")]
        public int AvailaibleTickets { get; set; }

        //[BsonElement("image")]
        //public byte[] Image { get; set; }

        //[BsonElement("image")]
        //public IFormFile Image { get; set; }




        //movie name, duration, genre, rating, image URL and available ticket
        public MovieModel()
		{
		}
	}
}

