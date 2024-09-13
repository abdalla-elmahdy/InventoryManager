using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using InventoryManager.Shared.Contracts.Categories;
using Microsoft.Extensions.DependencyInjection;


namespace InventoryManager.Services;

public static class ServicesRegistrations
{
    public static void AddCategoriesService(this IServiceCollection services) =>
        services.AddScoped(typeof(IService<CreateCategoryDto, Category>),
                            typeof(CategoriesService<CreateCategoryDto, Category>));
}
