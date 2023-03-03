using System.ComponentModel.DataAnnotations;

namespace GreenBay.Models.DTOs.UserDTO
{
    public class BidRequestDTO
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int Bid { get; set; }
    }
}
