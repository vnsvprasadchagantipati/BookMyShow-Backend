using AutoMapper;
using BookMyShowNewWebAPI.DTOs;
using BookMyShowNewWebAPI.Entity;
using BookMyShowNewWebAPI.Models;
using BookMyShowNewWebAPI.Services;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookMyShowNewWebAPI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            private readonly IUserService userService;
            private readonly IMapper _mapper;
            private readonly IConfiguration configuration;
            private readonly ILog _logger;

            public UserController(IUserService userService, IMapper mapper, IConfiguration configuration,ILog logger)
            {
                this.userService = userService;
                _mapper = mapper;
                this.configuration = configuration;
                _logger = logger;
            }

            //Get: /GetAllUsers
            [HttpGet, Route("GetAllUsers")]
            [Authorize(Roles = "Admin,Customer")]
            public IActionResult GetAllUsers()
            {
                try
                {
                    List<User> users = userService.GetAllUsers();
                    List<UserDto> usersDto = _mapper.Map<List<UserDto>>(users);
                    return StatusCode(200, usersDto);

                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            [HttpPost, Route("Register")]
            [AllowAnonymous] 
            public IActionResult AddUser(UserDto userDto)
            {
                try
                {
                    User user = _mapper.Map<User>(userDto);
                    userService.CreateUser(user);
                    return StatusCode(200, user);

                }
                catch (Exception ex)
                {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                
                }
            }
            //PUT /EditUser
            [HttpPut, Route("EditUser")]
            [Authorize(Roles = "Customer")]
            public IActionResult EditUser(UserDto userDto)
            {
                try
                {
                    User user = _mapper.Map<User>(userDto);
                    userService.EditUser(user);
                    return StatusCode(200, user);
        

                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
            [HttpPost, Route("Validate")]
            [AllowAnonymous]
            public IActionResult Validate(Login login)
            {
                try
                {
                    User user = userService.ValidteUser(login.Email, login.Password);
                    AuthResponse authReponse = new AuthResponse();
                    if (user != null)
                    {
                        authReponse.UserID = user.UserID;
                        authReponse.UserName = user.Name;
                        authReponse.Role = user.Role;
                        authReponse.Token = GetToken(user);
                    }
                    return StatusCode(200, authReponse);
                }
                catch (Exception ex)
                {

                    return StatusCode(500, ex.Message);
                }
            }
            private string GetToken(User? user)
            {
                var issuer = configuration["Jwt:Issuer"];
                var audience = configuration["Jwt:Audience"];
                var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                //header part
                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature
                );
                //payload part
                var subject = new ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.Name,user.Name),
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim(ClaimTypes.Email,user.Email),
                    });

                var expires = DateTime.UtcNow.AddMinutes(10);
                //signature part
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = expires,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = signingCredentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                return jwtToken;
            }

        }
    }


