using GreenBay.Contexts;
using GreenBay.Models.DTOs.ItemDTO;
using GreenBay.Models.Entities;

namespace GreenBay.Services
{
    public class ItemService : IItemService
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
        public ItemResponseDTO ShowAllSellable()
        {
            List<Item> sellable = GetAll().Where(x => x.Sold == false).ToList();

            if (sellable.Count == 0)
                return new ItemResponseDTO() { Status = 200, Message = "Any new products" };

            return new ItemResponseDTO() { Status = 200, Data = sellable };
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
        private List<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        #endregion
    }
}
