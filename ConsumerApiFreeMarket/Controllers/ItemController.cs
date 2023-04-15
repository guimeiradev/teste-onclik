using ConsumerApiFreeMarket.Models;
using ConsumerApiFreeMarket.Service;
using ConsumerApiFreeMarket.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ConsumerApiFreeMarket.Controllers {
    [ApiController]
    public class ItemController : ControllerBase {

        private readonly ItemService _service;

        public ItemController(ItemService service) {
            _service = service;
        }

        [HttpGet("v1/item")]
        public async Task<IActionResult> GetItem(int statusCode) {
            try {

                var item = await _service.GetItem(statusCode);

                return Ok(item);
            } catch {
                return Ok(new ResultViewModel<Item>("Falha interna no servidor."));
            }
        }
    }
}
