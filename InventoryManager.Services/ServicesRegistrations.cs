using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.Categories;
using InventoryManager.Shared.Contracts.Inventories;
using InventoryManager.Shared.Contracts.Orders;
using InventoryManager.Shared.Contracts.Products;
using Microsoft.Extensions.DependencyInjection;


namespace InventoryManager.Services;

public static class ServicesRegistrations
{
    public static void AddEntitiesServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IService<CategoryOperationsDto, Category>),
                        typeof(CategoriesService<CategoryOperationsDto, Category>));
        services.AddScoped(typeof(IService<InventoryOperationsDto, Inventory>),
                        typeof(InventoriesService<InventoryOperationsDto, Inventory>));
        services.AddScoped(typeof(IService<ProductOperationsDto, Product>),
                        typeof(ProductsService<ProductOperationsDto, Product>));
        services.AddScoped(typeof(IService<OrderOperationsDto, Order>),
                        typeof(OrdersService<OrderOperationsDto, Order>));
    }

}
