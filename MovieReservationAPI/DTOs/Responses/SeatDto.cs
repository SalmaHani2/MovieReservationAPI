namespace MovieReservationAPI.DTOs.Responses
{
    public class SeatDto
    {
        public int Id { get; set; }
        public string RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public int ScreenId { get; set; }
    }
}
