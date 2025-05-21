using AutoMapper;
using Domain.Models;
using TodoList.ViewModels;

namespace TodoList.Mappings
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemTitleViewModel>()
                .ForMember(item => item.IsClosed, o => o.MapFrom(src => src.ClosedDate != null));

            CreateMap<CreateItemViewModel, Item>();

            CreateMap<Item, ItemViewModel>();
        }
    }
}
