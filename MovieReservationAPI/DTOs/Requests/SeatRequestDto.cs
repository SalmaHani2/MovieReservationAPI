using System.ComponentModel.DataAnnotations;

namespace MovieReservationAPI.DTOs.Requests
{
    public class SeatRequestDto
    {
        [Required]
        public string RowNumber { get; set; }
        [Required]
        public int SeatNumber { get; set; }
        [Required]
        public int ScreenId { get; set; }
    }
}
