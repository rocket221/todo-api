using FluentValidation;
using TodoList.Models;

namespace TodoList.Validators
{
    public static class ValidatorsServiceExtension
    {
        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Item>, ItemValidator>();
            services.AddScoped<IValidator<ItemsList>, ListValidator>();
        }
    }
}
