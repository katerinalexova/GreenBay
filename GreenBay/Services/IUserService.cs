using GreenBay.Models.DTOs.UserDTO;

namespace GreenBay.Services
{
    public interface IUserService
    {
        ResponseDTO Register(RegisterRequestDTO registerDTO);
        ResponseDTO Login(LoginRequestDTO loginDTO);
    }
}