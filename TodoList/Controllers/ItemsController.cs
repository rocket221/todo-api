using Microsoft.AspNetCore.Mvc;
using TodoList.Services;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _service;
        public ItemsController(IItemService service)
        {
            _service = service;
        }

        [HttpGet("{itemId}", Name = "GetItemById")]
        public ActionResult<ItemViewModel> GetItemById(Guid itemId)
        {
            var item = _service.GetById(itemId);
            return Ok(item);
        }

        [HttpPost()]
        public ActionResult<ItemViewModel> Create([FromBody]CreateItemViewModel item)
        {
            var createdItem = _service.Create(item);
            return CreatedAtRoute("GetItemById", new { itemId = createdItem.Id }, createdItem);
        }

        [HttpPatch("{itemId}")]
        public ActionResult<ItemViewModel> Update(Guid itemId, [FromBody]UpdateItemViewModel item)
        {
            var updatedItem = _service.Update(itemId, item);
            return Ok(updatedItem);
        }

        [HttpDelete("{itemId}")]
        public ActionResult<ItemViewModel> Delete(Guid itemId)
        {
            _service.Delete(itemId);
            return NoContent();
        }
    }
}
