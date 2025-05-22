using Domain.Models;
using Service.Models;

namespace Service.Factories
{
    public interface ISheetFactory
    {
        Sheet Create(CreateSheetModel createItemModel, int userId);

    }
    public class SheetFactory : ISheetFactory
    {
        public Sheet Create(CreateSheetModel createItemModel, int userId)
        {
            return new Sheet
            {
                Title = createItemModel.Title,
                Description = createItemModel.Description,
                UserId = userId
            };

        }
    }
}
