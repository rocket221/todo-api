using TodoList.ViewModels;

namespace TodoList.Services
{
    public interface IListService
    {
        ListViewModel GetById(Guid listId);
        ListViewModel Create(CreateListViewModel list);
        ListViewModel Update(Guid listId, UpdateListViewModel list);
        void Delete(Guid listId);
    }
}
