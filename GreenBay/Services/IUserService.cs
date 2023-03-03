using GreenBay.Models.DTOs.UserDTO;
using GreenBay.Models.Entities;

namespace GreenBay.Services
{
    public interface IUserService
    {
        UserResponseDTO Register(RegisterRequestDTO registerDTO);
        UserResponseDTO Login(LoginRequestDTO loginDTO);
        UserResponseDTO Bid(BidRequestDTO bidRequestDTO, User user);
    }
}