using Domain.Models;
using Service.Models;

namespace Service.Factories
{
    public interface IItemFactory
    {
        Item Create(CreateItemModel createItemModel, int userId);
    }

    public class ItemFactory : IItemFactory
    {
        public Item Create(CreateItemModel createItemModel, int userId)
        {
            return new Item
            {
                Title = createItemModel.Title,
                Description = createItemModel.Description,
                SheetId = createItemModel.SheetId,
                UserId = userId,
                CreatedDate = DateTime.UtcNow
            };

        }
    }
}
