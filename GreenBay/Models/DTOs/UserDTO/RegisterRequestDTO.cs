using System.ComponentModel.DataAnnotations;

namespace GreenBay.Models.DTOs.UserDTO
{
    public class RegisterRequestDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
