namespace ElectricalEngineering.Domain.Feeder {
    public class BaseFeeder: DbDependence {
        private BaseCable _cable = null;
        public BaseCircuitBreaker CircuitBreaker { get; set; }

        public BaseCable Cable
        {
            get => _cable;
            set
            {
                if (Cable != null) {
                    Name = Cable.Name;
                    _cable = value;
                }
            }
        }

        public BaseConsumer Consumer { get; set; }
    }
}