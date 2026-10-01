using System;
using System.Collections.Generic;

namespace MovieReservationAPI.DTOs.Responses
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationInMinutes { get; set; }
        public string PosterUrl { get; set; }
    }
}
