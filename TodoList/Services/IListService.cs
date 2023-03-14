using OneOf;
using TodoList.Validators;
using TodoList.ViewModels;

namespace TodoList.Services
{
    public interface IListService
    {
        ListViewModel GetById(Guid listId);
        OneOf<ListViewModel, ValidationFailed> Create(CreateListViewModel list);
        ListViewModel Update(Guid listId, UpdateListViewModel list);
        void Delete(Guid listId);
    }
}
