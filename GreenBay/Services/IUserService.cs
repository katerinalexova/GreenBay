using GreenBay.Models.DTOs.UserDTO;

namespace GreenBay.Services
{
    public interface IUserService
    {
        RegisterResponseDTO Register(RegisterRequestDTO registerDTO);
    }
}