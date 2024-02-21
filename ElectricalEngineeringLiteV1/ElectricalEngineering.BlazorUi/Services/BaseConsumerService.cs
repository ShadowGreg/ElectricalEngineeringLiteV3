using ElectricalEngineering.Data.Data;
using ElectricalEngineering.Data.Repositories;
using ElectricalEngineering.Domain.Abstractions.Repositories;
using ElectricalEngineering.Domain.Feeder;

namespace ElectricalEngineering.BlazorUi.Controllers;

public class BaseConsumerService {
    private readonly IRepository<BaseConsumer> _baseConsumerRepository 
        = new InMemoryRepository<BaseConsumer>(FakeDataBase.Consumers);

    public async Task<IEnumerable<BaseConsumer>> GetAllConsumersAsync() {
        var consumers = await _baseConsumerRepository.GetAllAsync();
        return consumers;
    }
}