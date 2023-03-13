using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoList.ModelExtensions;
using TodoList.Models;
using TodoList.Repository;
using TodoList.ViewModels;

namespace TodoList.Services
{
    public class ListService : IListService
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public ListService(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ListViewModel Create(CreateListViewModel viewModel)
        {
            var list = _mapper.Map<ItemsList>(viewModel);
            list.SetIdsAndDates();

            var entity  = _context.ItemsLists.Add(list);
            _context.SaveChanges();

            return _mapper.Map<ListViewModel>(entity.Entity);
        }

        public void Delete(Guid listId)
        {
            var list = new ItemsList { Id= listId };
            _context.ItemsLists.Attach(list);
            _context.ItemsLists.Remove(list);
            _context.SaveChanges();
        }

        public ListViewModel GetById(Guid listId)
        {
            var list =  _context.ItemsLists
                .Include(list => list.Items)
                .FirstOrDefault(list => list.Id == listId)!;

            return _mapper.Map<ListViewModel>(list);
        }

        public ListViewModel Update(Guid listId, UpdateListViewModel list)
        {
            var entity = _context.ItemsLists.FirstOrDefault(list => list.Id == listId);
            entity.Update(list);
            _context.SaveChanges();

            return _mapper.Map<ListViewModel>(entity);
        }
    }
}
