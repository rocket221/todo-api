using AutoMapper;
using Domain.Models;
using Service.Models;
using TodoList.Dtos;
using TodoList.Dtos;

namespace TodoList.Mappings
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemTitleDto>()
                .ForMember(item => item.IsClosed, o => o.MapFrom(src => src.ClosedDate != null));

            CreateMap<CreateItemDto, CreateItemModel>();

            CreateMap<UpdateItemDto, UpdateItemModel>();

            CreateMap<Item, ItemDto>();
        }
    }
}
