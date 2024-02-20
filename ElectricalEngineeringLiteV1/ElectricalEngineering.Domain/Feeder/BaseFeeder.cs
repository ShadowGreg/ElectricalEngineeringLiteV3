namespace ElectricalEngineering.Domain.Feeder {
    public class BaseFeeder: DbDependence {
        public BaseCircuitBreaker CircuitBreaker { get; set; }
        public BaseCable Cable { get; set; }
        public BaseConsumer Consumer { get; set; }
    }
}