using System.ComponentModel.DataAnnotations;

namespace MovieReservationAPI.DTOs.Requests
{
    public class CinemaRequestDto
    {
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
