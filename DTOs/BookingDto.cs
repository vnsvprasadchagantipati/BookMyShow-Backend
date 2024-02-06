namespace BookMyShowNewWebAPI.DTOs
{
    public class BookingDto
    {
        public long BookingID { get; set; }
        public decimal Amount { get; set; }
        public DateTime BookingDateTime { get; set; }
        public long ShowID { get; set; }
        public string? UserID { get; set; }
       // public string? MovName { get; set; }


    }
}
