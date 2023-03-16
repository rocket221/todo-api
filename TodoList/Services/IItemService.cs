using OneOf.Types;
using OneOf;
using TodoList.Validators;
using TodoList.ViewModels;

namespace TodoList.Services
{
    public interface IItemService
    {
        OneOf<ItemViewModel, NotFound> GetById(Guid itemId);
        OneOf<ItemViewModel, ValidationFailed> Create(CreateItemViewModel viewModel);
        OneOf<ItemViewModel, ValidationFailed, NotFound> Update(Guid itemId, UpdateItemViewModel item);
        OneOf<Success, NotFound> Delete(Guid listId);
        List<ItemViewModel> GetAllItems();
    }
}
