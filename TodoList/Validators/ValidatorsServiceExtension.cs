using FluentValidation;
using TodoList.ViewModels;

namespace TodoList.Validators
{
    public static class ValidatorsServiceExtension
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateItemViewModel>, CreateItemValidator>();
            services.AddScoped<IValidator<UpdateItemViewModel>, UpdateItemValidator>();
            services.AddScoped<IValidator<CreateSheetViewModel>, CreateSheetValidator>();
            services.AddScoped<IValidator<UpdateSheetViewModel>, UpdateSheetValidator>();
        }
    }
}
