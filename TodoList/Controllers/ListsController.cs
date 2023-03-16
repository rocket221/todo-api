using Microsoft.AspNetCore.Mvc;
using OneOf.Types;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using TodoList.Mappings;
using TodoList.Services;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListsController : ControllerBase
    {
        private readonly IListService _service;
        public ListsController(IListService service)
        {
            _service = service;
        }

        [HttpGet("{listId}", Name = "GetListById")]
        public IActionResult GetListById(Guid listId)
        {
            var result = _service.GetById(listId);
            return result.Match<IActionResult>(
                list => Ok(list),
                _ => NotFound()
                );
        }

        [HttpGet]
        public ActionResult<IEnumerable<ListViewModel>> GetAllLists()
        {
            return _service.GetAllLists();
        }

        [HttpPost()]
        public IActionResult Create([FromBody] CreateListViewModel list)
        {
            var result = _service.Create(list);
            return result.Match<IActionResult>(
                list => CreatedAtRoute("GetListById", new { listId = list.Id }, list),
                failed => BadRequest(failed.Errors.MapToResonse())
                );
        }

        [HttpPatch("{listId}")]
        public IActionResult Update(Guid listId, [FromBody]UpdateListViewModel list)
        {
            var result = _service.Update(listId, list);
            return result.Match<IActionResult>(
                list => Ok(list),
                failed => BadRequest(failed.Errors.MapToResonse()),
                _ => NotFound()
            );
        }

        [HttpDelete("{listId}")]
        public IActionResult Delete(Guid listId)
        {
            var result = _service.Delete(listId);
            return result.Match<IActionResult>(
                success => NoContent(),
                _ => NotFound()
                );
        }
    }
}
