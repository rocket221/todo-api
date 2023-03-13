using TodoList.Models;
using TodoList.ViewModels;

namespace TodoList.ModelExtensions
{
    public static class ListExtension
    {
        public static void SetIdsAndDates(this ItemsList list)
        {
            list.UserId = Guid.NewGuid();
            list.Id = Guid.NewGuid();
        }

        public static void Update(this ItemsList list, UpdateListViewModel listViewModel)
        {
            list.Title = listViewModel.Title;
            list.Description = listViewModel.Description;
        }
    }
}
