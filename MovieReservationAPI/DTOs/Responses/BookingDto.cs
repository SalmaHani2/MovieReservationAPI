using System;

namespace MovieReservationAPI.DTOs.Responses
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime BookingTime { get; set; }
        public int ShowtimeId { get; set; }
        public int UserId { get; set; }
    }
}
