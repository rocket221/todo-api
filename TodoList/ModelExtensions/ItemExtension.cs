using TodoList.Models;
using TodoList.ViewModels;

namespace TodoList.ModelExtensions
{
    public static class ItemExtension
    {
        public static void SetIdsAndDates(this Item item)
        {
            item.CreatedDate = DateTime.UtcNow;
            item.UserId = Guid.NewGuid();
            item.Id = Guid.NewGuid();
        }

        public static void Update(this Item item, UpdateItemViewModel itemViewModel)
        {
            item.Title= itemViewModel.Title;
            item.Description = itemViewModel.Description;
        }
    }
}
