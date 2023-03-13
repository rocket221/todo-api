using AutoMapper;
using TodoList.ModelExtensions;
using TodoList.Models;
using TodoList.Repository;
using TodoList.ViewModels;

namespace TodoList.Services
{
    public class ItemService : IItemService
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public ItemService(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ItemViewModel Create(CreateItemViewModel viewModel)
        {
            var item = _mapper.Map<Item>(viewModel);
            item.SetIdsAndDates();

            var entity = _context.Items.Add(item);
            _context.SaveChanges();

            return _mapper.Map<ItemViewModel>(entity.Entity);
        }

        public void Delete(Guid itemId)
        {
            var item = new Item { Id = itemId };
            _context.Items.Attach(item);
            _context.Items.Remove(item);
            _context.SaveChanges();
        }

        public ItemViewModel GetById(Guid itemId)
        {
            var item =  _context.Items.FirstOrDefault(item => item.Id == itemId);
            return _mapper.Map<ItemViewModel>(item);
        }

        public ItemViewModel Update(Guid itemId, UpdateItemViewModel item)
        {
            var entity = _context.Items.FirstOrDefault(item => item.Id == itemId);
            entity.Update(item);
            _context.SaveChanges();

            return _mapper.Map<ItemViewModel>(entity);
        }
    }
}
