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
    public class BookingController : ControllerBase
    {
       
        
            private readonly IBookingService bookingService;
            private readonly IMapper _mapper;
            private readonly IConfiguration configuration;
            private readonly ILog _logger;
    

        public BookingController(IBookingService bookingService, IMapper mapper, ILog logger)
        {
            this.bookingService = bookingService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet, Route("GetAllBookings")]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult GetAll(string userID)
        {
            try
            {
                List<Booking> Bookings = bookingService.GetAllBookings(userID);
                List<BookingDto> bookingDto = _mapper.Map<List<BookingDto>>(Bookings);
                return StatusCode(200, bookingDto);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


       [HttpPost, Route("AddBooking")]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Add([FromBody] BookingDto bookingDto)
        {
            try
            {
                Booking booking = _mapper.Map<Booking>(bookingDto);
                bookingService.CreateBooking(booking);
                return StatusCode(200, bookingDto);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, $"An error occurred while adding a booking: {ex.Message}. Inner exception: {ex.InnerException?.Message}");
            }
        }

        [HttpPut, Route("EditBooking")]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult EditBooking(BookingDto bookingDto)
        {
            try
            {
                Booking booking = _mapper.Map<Booking>(bookingDto);
                bookingService.EditBooking(booking);
                return StatusCode(200, bookingDto);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete, Route("DeleteBooking/{bookingID}")]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult DeleteBooking(long bookingID)
        {
            try
            {
                bookingService.DeleteBooking(bookingID);
                return StatusCode(200, new JsonResult($"Booking with Id {bookingID} is Deleted"));
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetBookingByID/{bookingID}")]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult GetBookingByID(long bookingID)
        {
            try
            {
                Booking booking = bookingService.GetBookingByID(bookingID);
                if (booking == null)
                {
                    return NotFound($"Booking with ID {bookingID} not found");
                }

                BookingDto bookingDto = _mapper.Map<BookingDto>(booking);
                return StatusCode(200, bookingDto);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /*  [HttpGet, Route("GetAllBookingsWithMovName")]
          [Authorize(Roles = "Admin,Customer")]
          public IActionResult GetAllBookingsWithMovName()
          {
              try
              {
                  List<BookingDto> bookingDto = bookingService.GetAllBookingsWithMovName();
                  return StatusCode(200, bookingDto);
              }
              catch (Exception ex)
              {
                  _logger.Error(ex.Message);
                  return StatusCode(500, ex.Message);
              }
          }*/
        [HttpGet, Route("GetBookingByShowID/{showID}")]
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult GetBookingByShowID(long showID)
        {
            try
            {
                List<Booking> bookings = bookingService.GetBookingByShowID(showID);
                List<BookingDto> bookingDto = _mapper.Map<List<BookingDto>>(bookings);
                return StatusCode(200, bookingDto);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        


    }


}







