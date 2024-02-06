using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowNewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDetailsController : ControllerBase
    {
       
     private readonly IMovieDetailsService _movieDetailsService;

        public MovieDetailsController(IMovieDetailsService movieDetailsService)
        {
            _movieDetailsService = movieDetailsService;
        }

        [HttpGet]
        public IActionResult GetMovieDetailsByCityAndMultiplex(long cityID, long mulID)
        {
            List<MovieDetailsDTO> movieDetails = _movieDetailsService.GetMovieDetailsByCityAndMultiplex(cityID, mulID);

            if (movieDetails == null || movieDetails.Count == 0)
            {
                return NotFound("No movie details found for the specified criteria.");
            }

            return Ok(movieDetails);
        }
    }

}
