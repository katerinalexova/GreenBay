using GreenBay.Models.DTOs.UserDTO;

namespace GreenBay.Services
{
    public interface IUserService
    {
        UserResponseDTO Register(RegisterRequestDTO registerDTO);
        UserResponseDTO Login(LoginRequestDTO loginDTO);
    }
}