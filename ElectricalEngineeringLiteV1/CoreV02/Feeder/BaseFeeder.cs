using CoreV01.Properties;

namespace CoreV01.Feeder {
    public class BaseFeeder: DBDependence {
        public BaseCircuitBreaker CircuitBreaker { get; set; }
        public BaseCable Cable { get; set; }
        public BaseConsumer Consumer { get; set; }
    }
}