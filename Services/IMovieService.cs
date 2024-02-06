using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Entity;

namespace BookMyShowNewWebAPI.Services
{
    public interface IMovieService
    {
        void CreateMovie(Movie movie);
        List<Movie> GetAllMovies();
        void EditMovie(Movie movie);
        void DeleteMovie(long MovID);
        Movie GetMovieByID(long movID);
        // List<MovieDetailsDTO> GetMovieDetailsByCityAndMultiplex(long cityId, long multiplexId);
        List<Movie> GetMoviesByMulID(long mulID);

    }
}
