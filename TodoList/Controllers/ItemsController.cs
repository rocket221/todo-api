using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoList.Mappings;
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
        public IActionResult GetItemById(Guid itemId)
        {
            var result = _service.GetById(itemId);
            return result.Match<IActionResult>(
                item => Ok(item),
                _ => NotFound()
                );
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<ItemViewModel>> GetAllItems()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            return _service.GetAllItems();
        }

        [HttpPost()]
        public IActionResult Create([FromBody]CreateItemViewModel item)
        {
            var result = _service.Create(item);
            return result.Match<IActionResult>(
                item => CreatedAtRoute("GetItemById", new { itemId = item.Id }, item),
                failed => BadRequest(failed.Errors.MapToResonse())
                );
        }

        [HttpPatch("{itemId}")]
        public IActionResult Update(Guid itemId, [FromBody]UpdateItemViewModel item)
        {
            var result = _service.Update(itemId, item);
            return result.Match<IActionResult>(
                item => Ok(item),
                failed => BadRequest(failed.Errors.MapToResonse()),
                _ => NotFound()
            );
        }

        [HttpDelete("{itemId}")]
        public IActionResult Delete(Guid itemId)
        {
            var result = _service.Delete(itemId);
            return result.Match<IActionResult>(
                success => NoContent(),
                _ => NotFound()
                );
        }
    }
}
