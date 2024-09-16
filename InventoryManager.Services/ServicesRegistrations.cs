using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.Categories;
using InventoryManager.Shared.Contracts.Inventories;
using Microsoft.Extensions.DependencyInjection;


namespace InventoryManager.Services;

public static class ServicesRegistrations
{
    public static void AddCategoriesService(this IServiceCollection services) =>
        services.AddScoped(typeof(IService<CategoryOperationsDto, Category>),
                            typeof(CategoriesService<CategoryOperationsDto, Category>));

    public static void AddInventoriesService(this IServiceCollection services) =>
        services.AddScoped(typeof(IService<InventoryOperationsDto, Inventory>),
                        typeof(InventoriesService<InventoryOperationsDto, Inventory>));
}
