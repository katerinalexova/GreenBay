using GreenBay.Models.DTOs.ItemDTO;

namespace GreenBay.Services
{
    public interface IItemService
    {
        ItemResponseDTO Create(CreateItemRequestDTO createItemRequestDTO);
        ItemResponseDTO ShowAllSellable();
        ItemResponseDTO ShowById(int id);
    }
}