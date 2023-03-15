using AutoMapper;
using FluentValidation;
using OneOf.Types;
using OneOf;
using TodoList.ModelExtensions;
using TodoList.Models;
using TodoList.Repository;
using TodoList.ViewModels;
using TodoList.Validators;

namespace TodoList.Services
{
    public class ItemService : IItemService
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<Item> _validator;

        public ItemService(TodoContext context, IMapper mapper, IValidator<Item> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public OneOf<ItemViewModel, NotFound> GetById(Guid itemId)
        {
            var item = _context.Items.FirstOrDefault(item => item.Id == itemId);

            if(item == null)
            {
                return new NotFound();
            }

            return _mapper.Map<ItemViewModel>(item);
        }

        public List<ItemViewModel> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public OneOf<ItemViewModel, ValidationFailed> Create(CreateItemViewModel viewModel)
        {
            var item = _mapper.Map<Item>(viewModel);
            item.SetIdsAndDates();

            var result = _validator.Validate(item);
            if (!result.IsValid)
            {
                return new ValidationFailed(result.Errors);
            }

            var entity = _context.Items.Add(item);
            _context.SaveChanges();

            return _mapper.Map<ItemViewModel>(entity.Entity);
        }

        public OneOf<ItemViewModel, ValidationFailed, NotFound> Update(Guid itemId, UpdateItemViewModel item)
        {
            var entity = _context.Items.FirstOrDefault(item => item.Id == itemId);
            if (entity == null)
            {
                return new NotFound();
            }
            entity.Update(item);

            var result = _validator.Validate(entity);
            if (!result.IsValid)
            {
                return new ValidationFailed(result.Errors);
            }

            _context.SaveChanges();
            return _mapper.Map<ItemViewModel>(entity);
        }
        public OneOf<Success, NotFound> Delete(Guid itemId)
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
