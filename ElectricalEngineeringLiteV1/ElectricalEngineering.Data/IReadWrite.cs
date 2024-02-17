using ElectricalEngineering.Domain.Feeder;

namespace ElectricalEngineering.Data {
    //а-ля паттерн репозитория
    public interface IReadWrite {
        List<BaseConsumer> GetConsumers();
    }
}