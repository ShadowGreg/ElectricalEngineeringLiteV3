using System.Collections.Generic;
using System.Collections.ObjectModel;
using CoreV01.Feeder;

namespace DataBase {
    public interface IReadWrite {
        List<BaseConsumer> GetConsumers();
    }
}