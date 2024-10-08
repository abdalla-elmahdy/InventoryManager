using InventoryManager.Core.Entities;
using InventoryManager.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Infrastructure.Data;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, ITrackable
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _entity;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _entity = _context.Set<TEntity>();
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _entity.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }



    public async Task<IEnumerable<TEntity>> GetAllAsync() =>
        await _entity.AsNoTracking().ToListAsync();

    public async Task<TEntity?> GetByTrackingNumberAsync(Guid trackingNumber) =>
        await _entity.FirstOrDefaultAsync(e => e.TrackingNumber == trackingNumber);

    public async Task UpdateAsync(TEntity entity)
    {
        _entity.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _entity.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
