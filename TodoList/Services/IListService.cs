using OneOf;
using OneOf.Types;
using TodoList.Validators;
using TodoList.ViewModels;

namespace TodoList.Services
{
    public interface IListService
    {
        OneOf<ListViewModel, NotFound> GetById(Guid listId);
        List<ListViewModel> GetAllLists();
        OneOf<ListViewModel, ValidationFailed> Create(CreateListViewModel list);
        OneOf<ListViewModel, ValidationFailed, NotFound> Update(Guid listId, UpdateListViewModel list);
        OneOf<Success, NotFound> Delete(Guid listId);
    }
}
