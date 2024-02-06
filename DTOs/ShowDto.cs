namespace BookMyShowNewWebAPI.DTOs
{
    public class ShowDto
    {
        public long ShowID { get; set; }
        public long MulID { get; set; }
        public long MovieID { get; set; }
        public DateTime ShowDateTime { get; set; }
        public string ShowTiming { get; set; }
        public int AvailableSeats { get; set; }


    }
}
