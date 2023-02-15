using System.ComponentModel.DataAnnotations;

namespace GreenBay.Models.DTOs.ItemDTO
{
    public class CreateItemRequestDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string PhotoUrl { get; set; }
        [Required]
        public int StartingPrice { get; set; }
        [Required]
        public int PurchasePrice { get; set; }
    }
}
