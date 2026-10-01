namespace MovieReservationAPI.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public string RowNumber { get; set; } 
        public int SeatNumber { get; set; }    

        public int ScreenId { get; set; }
        public Screen Screen { get; set; }
    }
}
