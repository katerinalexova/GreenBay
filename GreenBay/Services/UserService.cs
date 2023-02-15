using GreenBay.Contexts;
using GreenBay.Models.DTOs.UserDTO;
using GreenBay.Models.Entities;

namespace GreenBay.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public RegisterResponseDTO Register(RegisterRequestDTO registerDTO)
        {
            if (registerDTO == null)
                return new RegisterResponseDTO() { Status = 400, Message = "Invalid input." };
            if (_context.Users.Any(x => x.Username.Equals(registerDTO.Username)))
                return new RegisterResponseDTO() { Status = 400, Message = "Username is already taken. Please select a different one." };

            AddUser(registerDTO);
            return new RegisterResponseDTO() { Status = 201, Message = "User succesfully registered." };
        }

        #region Private methods

        private void AddUser(RegisterRequestDTO register)
        {
            _context.Users.Add(
                new User()
                {
                    Username = register.Username,
                    Password = register.Password,
                    Email = register.Email,
                    Coins = 0
                });

            _context.SaveChanges();
        }

        #endregion


    }
}
