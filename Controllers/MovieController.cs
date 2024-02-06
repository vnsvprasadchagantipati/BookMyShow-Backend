using AutoMapper;
using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Entity;
using BookMyShowNewWebAPI.Services;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowNewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        
            private readonly IMovieService movieService;
            private readonly IMapper _mapper;
            private readonly IConfiguration configuration;
            private readonly ILog _logger;

            public MovieController(IMovieService movieService, IMapper mapper, IConfiguration configuration,ILog logger)
            {
                this.movieService = movieService;
                _mapper = mapper;
                this.configuration = configuration;
                _logger = logger;
            }
            //end points
            //GET /GetAllMovies
            [HttpGet, Route("GetAllMovies")]
            [Authorize(Roles = "Admin,Customer")]
            public IActionResult GetAll()
            {
                try
                {
                    List<Movie> Movies = movieService.GetAllMovies();
                    List<MovieDto> moviesDto = _mapper.Map<List<MovieDto>>(Movies);
                    return StatusCode(200, moviesDto);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            //POST /AddMovie
            [Authorize(Roles = "Admin")]
            [HttpPost, Route("AddMovie")]
            public IActionResult Add([FromBody] MovieDto movieDto)
            {
                try
                {
                    Movie movie = _mapper.Map<Movie>(movieDto);
                    movieService.CreateMovie(movie);
                    return StatusCode(200, movieDto);

                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }

            //PUT /EditMovie
            [HttpPut, Route("EditMovie")]
            [Authorize(Roles = "Admin")]
            public IActionResult EditMovie(MovieDto movieDto)
            {
                try
                {
                    Movie movie = _mapper.Map<Movie>(movieDto);
                    movieService.EditMovie(movie);
                    return StatusCode(200, movie);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            //Delete /DeleteMovie
            [HttpDelete, Route("DeleteMovie/{movID}")]
            [Authorize(Roles = "Admin")]
            public IActionResult DeleteMovie(long movID)
            {
                try
                {
                    movieService.DeleteMovie(movID);
                    return StatusCode(200, new JsonResult($"Movie with Id {movID} is Deleted"));
                }
                catch (Exception ex)
                {
                  _logger.Error(ex.Message);
                  return StatusCode(500, ex.Message);
                }
            }
        // GET /GetMovieByID/{movID}
        [HttpGet, Route("GetMovieByID/{movID}")]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult GetMovieByID(long movID)
        {
            try
            {
                Movie movie = movieService.GetMovieByID(movID);
                if (movie != null)
                {
                    MovieDto movieDto = _mapper.Map<MovieDto>(movie);
                    return StatusCode(200, movieDto);
                }
                else
                {
                    return StatusCode(404, "Movie not found");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        /* [HttpGet, Route("GetMovieDetailsByCityAndMultiplex")]
         [Authorize(Roles = "Admin,Customer")]
         public IActionResult GetMovieDetailsByCityAndMultiplex(long cityId, long multiplexId)
         {
             try
             {
                 // Fetch movie details based on city and multiplex IDs using your service/repository logic
                 List<MovieDetailsDTO> movieDetails = movieService.GetMovieDetailsByCityAndMultiplex(cityId, multiplexId);

                 if (movieDetails != null && movieDetails.Count > 0)
                 {
                     return StatusCode(200, movieDetails);
                 }
                 else
                 {
                     return StatusCode(404, "No movie details found for the provided city and multiplex");
                 }
             }
             catch (Exception ex)
             {
                 _logger.Error(ex.Message);
                 return StatusCode(500, ex.Message);
             }
         }*/
        [HttpGet, Route("GetMoviesByMulID/{mulID}")]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult GetMoviesByMulID(long mulID)
        {
            try
            {
                List<Movie> movies = movieService.GetMoviesByMulID(mulID);

                if (movies != null && movies.Count > 0)
                {
                    List<MovieDto> moviesDto = _mapper.Map<List<MovieDto>>(movies);
                    return StatusCode(200, moviesDto);
                }
                else
                {
                    return StatusCode(404, "No movies found for the provided multiplex");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


    }
}






