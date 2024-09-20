using InventoryManager.Core.Interfaces;
using InventoryManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManager.Infrastructure;

public static class InfrastructureRegistrations
{
    /// <summary>
    /// Extension method, Injects a Sql Server ApplicationDbContext into services collection.
    /// </summary> 
    public static void AddInventoryDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(connectionString)
            );

    /// <summary>
    /// Injects Efcore Implementation of the IRepository interface (scoped)
    /// </summary> 
    public static void AddRepository(this IServiceCollection services) =>
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
}
