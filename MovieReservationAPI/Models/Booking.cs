namespace MovieReservationAPI.Models
{

    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingTime { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }
        public string Status { get; set; } 

        public int UserId { get; set; }
        public User User { get; set; }

        public int ShowtimeId { get; set; }
        public Showtime Showtime { get; set; }
    }

}
