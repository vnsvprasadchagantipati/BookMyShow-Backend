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
    public class WalletController : ControllerBase
    {
   
            private readonly IWalletService walletService;
            private readonly IMapper _mapper;
            private readonly IConfiguration configuration;
            private readonly ILog _logger;

            public WalletController(IWalletService walletService, IMapper mapper, IConfiguration configuration,ILog logger)
            {
                this.walletService = walletService;
                _mapper = mapper;
                this.configuration = configuration;
                _logger = logger;
            }
            //end points
            //GET /GetAllWallet
            [HttpGet, Route("GetAllWallets")]
            [Authorize(Roles = "Customer")]
            public IActionResult GetAll()
            {
                try
                {
                    List<Wallet> Wallets = walletService.GetAllWallets();
                    List<WalletDto> walletDto = _mapper.Map<List<WalletDto>>(Wallets);
                    return StatusCode(200, walletDto);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            //POST /AddWallet
            [Authorize(Roles = "Admin,Customer")]
            [HttpPost, Route("AddWallet")]
            public IActionResult Add([FromBody] WalletDto walletDto)
            {
                try
                {
                    Wallet wallet = _mapper.Map<Wallet>(walletDto);
                    walletService.CreateWallet(wallet);
                    return StatusCode(200, walletDto);

                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }

            //PUT /EditWallet
            [HttpPut, Route("EditWallet")]
            [Authorize(Roles = "")]
            public IActionResult EditWallet(WalletDto walletDto)
            {
                try
                {
                    Wallet wallet = _mapper.Map<Wallet>(walletDto);
                    walletService.EditWallet(wallet);
                    return StatusCode(200, wallet);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            //Delete /DeleteWallet
            [HttpDelete, Route("DeleteWallet/{walletID}")]
            [Authorize(Roles = "Admin")]
            public IActionResult DeleteWallet(long walletID)
            {
                try
                {
                    walletService.DeleteWallet(walletID);
                    return StatusCode(200, new JsonResult($"Wallet with Id {walletID} is Deleted"));
                }
                catch (Exception ex)
                {
                   _logger.Error(ex.Message);
                   return StatusCode(500, ex.Message);
                }
            }
        [HttpGet, Route("GetWalletsByUserID/{userID}")]
        [Authorize(Roles = "Customer")]
        public IActionResult GetWalletsByUserID(string userID)
        {
            try
            {
                List<Wallet> Wallets = walletService.GetWalletsByUserID(userID);
                List<WalletDto> walletDto = _mapper.Map<List<WalletDto>>(Wallets);
                return StatusCode(200, walletDto);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

    }
}







