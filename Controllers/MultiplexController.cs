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
    public class MultiplexController : ControllerBase
    {
            private readonly IMultiplexService multiplexService;
            private readonly IMapper _mapper;
            private readonly IConfiguration configuration;
            private readonly ILog _logger;

            public MultiplexController(IMultiplexService multiplexService, IMapper mapper, IConfiguration configuration,ILog logger)
            {
                this.multiplexService = multiplexService;
                _mapper = mapper;
                this.configuration = configuration;
                _logger = logger;
            }
            //end points
            //GET /GetAllMultiplexes
            [HttpGet, Route("GetAllMultiplexes")]
            [Authorize(Roles = "Admin,Customer")]
            public IActionResult GetAll()
            {
                try
                {
                    List<Multiplex> Multiplexes = multiplexService.GetAllMultiplexes();
                    List<MultiplexDto> multiplexesDto = _mapper.Map<List<MultiplexDto>>(Multiplexes);
                    return StatusCode(200, multiplexesDto);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            //POST /AddMultiplex
            [Authorize(Roles = "Admin")]
            [HttpPost, Route("AddMultiplex")]
            public IActionResult Add([FromBody] MultiplexDto multiplexDto)
            {
             try
             {
                 Multiplex multiplex = _mapper.Map<Multiplex>(multiplexDto);
                 multiplexService.CreateMultiplex(multiplex);
                 return StatusCode(200, multiplexDto);

             }
             catch (Exception ex)
             {
                 _logger.Error(ex.Message);
                 return StatusCode(500, ex.Message);
             }
         }

        //PUT /EditMultiplex
        [HttpPut, Route("EditMultiplex")]
           [Authorize(Roles = "Admin")]
            public IActionResult EditMultiplex(MultiplexDto multiplexDto)
            {
                try
                {
                    Multiplex multiplex = _mapper.Map<Multiplex>(multiplexDto);
                    multiplexService.EditMultiplex(multiplex);
                    return StatusCode(200, multiplex);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            //Delete /DeleteMultiplex
            [HttpDelete, Route("DeleteMultiplex/{mulID}")]
            [Authorize(Roles = "Admin")]
            public IActionResult DeleteMultiplex(long mulID)
            {
                try
                {
                    multiplexService.DeleteMultiplex(mulID);
                    return StatusCode(200, new JsonResult($"Multiplex with Id {mulID} is Deleted"));
                }
                catch (Exception ex)
                {
                  _logger.Error(ex.Message);
                  return StatusCode(500, ex.Message);
                }
            }
        //GET /GetMultiplexByID/{id}
        [HttpGet, Route("GetMultiplexByID/{mulID}")]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult GetMultiplexByID(long mulID)
        {
            try
            {
                Multiplex multiplex = multiplexService.GetMultiplexByID(mulID);
                if (multiplex != null)
                {
                    MultiplexDto multiplexDto = _mapper.Map<MultiplexDto>(multiplex);
                    return StatusCode(200, multiplexDto);
                }
                else
                {
                    return StatusCode(404, $"Multiplex with ID {mulID} not found");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("GetMultiplexByCityID/{cityID}")]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult GetMultiplexByCityID(long cityID)
        {
            try
            {
                List<Multiplex> multiplexes = multiplexService.GetMultiplexByCityID(cityID);
                if (multiplexes.Any())
                {
                    List<MultiplexDto> multiplexesDto = _mapper.Map<List<MultiplexDto>>(multiplexes);
                    return StatusCode(200, multiplexesDto);
                }
                else
                {
                    return StatusCode(404, $"No multiplexes found for City ID {cityID}");
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





