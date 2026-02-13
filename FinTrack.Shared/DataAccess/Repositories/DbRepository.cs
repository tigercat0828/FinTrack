using Microsoft.EntityFrameworkCore;
namespace FinTrack.Shared.DataAccess.Repositories;

public class DbRepository<T>(IDbContextFactory<AppDbContext> factory) where T : class
{
    private readonly IDbContextFactory<AppDbContext> _factory = factory;
    public async Task<List<T>> GetAllAsync()
    {
        await using var context = await _factory.CreateDbContextAsync();
        return await context.Set<T>()
                            .AsNoTracking()
                            .ToListAsync();
    }
    public async Task<List<T>> GetByPage(int page, int size)
    {
        using var context = _factory.CreateDbContext();
        return await context.Set<T>()
             .AsNoTracking()
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
    }
    public async Task<T> GetByIdAsync(object id)
    {
        await using var context = await _factory.CreateDbContextAsync();
        return await context.Set<T>().FindAsync(id);
    }
    public async Task CreateAsync(T entity)
    {
        await using var context = await _factory.CreateDbContextAsync();
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
    }
    public async Task UpdateAsync(T entity)
    {
        await using var context = await _factory.CreateDbContextAsync();

        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        await using var context = await _factory.CreateDbContextAsync();

        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(object id)
    {
        await using var context = await _factory.CreateDbContextAsync();

        var entity = await context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
