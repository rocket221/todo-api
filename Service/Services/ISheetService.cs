using Domain.Models;
using OneOf;
using OneOf.Types;
using Service.Models;

namespace Service.Services
{
    public interface ISheetService
    {
        OneOf<Sheet, NotFound> GetById(int sheetId, int userId);
        List<Sheet> GetAllSheets(int userId);
        OneOf<Sheet> Create(int userId, CreateSheetModel sheet);
        OneOf<Sheet, NotFound> Update(int sheetId, int userId, UpdateSheetModel sheet);
        OneOf<Success, NotFound> Delete(int sheetId, int userId);
    }
}
