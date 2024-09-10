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
    
}
