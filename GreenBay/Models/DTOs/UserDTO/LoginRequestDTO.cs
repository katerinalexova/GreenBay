using System.ComponentModel.DataAnnotations;

namespace GreenBay.Models.DTOs.UserDTO
{
    public class LoginRequestDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
