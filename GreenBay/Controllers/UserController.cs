using GreenBay.Models.DTOs.UserDTO;
using GreenBay.Services;
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
    }
}
