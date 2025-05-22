using Domain.Models;
using Service.Models;

namespace Service.ModelExtensions
{
    public static class SheetExtension
    {
        public static void Update(this Sheet sheet, UpdateSheetModel updateSheetModel)
        {
            sheet.Title = updateSheetModel.Title;
            sheet.Description = updateSheetModel.Description;
        }
    }
}
