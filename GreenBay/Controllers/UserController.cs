using GreenBay.Models.DTOs.UserDTO;
using GreenBay.Models.Entities;
using GreenBay.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenBay.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/register")]
        public IActionResult Register([FromBody] RegisterRequestDTO registerDTO)
        {
            var response = _userService.Register(registerDTO);
            return StatusCode(response.Status, response.Message);
        }

        [HttpPost("/login")]
        public IActionResult Login([FromBody] LoginRequestDTO loginDTO)
        {
            var response = _userService.Login(loginDTO);
            return StatusCode(response.Status, response.Message);
        }

        [HttpPost("/bid")]
        public IActionResult Bid([FromBody] BidRequestDTO bidDTO)
        {
            // user placeholder
            User user = new User()
            {
                Id = 3,
                Username = "username",
                Password = "password",
                Email = "email@email.com",
                Coins = 1,
            };

            var response = _userService.Bid(bidDTO, user);
            return StatusCode(response.Status, response.Message);
        }
    }
}
