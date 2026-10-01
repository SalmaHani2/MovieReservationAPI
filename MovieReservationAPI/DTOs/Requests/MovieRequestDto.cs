using System.ComponentModel.DataAnnotations;

namespace MovieReservationAPI.DTOs.Requests
{
    public class MovieRequestDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationInMinutes { get; set; }
        public string PosterUrl { get; set; }
    }
}
