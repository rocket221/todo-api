using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Services;
using TodoList.Auth;
using TodoList.Mappings;
using TodoList.Dtos;

namespace TodoList.Controllers
{
    [Authorize]
    [RequireUserId]
    [ApiController]
    [Route("api/[controller]")]
    public class SheetsController : BaseController
    {
        private readonly ISheetService _service;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateSheetDto> _createValidator;
        private readonly IValidator<UpdateSheetDto> _updateValidator;

        public SheetsController(
            ISheetService service,
            IMapper mapper,
            IValidator<CreateSheetDto> createValidator,
            IValidator<UpdateSheetDto> updateValidator)
        {
            _service = service;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet("{sheetId}", Name = "GetSheetById")]
        public IActionResult GetSheetById(int sheetId)
        {
            var result = _service.GetById(sheetId, UserId!.Value);
            return result.Match<IActionResult>(
                sheet => Ok(_mapper.Map<SheetDto>(sheet)),
                _ => NotFound()
                );
        }

        [HttpGet]
        public ActionResult<IEnumerable<SheetDto>> GetAllSheets()
        {
            var sheets = _service.GetAllSheets(UserId!.Value);
            return _mapper.Map<List<SheetDto>>(sheets);
        }

        [HttpPost()]
        public IActionResult Create([FromBody] CreateSheetDto sheet)
        {
            var validationResult = _createValidator.Validate(sheet);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.MapToResonse());
            }

            var createSheetModel = _mapper.Map<CreateSheetModel>(sheet);
            var result = _service.Create(UserId!.Value, createSheetModel);

            return result.Match<IActionResult>(
                sheet => CreatedAtRoute("GetSheetById", new { sheetId = sheet.Id }, sheet)
                );
        }

        [HttpPatch("{sheetId}")]
        public IActionResult Update(int sheetId, [FromBody]UpdateSheetDto sheet)
        {
            var validationResult = _updateValidator.Validate(sheet);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.MapToResonse());
            }

            var updateSheetModel = _mapper.Map<UpdateSheetModel>(sheet);

            var result = _service.Update(sheetId, UserId!.Value, updateSheetModel);
            return result.Match<IActionResult>(
                sheet => Ok(sheet),
                _ => NotFound()
            );
        }

        [HttpDelete("{sheetId}")]
        public IActionResult Delete(int sheetId)
        {
            var result = _service.Delete(sheetId, UserId!.Value);
            return result.Match<IActionResult>(
                success => NoContent(),
                _ => NotFound()
                );
        }
    }
}
