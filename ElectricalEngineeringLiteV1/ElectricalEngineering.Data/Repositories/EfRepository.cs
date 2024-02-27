using ElectricalEngineering.Domain;
using ElectricalEngineering.Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ElectricalEngineering.Data.Repositories;

public class EfRepository<T>(DataContext context) : IRepository<T>
    where T : DbDependence 
{
    private readonly DataContext _context = context;

    public async Task<IEnumerable<T>> GetAllAsync() {
        var entities = await _context.Set<T>().ToListAsync();
        return entities;
    }

    public Task<T> GetByName(string name) {
        var entity = _context.Set<T>().FirstOrDefault(x => x.Name == name);
        return Task.FromResult(entity)!;
    }

    public async Task<string> AddAsync(T entity) {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity.SelfId;
    }

    public async Task UpdateAsync(T entity) {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity) {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}