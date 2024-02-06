using BookMyShowNewWebAPI.DTOs;

namespace BookMyShowNewWebAPI.Services
{
    public interface IMovieDetailsService
    {
        List<MovieDetailsDTO> GetMovieDetailsByCityAndMultiplex(long cityID, long mulID);
       
    }
}
