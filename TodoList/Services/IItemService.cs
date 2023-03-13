using TodoList.ViewModels;

namespace TodoList.Services
{
    public interface IItemService
    {
        ItemViewModel GetById(Guid itemId);
        ItemViewModel Create(CreateItemViewModel viewModel);
        ItemViewModel Update(Guid itemId, UpdateItemViewModel item);
        void Delete (Guid itemId);
    }
}
