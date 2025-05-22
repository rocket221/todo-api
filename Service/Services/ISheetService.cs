using Domain.Models;
using OneOf;
using OneOf.Types;
using Service.Models;

namespace Service.Services
{
    public interface ISheetService
    {
        OneOf<Sheet, NotFound> GetById(int sheetId);
        List<Sheet> GetAllSheets();
        OneOf<Sheet> Create(CreateSheetModel sheet);
        OneOf<Sheet, NotFound> Update(int sheetId, UpdateSheetModel sheet);
        OneOf<Success, NotFound> Delete(int sheetId);
    }
}
