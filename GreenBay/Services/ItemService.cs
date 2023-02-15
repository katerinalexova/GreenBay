using GreenBay.Contexts;
using GreenBay.Models.DTOs.ItemDTO;
using GreenBay.Models.DTOs.UserDTO;
using GreenBay.Models.Entities;

namespace GreenBay.Services
{
    public class ItemService
    {
        private readonly ApplicationDbContext _context;

        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ItemResponseDTO Create(CreateItemRequestDTO createItemRequestDTO)
        {
            if (createItemRequestDTO == null)
                return new ItemResponseDTO() { Status = 400, Message = "Invalid input." };
            if (createItemRequestDTO.StartingPrice < 0)
                return new ItemResponseDTO() { Status = 400, Message = "Invalid price." };

            CreateItem(createItemRequestDTO);
            return new ItemResponseDTO() { Status = 200, Message = "Item succesfully added" };
        }

        #region Private methods

        private void CreateItem(CreateItemRequestDTO createItemRequestDTO)
        {
            _context.Items.Add(
                new Item()
                {
                    Name = createItemRequestDTO.Name,
                    Description = createItemRequestDTO.Description,
                    PhotoUrl = createItemRequestDTO.PhotoUrl,
                    Price = createItemRequestDTO.StartingPrice
                });

            _context.SaveChanges();
        }

        #endregion
    }
}
