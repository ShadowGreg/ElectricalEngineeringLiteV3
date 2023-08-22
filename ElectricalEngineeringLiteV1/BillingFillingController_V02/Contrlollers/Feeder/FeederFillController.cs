using BillingFillingController.Contrlollers.Breakers;
using BillingFillingController.Contrlollers.Cable;
using BillingFillingController.Contrlollers.Consumer;
using CoreV01.Feeder;

namespace BillingFillingController.Contrlollers.Feeder {
    public class FeederFillController {
        public BaseCable Cable { get; set; }
        public BaseCircuitBreaker CircuitBreaker { get; set; }
        public BaseConsumer Consumer { get; }
        private readonly ConsumerFillController _consumerFillController;

        public FeederFillController(BaseConsumer consumer) {
            Consumer = consumer;
            Cable = new BaseCable();
            CircuitBreaker = new BaseCircuitBreaker();
            _consumerFillController = new ConsumerFillController();
        }

        public BaseFeeder GetFeeder(int num, double maxVoltageDrop, double length) {
            BaseFeeder outputFeeder = new BaseFeeder() {
                Consumer = Consumer
            };
            _consumerFillController.FillConsumerFields(Consumer);
            Consumer.SequentialNumber = num;
            Consumer.OwnerId = outputFeeder.SelfId;
            Cable = new CableFillController(Consumer, length).GetCableValue(maxVoltageDrop);
            Cable.OwnerId = outputFeeder.SelfId;
            outputFeeder.Cable = Cable;
            CircuitBreaker = new CircuitBreakerFillController().BreakerSelect(Consumer, Cable);
            CircuitBreaker.OwnerId = outputFeeder.SelfId;
            outputFeeder.CircuitBreaker = CircuitBreaker;

            return outputFeeder;
        }
    }
}