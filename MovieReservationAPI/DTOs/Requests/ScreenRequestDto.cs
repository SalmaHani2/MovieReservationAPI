using System.ComponentModel.DataAnnotations;

namespace MovieReservationAPI.DTOs.Requests
{
    public class ScreenRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int CinemaId { get; set; }
    }
}
