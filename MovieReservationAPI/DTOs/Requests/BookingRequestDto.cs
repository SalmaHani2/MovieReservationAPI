using System;
using System.ComponentModel.DataAnnotations;

namespace MovieReservationAPI.DTOs.Requests
{
    public class BookingRequestDto
    {
        [Required]
        public DateTime BookingTime { get; set; }
        [Required]
        public int ShowtimeId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
