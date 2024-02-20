using ElectricalEngineering.Domain.Feeder;
using ElectricalEngineering.DomainServices.Contrlollers.Breakers;
using ElectricalEngineering.DomainServices.Contrlollers.Cable;
using ElectricalEngineering.DomainServices.Contrlollers.Consumer;
using ElectricalEngineering.DomainServices.StandardData.Cable;

namespace ElectricalEngineering.DomainServices.Feeder {
    public class FeederFillService(BaseConsumer consumer) {
        private readonly ConsumerFillController _consumerFillController = new();

        public BaseCable Cable { get; set; } = new();
        public BaseCircuitBreaker CircuitBreaker { get; set; } = new();
        public BaseConsumer Consumer { get; } = consumer;

        public BaseFeeder GetFeeder(int num, double maxVoltageDrop, double length) {
            var outputFeeder = new BaseFeeder {
                Consumer = Consumer
            };
            _consumerFillController.FillConsumerFields(Consumer);
            Consumer.SequentialNumber = num;
            Consumer.OwnerId = outputFeeder.SelfId;
            Cable = new CableFillData(Consumer, length).GetCableValue(maxVoltageDrop);
            Cable.OwnerId = outputFeeder.SelfId;
            outputFeeder.Cable = Cable;
            CircuitBreaker = new CircuitBreakerFillController().BreakerSelect(Consumer, Cable);
            CircuitBreaker.OwnerId = outputFeeder.SelfId;
            outputFeeder.CircuitBreaker = CircuitBreaker;

            return outputFeeder;
        }
    }
}