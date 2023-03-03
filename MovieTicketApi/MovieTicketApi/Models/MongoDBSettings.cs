using System;
namespace MovieTicketApi.Models
{
	public class MongoDBSettings
	{
        public string? ConnectionURI { get; set; }
        public string? DatabaseName { get; set; }
        public string? UserCollection { get; set; }
        public string? MovieCollection { get; set; }

    }
}

