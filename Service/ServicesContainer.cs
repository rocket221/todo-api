using Microsoft.Extensions.DependencyInjection;
using Service.Services;

namespace Service
{
    public static class ServicesContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<ISheetService, SheetService>();
        }
    }
}
