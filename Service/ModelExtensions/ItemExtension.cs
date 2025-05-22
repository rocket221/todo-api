using Domain.Models;
using Service.Models;

namespace Service.ModelExtensions
{
    public static class ItemExtension
    {
        public static void Update(this Item item, UpdateItemModel updateItemModel)
        {
            item.Title= updateItemModel.Title;
            item.Description = updateItemModel.Description;
            item.ClosedDate = updateItemModel.ClosedDate;
        }
    }
}
