using AutoMapper;
using Domain.Models;
using Service.Models;
using TodoList.Dtos;

namespace TodoList.Mappings
{
    public class SheetProfile : Profile
    {
        public SheetProfile()
        {
            CreateMap<Sheet, SheetDto>();

            CreateMap<CreateSheetDto, CreateSheetModel>();

            CreateMap<UpdateSheetDto, UpdateSheetModel>();
        }
    }
}
