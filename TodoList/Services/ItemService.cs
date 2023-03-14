using AutoMapper;
using FluentValidation;
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
        private IValidator<Item> _validator;

        public ItemService(TodoContext context, IMapper mapper, IValidator<Item> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public ItemViewModel Create(CreateItemViewModel viewModel)
        {
            var item = _mapper.Map<Item>(viewModel);
            item.SetIdsAndDates();

            var result = _validator.Validate(item);

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

            var result = _validator.Validate(entity);

            _context.SaveChanges();

            return _mapper.Map<ItemViewModel>(entity);
        }
    }
}
