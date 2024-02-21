using ElectricalEngineering.Domain;
using ElectricalEngineering.Domain.Abstractions.Repositories;

namespace ElectricalEngineering.Data.Repositories;

public class InMemoryRepository<T>(List<T> data): IRepository<T>
    where T : DbDependence {
    protected List<T> Data { get; set; } = data;


    public Task<IEnumerable<T>> GetAllAsync() {
        return Task.FromResult(Data.AsEnumerable());
    }

    public Task<T> GetByName(string name) {
        return Task.FromResult(Data.FirstOrDefault(x => x.Name == name))!;
    }

    public async Task<string> AddAsync(T entity) {
        data.Append(entity);
        return entity.SelfId;
    }

    public async Task UpdateAsync(T entity) {
        var item  =data.FirstOrDefault(e => e.SelfId == entity.SelfId);
        if ( item != null) { item = entity; }
    }

    public async Task DeleteAsync(T entity) {
        var item  =data.FirstOrDefault(e => e.SelfId == entity.SelfId);
        if ( item != null) { data.Remove(item); }
    }
}