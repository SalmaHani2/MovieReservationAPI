namespace MovieReservationAPI.Models
{
     public class Screen
        {
            public int Id { get; set; }
            public string Name { get; set; } 

            public int CinemaId { get; set; }
            public Cinema Cinema { get; set; }

            public ICollection<Seat> Seats { get; set; }

            public ICollection<Showtime> Showtimes { get; set; }
        }
    }

