namespace GreenBay.Models.DTOs.ItemDTO
{
    public class ItemResponseDTO
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
