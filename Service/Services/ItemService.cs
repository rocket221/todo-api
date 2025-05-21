using OneOf.Types;
using OneOf;
using Domain.Repository;
using Domain.Models;
using Service.Models;
using Service.ModelExtensions;

namespace Service.Services
{
    public class ItemService : IItemService
    {
        private readonly TodoContext _context;

        public ItemService(TodoContext context)
        {
            _context = context;
        }

        public OneOf<Item, NotFound> GetById(int itemId)
        {
            var item = _context.Items.FirstOrDefault(item => item.Id == itemId);

            if(item == null)
            {
                return new NotFound();
            }

            return item;
        }

        public List<Item> GetAllItems()
        {
            var items = _context.Items.ToList();
            return items;
        }

        public OneOf<Item> Create(CreateItemModel viewModel)
        {
            throw new NotImplementedException();

            //var item = _mapper.Map<Item>(viewModel);
            //item.SetIdsAndDates();

            //var entity = _context.Items.Add(item);
            //_context.SaveChanges();

            //return entity.Entity;
        }

        public OneOf<Item, NotFound> Update(int itemId, UpdateItemModel item)
        {
            var entity = _context.Items.FirstOrDefault(item => item.Id == itemId);
            if (entity == null)
            {
                return new NotFound();
            }
            entity.Update(item);

            _context.SaveChanges();
            return entity;
        }
        public OneOf<Success, NotFound> Delete(int itemId)
        {
            var item = _context.Items.FirstOrDefault(item => item.Id == itemId);
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
