using OneOf.Types;
using OneOf;
using Domain.Repository;
using Domain.Models;
using Service.Models;
using Service.ModelExtensions;
using Service.Factories;

namespace Service.Services
{
    public class ItemService : IItemService
    {
        private readonly TodoContext _context;
        private readonly IItemFactory _itemFactory;

        public ItemService(TodoContext context, IItemFactory itemFactory)
        {
            _context = context;
            _itemFactory = itemFactory;
        }

        public OneOf<Item, NotFound> GetById(int itemId, int userId)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == itemId && i.UserId == userId);

            if(item == null)
            {
                return new NotFound();
            }

            return item;
        }

        public List<Item> GetAllItems(int userId)
        {
            var items = _context.Items.Where(x => x.UserId == userId).ToList();
            return items;
        }

        public OneOf<Item, NotFound> Create(int userId, CreateItemModel viewModel)
        {
            var sheet = _context.Sheets.FirstOrDefault(s => s.Id == viewModel.SheetId && s.UserId == userId);
            if (sheet == null)
                return new NotFound();

            var item = _itemFactory.Create(viewModel, userId);

            var entity = _context.Items.Add(item);
            _context.SaveChanges();

            return entity.Entity;
        }

        public OneOf<Item, NotFound> Update(int itemId, int userId, UpdateItemModel item)
        {
            var entity = _context.Items.FirstOrDefault(i => i.Id == itemId && i.UserId == userId);
            if (entity == null)
            {
                return new NotFound();
            }
            entity.Update(item);

            _context.SaveChanges();
            return entity;
        }
        public OneOf<Success, NotFound> Delete(int itemId, int userId)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == itemId && i.UserId == userId);
            if (item == null)
            {
                return new NotFound();
            }

            _context.Items.Remove(item);
            _context.SaveChanges();
            return new Success();
        }
    }
}
