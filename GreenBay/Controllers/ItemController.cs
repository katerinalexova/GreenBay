using GreenBay.Models.DTOs.ItemDTO;
using GreenBay.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenBay.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService= itemService;
        }

        [HttpPost("/create")]
        public IActionResult Create([FromBody] CreateItemRequestDTO createItemRequestDTO)
        {
            var response = _itemService.Create(createItemRequestDTO);
            return StatusCode(response.Status, response.Message);
        }

        [HttpGet("/list")]
        public IActionResult GetAllSellable()
        {
            var response = _itemService.ShowAllSellable();

            if (response.Data == null)
                return StatusCode(response.Status, response.Message);

            return Ok(response.Data);
        }
    }
}
