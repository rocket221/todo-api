using System.Runtime.CompilerServices;
using TodoList.Services;

namespace TodoList
{
    public static class ServicesContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IListService, ListService>();
        }
    }
}
