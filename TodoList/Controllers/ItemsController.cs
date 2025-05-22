using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Services;
using TodoList.Auth;
using TodoList.Dtos;
using TodoList.Mappings;
using TodoList.Dtos;

namespace TodoList.Controllers
{
    [Authorize]
    [RequireUserId]
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : BaseController
    {
        private readonly IItemService _service;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateItemDto> _createValidator;
        private readonly IValidator<UpdateItemDto> _updateValidator;

        public ItemsController(
            IItemService service,
            IMapper mapper,
            IValidator<CreateItemDto> createValidator,
            IValidator<UpdateItemDto> updateValidator)
        {
            _service = service;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet("{itemId}", Name = "GetItemById")]
        public IActionResult GetItemById(int itemId)
        {
            var result = _service.GetById(itemId, UserId!.Value);
            return result.Match<IActionResult>(
                item => Ok(_mapper.Map<ItemDto>(item)),
                _ => NotFound()
                );
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemDto>> GetAllItems()
        {
            var items = _service.GetAllItems(UserId!.Value);
            return _mapper.Map<List<ItemDto>>(items);
        }

        [HttpPost()]
        public IActionResult Create([FromBody] CreateItemDto item)
        {
            var validationResult = _createValidator.Validate(item);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.MapToResonse());
            }

            var createItemModel = _mapper.Map<CreateItemModel>(item);
            var result = _service.Create(UserId!.Value, createItemModel);

            return result.Match<IActionResult>(
                item => CreatedAtRoute("GetItemById", new { itemId = item.Id }, item),
                _ => NotFound()
                );
        }

        [HttpPatch("{itemId}")]
        public IActionResult Update(int itemId, [FromBody] UpdateItemDto item)
        {
            var validationResult = _updateValidator.Validate(item);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.MapToResonse());
            }

            var updateItemModel = _mapper.Map<UpdateItemModel>(item);
            var result = _service.Update(itemId, UserId!.Value, updateItemModel);


            return result.Match<IActionResult>(
                item => Ok(item),
                _ => NotFound()
            );
        }

        [HttpDelete("{itemId}")]
        public IActionResult Delete(int itemId)
        {
            var result = _service.Delete(itemId, UserId!.Value);
            return result.Match<IActionResult>(
                success => NoContent(),
                _ => NotFound()
                );
        }
    }
}
