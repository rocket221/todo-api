using OneOf.Types;
using OneOf;
using Service.Models;
using Domain.Models;

namespace Service.Services
{
    public interface IItemService
    {
        OneOf<Item, NotFound> GetById(int itemId, int userId);
        List<Item> GetAllItems(int userId);
        OneOf<Item, NotFound> Create(int userId, CreateItemModel viewModel);
        OneOf<Item, NotFound> Update(int itemId, int userId, UpdateItemModel item);
        OneOf<Success, NotFound> Delete(int itemId, int userId);
    }
}
