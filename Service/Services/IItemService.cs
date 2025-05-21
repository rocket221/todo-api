using OneOf.Types;
using OneOf;
using Service.Models;
using Domain.Models;

namespace Service.Services
{
    public interface IItemService
    {
        OneOf<Item, NotFound> GetById(int itemId);
        List<Item> GetAllItems();
        OneOf<Item> Create(CreateItemModel viewModel);
        OneOf<Item, NotFound> Update(int itemId, UpdateItemModel item);
        OneOf<Success, NotFound> Delete(int listId);
    }
}
