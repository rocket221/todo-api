using AutoMapper;
using Domain.Models;
using TodoList.ViewModels;

namespace TodoList.Mappings
{
    public class SheetProfile : Profile
    {
        public SheetProfile()
        {
            CreateMap<Sheet, SheetViewModel>();

            CreateMap<CreateSheetViewModel, Sheet>();
        }
    }
}
