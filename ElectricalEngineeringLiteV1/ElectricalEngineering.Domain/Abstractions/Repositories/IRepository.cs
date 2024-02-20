namespace ElectricalEngineering.Domain.Abstractions.Repositories;

public interface IRepository<T>
    where T : DbDependence {
    Task<IEnumerable<T>> GetAllAsync();

    Task<T> GetByName(string name);

    Task<string> AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}