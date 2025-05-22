using FluentValidation;
using TodoList.Dtos;
using TodoList.Dtos;

namespace TodoList.Validators
{
    public static class ValidatorsServiceExtension
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateItemDto>, CreateItemValidator>();
            services.AddScoped<IValidator<UpdateItemDto>, UpdateItemValidator>();
            services.AddScoped<IValidator<CreateSheetDto>, CreateSheetValidator>();
            services.AddScoped<IValidator<UpdateSheetDto>, UpdateSheetValidator>();
        }
    }
}
