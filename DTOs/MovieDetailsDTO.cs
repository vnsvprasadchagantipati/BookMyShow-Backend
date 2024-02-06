namespace BookMyShowNewWebAPI.DTOs
{
    public class MovieDetailsDTO
    {
        public string MovName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime ShowDateTime { get; set; }
        public decimal Amount { get; set; }
    }
}
