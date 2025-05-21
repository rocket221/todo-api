using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using Service.Services;
using TodoList.Mappings;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SheetsController : ControllerBase
    {
        private readonly ISheetService _service;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateSheetViewModel> _createValidator;
        private readonly IValidator<UpdateSheetViewModel> _updateValidator;

        public SheetsController(
            ISheetService service,
            IMapper mapper,
            IValidator<CreateSheetViewModel> createValidator,
            IValidator<UpdateSheetViewModel> updateValidator)
        {
            _service = service;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet("{sheetId}", Name = "GetSheetById")]
        public IActionResult GetSheetById(int sheetId)
        {
            var result = _service.GetById(sheetId);
            return result.Match<IActionResult>(
                sheet => Ok(_mapper.Map<SheetViewModel>(sheet)),
                _ => NotFound()
                );
        }

        [HttpGet]
        public ActionResult<IEnumerable<SheetViewModel>> GetAllSheets()
        {
            var sheets = _service.GetAllSheets();
            return _mapper.Map<List<SheetViewModel>>(sheets);
        }

        [HttpPost()]
        public IActionResult Create([FromBody] CreateSheetViewModel sheet)
        {
            var validationResult = _createValidator.Validate(sheet);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.MapToResonse());
            }

            var createSheetModel = _mapper.Map<CreateSheetModel>(sheet);
            var result = _service.Create(createSheetModel);

            return result.Match<IActionResult>(
                sheet => CreatedAtRoute("GetSheetById", new { sheetId = sheet.Id }, sheet)
                );
        }

        [HttpPatch("{sheetId}")]
        public IActionResult Update(int sheetId, [FromBody]UpdateSheetViewModel sheet)
        {
            var validationResult = _updateValidator.Validate(sheet);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.MapToResonse());
            }

            var updateSheetModel = _mapper.Map<UpdateSheetModel>(sheet);

            var result = _service.Update(sheetId, updateSheetModel);
            return result.Match<IActionResult>(
                sheet => Ok(sheet),
                _ => NotFound()
            );
        }

        [HttpDelete("{sheetId}")]
        public IActionResult Delete(int sheetId)
        {
            var result = _service.Delete(sheetId);
            return result.Match<IActionResult>(
                success => NoContent(),
                _ => NotFound()
                );
        }
    }
}
