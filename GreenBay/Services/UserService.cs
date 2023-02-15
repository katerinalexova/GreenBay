using GreenBay.Contexts;
using GreenBay.Models.DTOs.UserDTO;
using GreenBay.Models.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;

namespace GreenBay.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public UserService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public ResponseDTO Register(RegisterRequestDTO registerDTO)
        {
            if (registerDTO == null)
                return new ResponseDTO() { Status = 400, Message = "Invalid input." };
            if (_context.Users.Any(x => x.Username.Equals(registerDTO.Username)))
                return new ResponseDTO() { Status = 400, Message = "Username is already taken. Please select a different one." };

            RegisterUser(registerDTO);
            return new ResponseDTO() { Status = 201, Message = "User succesfully registered." };
        }

        public ResponseDTO Login(LoginRequestDTO loginDTO)
        {
            if(loginDTO == null)
                return new ResponseDTO() { Status = 400, Message = "Invalid input." };
            if (!_context.Users.Any(u => u.Username.Equals(loginDTO.Username)))
                return new ResponseDTO() { Status = 400, Message = "Username not registered." };
            if (!_context.Users.FirstOrDefault(u => u.Username == loginDTO.Username).Password.Equals(loginDTO.Password))
                return new ResponseDTO() { Status = 400, Message = "Incorrect password." };

            var token = CreateToken(loginDTO);
                return new ResponseDTO() { Status = 200, Message = token };
        }

        #region Private methods

        private void RegisterUser(RegisterRequestDTO register)
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

        private string CreateToken(LoginRequestDTO loginDTO)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, loginDTO.Username)
            };

            var keyString = _configuration["Jwt:Key"];
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(keyString));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion


    }
}
