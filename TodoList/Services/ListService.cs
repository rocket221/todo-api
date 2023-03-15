using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;
using TodoList.ModelExtensions;
using TodoList.Models;
using TodoList.Repository;
using TodoList.Validators;
using TodoList.ViewModels;

namespace TodoList.Services
{
    public class ListService : IListService
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<ItemsList> _validator;

        public ListService(TodoContext context, IMapper mapper, IValidator<ItemsList> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        public OneOf<ListViewModel, NotFound> GetById(Guid listId)
        {
            var list =  _context.ItemsLists
                .Include(list => list.Items)
                .FirstOrDefault(list => list.Id == listId);

            if (list == null)
            {
                return new NotFound();
            }

            return _mapper.Map<ListViewModel>(list);
        }

        public OneOf<ListViewModel, ValidationFailed> Create(CreateListViewModel viewModel)
        {
            var list = _mapper.Map<ItemsList>(viewModel);
            list.SetIdsAndDates();

            var result = _validator.Validate(list);
            if (!result.IsValid)
            {
                return new ValidationFailed(result.Errors);
            }

            var entity  = _context.ItemsLists.Add(list);
            _context.SaveChanges();

            return _mapper.Map<ListViewModel>(entity.Entity);
        }

        public OneOf<ListViewModel, ValidationFailed, NotFound> Update(Guid listId, UpdateListViewModel list)
        {
            var entity = _context.ItemsLists.FirstOrDefault(list => list.Id == listId);
            if (entity == null)
            {
                return new NotFound();
            }
            entity.Update(list);

            var result = _validator.Validate(entity);
            if (!result.IsValid)
            {
                return new ValidationFailed(result.Errors);
            }

            _context.SaveChanges();
            return _mapper.Map<ListViewModel>(entity);
        }

        public OneOf<Success, NotFound> Delete(Guid listId)
        {
            var list = _context.ItemsLists.FirstOrDefault(list => list.Id == listId);

            if (list == null)
            {
                return new NotFound();
            }

            _context.ItemsLists.Remove(list);
            _context.SaveChanges();
            return new Success();
        }
    }
}
