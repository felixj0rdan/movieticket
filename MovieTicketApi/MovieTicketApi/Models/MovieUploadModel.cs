using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MovieTicketApi.Models
{
	public class MovieUploadModel
	{


        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public int AvailaibleTickets { get; set; }
        public IFormFile Image { get; set; }

        public MovieUploadModel()
		{
		}
	}
}

