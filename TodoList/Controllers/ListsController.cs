﻿using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<ListViewModel> GetListById(Guid listId)
        {
            var item = _service.GetById(listId);
            return Ok(item);
        }

        [HttpPost()]
        public ActionResult<ListViewModel> Create([FromBody] CreateListViewModel list)
        {
            var createdList = _service.Create(list);
            return CreatedAtRoute("GetListById", new { listId = createdList.Id }, createdList);

        }

        [HttpPatch("{listId}")]
        public ActionResult<ListViewModel> Update(Guid listId, [FromBody]UpdateListViewModel list)
        {
            var updatedList = _service.Update(listId, list);
            return Ok(updatedList);

        }

        [HttpDelete("{listId}")]
        public ActionResult<ListViewModel> Delete(Guid listId)
        {
            _service.Delete(listId);
            return NoContent();
        }
    }
}