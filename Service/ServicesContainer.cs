using Microsoft.Extensions.DependencyInjection;
using Service.Factories;
using Service.Services;

namespace Service
{
    public static class ServicesContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ISheetService, SheetService>();
            services.AddScoped<IItemFactory, ItemFactory>();
            services.AddScoped<ISheetFactory, SheetFactory>();
        }
    }
}
