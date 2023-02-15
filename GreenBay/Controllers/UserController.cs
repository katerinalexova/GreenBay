using GreenBay.Models.DTOs.UserDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenBay.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("/register")]
        public IActionResult Register([FromBody] RegisterDTO registerDTO)
        {
            return Ok(registerDTO);
        }
    }
}
