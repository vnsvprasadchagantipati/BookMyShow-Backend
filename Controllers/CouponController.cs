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
    public class CouponController : ControllerBase
    {
       
        
            private readonly ICouponService couponService;
            private readonly IMapper _mapper;
            private readonly IConfiguration configuration;
            private readonly ILog _logger;


            public CouponController(ICouponService couponService, IMapper mapper, IConfiguration configuration,ILog logger)
            {
                this.couponService = couponService;
                _mapper = mapper;
                this.configuration = configuration;
                _logger=logger;
            }
            //end points
            //GET /GetAllCoupon
            [HttpGet, Route("GetAllCoupons")]
            [Authorize(Roles = "Admin,Customer")]
            public IActionResult GetAll()
            {
                try
                {
                    List<Coupon> Coupons = couponService.GetAllCoupons();
                    List<CouponDto> couponsDto = _mapper.Map<List<CouponDto>>(Coupons);
                    return StatusCode(200, couponsDto);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            //POST /AddCoupon
            [Authorize(Roles = "Admin")]
            [HttpPost, Route("AddCoupon")]
            public IActionResult Add([FromBody] CouponDto couponDto)
            {
                try
                {
                    Coupon coupon = _mapper.Map<Coupon>(couponDto);
                    couponService.CreateCoupon(coupon);
                    return StatusCode(200, couponDto);

                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }

            //PUT /EditCoupon
            [HttpPut, Route("EditCoupon")]
            [Authorize(Roles = "Admin")]
            public IActionResult EditCoupon(CouponDto couponDto)
            {
                try
                {
                    Coupon coupon = _mapper.Map<Coupon>(couponDto);
                    couponService.EditCoupon(coupon);
                    return StatusCode(200, coupon);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            //Delete /DeleteCoupon
            [HttpDelete, Route("DeleteCoupon/{couponID}")]
            [Authorize(Roles = "Admin")]
            public IActionResult DeleteCoupon(long couponID)
            {
                try
                {
                    couponService.DeleteCoupon(couponID);
                    return StatusCode(200, new JsonResult($"Coupon with Id {couponID} is Deleted"));
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }







