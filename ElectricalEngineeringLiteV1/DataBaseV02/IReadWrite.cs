using System.Collections.Generic;
using CoreV01.Feeder;

namespace DataBase {
    public interface IReadWrite {
        List<BaseConsumer> GetConsumers();
    }
}