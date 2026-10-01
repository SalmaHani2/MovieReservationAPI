using System;
using System.ComponentModel.DataAnnotations;

namespace MovieReservationAPI.DTOs.Requests
{
    public class ShowtimeRequestDto
    {
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int ScreenId { get; set; }
    }
}
