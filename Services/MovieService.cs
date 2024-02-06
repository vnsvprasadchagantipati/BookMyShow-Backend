using BookMyShowNewWebAPI.Database;
using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly MyContext _context;

        public MovieService(MyContext context)
        {
            _context = context;
        }

        public void CreateMovie(Movie movie)
        {
            try
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteMovie(long MovID)
        {
            Movie movie = _context.Movies.Find(MovID);
            if (movie != null)
            {
                try
                {
                    _context.Movies.Remove(movie);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void EditMovie(Movie movie)
        {
            try
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Movie> GetAllMovies()
        {
            try
            {
                return _context.Movies.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public Movie GetMovieByID(long movID)
        {
            try
            {
                Movie movie = _context.Movies.Find(movID);
                return movie;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* public List<MovieDetailsDTO> GetMovieDetailsByCityAndMultiplex(long cityId, long multiplexId)
         {
             try
             {
                 var movieDetails = _context.Movies
                     .Join(_context.Shows,
                         movie => movie.MovieID,
                         show => show.MovieID,
                         (movie, show) => new { Movie = movie, Show = show })
                     .Where(joined => joined.Show.MulID == multiplexId)
                     .Select(joined => new MovieDetailsDTO
                     {
                         MovName = joined.Movie.MovName,
                         ReleaseDate = joined.Movie.ReleaseDate,
                         AvailableSeats = joined.Show.AvailableSeats,
                         ShowDateTime = joined.Show.ShowDateTime,
                         Amount = 0 // Set a default value instead of calculated amount
                     })
                     .ToList();

                 return movieDetails;
             }
             catch (Exception)
             {
                 throw;
             }
         }*/
        public List<Movie> GetMoviesByMulID(long mulID)
        {
            try
            {
                // Fetch movies by MulID
                List<Movie> movies = _context.Movies.Where(m => m.mulID == mulID).ToList();
                return movies;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
