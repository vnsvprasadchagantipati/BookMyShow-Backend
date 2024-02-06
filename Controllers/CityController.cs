using AutoMapper;
using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Entity;
using BookMyShowNewWebAPI.Services;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShowNewWebAPI.Controllers
{
    /*public static class Log4netExtensions
    {
        public static void AddLog4net(this IServiceCollection services)
        {
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            services.AddSingleton(LogManager.GetLogger(typeof(Program)));
        }
    }*/

                [Route("api/[controller]")]
                [ApiController]
                public class CityController : ControllerBase
        {


            private readonly ICityService cityService;
            private readonly IMapper _mapper;
            private readonly IConfiguration configuration;
            private readonly ILog _logger;

            public CityController(ICityService cityService, IMapper mapper, IConfiguration configuration, ILog logger)
            {
                this.cityService = cityService;
                _mapper = mapper;
                this.configuration = configuration;
                _logger = logger;
            }
            //end points
            //GET /GetAllCities
            [HttpGet, Route("GetAllCities")]
            [Authorize(Roles = "Admin,Customer")]
            public IActionResult GetAll()
            {
                try
                {
                    List<City> Cities = cityService.GetAllCities();
                    List<CityDto> citiesDto = _mapper.Map<List<CityDto>>(Cities);
                    return StatusCode(200, citiesDto);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            //POST /AddCity
           [Authorize(Roles = "Admin")]
            [HttpPost, Route("AddCity")]
            public IActionResult Add([FromBody] CityDto cityDto)
            {
                try
                {
                    City city = _mapper.Map<City>(cityDto);
                    cityService.CreateCity(city);
                    _logger.Info(city);
                    return StatusCode(200, city);

                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            //PUT /EditCity
            [HttpPut, Route("EditCity")]
            [Authorize(Roles = "Admin")]
            public IActionResult EditCity(CityDto cityDto)
            {
                try
                {
                    City city = _mapper.Map<City>(cityDto);
                    cityService.EditCity(city);
                    return StatusCode(200, city);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            //Delete /DeleteCity
            [HttpDelete, Route("DeleteCity/{cityID}")]
            [Authorize(Roles = "Admin")]
            public IActionResult DeleteCity(long cityID)
            {
                try
                {
                    cityService.DeleteCity(cityID);
                    return StatusCode(200, new JsonResult($"Product with Id {cityID} is Deleted"));
                }
                catch (Exception)
                {

                    throw;
                }
            }
        //GET /GetCityByID/{cityID}
        [HttpGet, Route("GetCityByID/{cityID}")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetCityByID(long cityID)
        {
            try
            {
                City city = cityService.GetCityByID(cityID);
                if (city == null)
                {
                    return StatusCode(404, "City not found");
                }
                return StatusCode(200, city);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
    }




