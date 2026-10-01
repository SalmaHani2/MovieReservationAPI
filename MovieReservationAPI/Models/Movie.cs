namespace MovieReservationAPI.Models
{
       public class Movie
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int DurationInMinutes { get; set; }
            public string PosterUrl { get; set; }

        public ICollection<Showtime> ShowTimes { get; set; }
        }
    
}
