namespace BookMyShowNewWebAPI.DTOs
{
    public class MovieDto
    {
        public long MovieID { get; set; }
        public string? MovName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public long mulID { get; set; }
        public string ImageUrl { get; set; }
    }
}
