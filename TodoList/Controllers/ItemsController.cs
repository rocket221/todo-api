using AutoMapper;
using Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Services;
using System.Security.Claims;
using TodoList.Mappings;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _service;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateItemViewModel> _createValidator;
        private readonly IValidator<UpdateItemViewModel> _updateValidator;

        public ItemsController(
            IItemService service,
            IMapper mapper,
            IValidator<CreateItemViewModel> createValidator,
            IValidator<UpdateItemViewModel> updateValidator)
        {
            _service = service;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet("{itemId}", Name = "GetItemById")]
        public IActionResult GetItemById(int itemId)
        {
            var result = _service.GetById(itemId);
            return result.Match<IActionResult>(
                item => Ok(_mapper.Map<ItemViewModel>(item)),
                _ => NotFound()
                );
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemViewModel>> GetAllItems()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var items = _service.GetAllItems();
            return _mapper.Map<List<ItemViewModel>>(items);
        }

        [HttpPost()]
        public IActionResult Create([FromBody]CreateItemViewModel item)
        {
            var validationResult = _createValidator.Validate(item);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.MapToResonse());
            }

            var createItemModel = _mapper.Map<CreateItemModel>(item);
            var result = _service.Create(createItemModel);

            return result.Match<IActionResult>(
                item => CreatedAtRoute("GetItemById", new { itemId = item.Id }, item)
                );
        }

        [HttpPatch("{itemId}")]
        public IActionResult Update(int itemId, [FromBody]UpdateItemViewModel item)
        {
            var validationResult = _updateValidator.Validate(item);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.MapToResonse());
            }

            var updateItemModel = _mapper.Map<UpdateItemModel>(item);
            var result = _service.Update(itemId, updateItemModel);


            return result.Match<IActionResult>(
                item => Ok(item),
                _ => NotFound()
            );
        }

        [HttpDelete("{itemId}")]
        public IActionResult Delete(int itemId)
        {
            var result = _service.Delete(itemId);
            return result.Match<IActionResult>(
                success => NoContent(),
                _ => NotFound()
                );
        }
    }
}
