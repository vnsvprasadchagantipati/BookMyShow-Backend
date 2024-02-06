using BookMyShowNewWebAPI.Database;
using BookMyShowNewWebAPI.DTOs;



namespace BookMyShowNewWebAPI.Services
{
    public class MovieDetailsService : IMovieDetailsService
    {

        private readonly MyContext _context;

        public MovieDetailsService(MyContext context)
        {
            _context = context;
        }

        public List<MovieDetailsDTO> GetMovieDetailsByCityAndMultiplex(long cityID, long mulID)
        {
            var movieDetails = (from show in _context.Shows
                                where show.Multiplex.CityID == cityID && show.MulID == mulID
                                select new MovieDetailsDTO
                                {
                                    MovName = show.Movie.MovName,
                                    ReleaseDate = show.Movie.ReleaseDate,
                                    AvailableSeats = show.AvailableSeats,
                                    ShowDateTime = show.ShowDateTime,
                                    Amount = show.Bookings.Any() ? show.Bookings.Sum(b => b.Amount) : 0
                                }).ToList();


            return movieDetails;
        }
    }





        
                                    
 
    
    }

