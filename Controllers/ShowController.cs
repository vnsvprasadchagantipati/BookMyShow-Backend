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
    public class ShowController : ControllerBase
    {
     
            private readonly IShowService showService;
            private readonly IMapper _mapper;
            private readonly IConfiguration configuration;
            private readonly ILog _logger;

            public ShowController(IShowService showService, IMapper mapper, IConfiguration configuration,ILog logger)
            {
                this.showService = showService;
                _mapper = mapper;
                this.configuration = configuration;
                _logger = logger;

            }
            //end points
            //GET /GetAllShows
            [HttpGet, Route("GetAllShows")]
            [Authorize(Roles = "Admin,Customer")]
            public IActionResult GetAll()
            {
                try
                {
                    List<Show> Shows = showService.GetAllShows();
                    List<ShowDto> showsDto = _mapper.Map<List<ShowDto>>(Shows);
                    return StatusCode(200, showsDto);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            //POST /AddShow
            [Authorize(Roles = "Admin,Customer")]
            [HttpPost, Route("AddShow")]
         public IActionResult Add([FromBody] ShowDto showDto)
         {
             try
             {
                 Show show = _mapper.Map<Show>(showDto);
                 showService.CreateShow(show);
                 return StatusCode(200, showDto);

             }
             catch (Exception ex)
             {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
             }
         }
        


        //PUT /EditShow
        [HttpPut, Route("EditShow")]
            [Authorize(Roles = "Admin")]
            public IActionResult EditShow(ShowDto showDto)
            {
                try
                {
                    Show show = _mapper.Map<Show>(showDto);
                    showService.EditShow(show);
                    return StatusCode(200, show);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            //Delete /DeleteShow
            [HttpDelete, Route("DeleteShow/{showID}")]
            [Authorize(Roles = "Admin")]
            public IActionResult DeleteShow(long showID)
            {
                try
                {
                    showService.DeleteShow(showID);
                    return StatusCode(200, new JsonResult($"Show with Id {showID} is Deleted"));
                }
                catch (Exception ex)
                {
                   _logger.Error(ex.Message);
                   return StatusCode(500, ex.Message);
                }
            }
        [HttpGet, Route("GetShowByID/{showID}")]
        [Authorize(Roles ="Admin,Customer")]
        public IActionResult GetShowByID(long showID)
        {
            try
            {
                Show show = showService.GetShowByID(showID);
                if (show != null)
                {
                    ShowDto showDto = _mapper.Map<ShowDto>(show);
                    return StatusCode(200, showDto);
                }
                else
                {
                    return StatusCode(404, $"Show with ID {showID} not found");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        // ShowController

        [HttpGet, Route("GetShowsByMultiplex/{multiplexId}")]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult GetShowsByMultiplex(long multiplexId)
        {
            try
            {
                List<Show> shows = showService.GetShowsByMultiplex(multiplexId);
                if (shows != null && shows.Any())
                {
                    List<ShowDto> showsDto = _mapper.Map<List<ShowDto>>(shows);
                    return StatusCode(200, showsDto);
                }
                else
                {
                    return StatusCode(404, "No shows found for the selected multiplex");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetShowsByMovieID/{movieID}")]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult GetShowsByMovieID(long movieID)
        {
            try
            {
                List<Show> shows = showService.GetShowsByMovieID(movieID);
                if (shows != null && shows.Any())
                {
                    List<ShowDto> showsDto = _mapper.Map<List<ShowDto>>(shows);
                    return StatusCode(200, showsDto);
                }
                else
                {
                    return StatusCode(404, "No shows found for the selected movie");
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






