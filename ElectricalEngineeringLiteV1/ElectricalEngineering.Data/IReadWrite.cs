using System.Collections.Generic;
using ElectricalEngineering.Domain.Feeder;

namespace DataBase {
    public interface IReadWrite {
        List<BaseConsumer> GetConsumers();
    }
}