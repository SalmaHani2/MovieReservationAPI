using System;

namespace MovieReservationAPI.DTOs.Responses
{
    public class ShowtimeDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }
        public int MovieId { get; set; }
        public int ScreenId { get; set; }
    }
}
