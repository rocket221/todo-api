using AutoMapper;
using TodoList.Models;
using TodoList.ViewModels;

namespace TodoList.Mappings
{
    public class ListProfile : Profile
    {
        public ListProfile()
        {
            CreateMap<ItemsList, ListViewModel>();

            CreateMap<CreateListViewModel, ItemsList>();
        }
    }
}
