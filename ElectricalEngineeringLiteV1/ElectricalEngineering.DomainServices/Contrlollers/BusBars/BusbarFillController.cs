using ElectricalEngineering.Domain;
using ElectricalEngineering.Domain.Feeder;
using ElectricalEngineering.DomainServices.Calculators;
using ElectricalEngineering.DomainServices.Contrlollers.Breakers;
using ElectricalEngineering.DomainServices.Feeder;

namespace ElectricalEngineering.DomainServices.Contrlollers.BusBars {
    public class BusbarFillController {
        private List<BaseConsumer> _consumers;
        private List<BaseFeeder> _feeders;
        private BaseBusbar _busbar;
        private readonly double _voltage;

        public BusbarFillController(double voltage) {
            _voltage = voltage;
            _consumers = new List<BaseConsumer>();
            _feeders = new List<BaseFeeder>();
            _busbar = new BaseBusbar();
            BusbarCalculations = new RtmCalculation();
        }

        public RtmCalculation BusbarCalculations { get; set; }

        /// <summary>
        ///     Добавление одного электроприёмника на шину
        /// </summary>
        /// <param name="newConsumer">Экземпляр класса BaseConsumer</param>
        /// <param name="length">Длина от распред щита до потребителя</param>
        /// <param name="maxVoltageDrop">Максимальное падение напряжения в линии до электроприёмника</param>
        public void AddConsumerOnBus(BaseConsumer newConsumer, double length, double maxVoltageDrop = 2.5) {
            _consumers.Add(newConsumer);
            if (_feeders.Count == 0) {
                _feeders.Add(new FeederFillService(newConsumer).GetFeeder(1, maxVoltageDrop, length));
            }
            else {
                int index = _feeders.Count + 1;
                _feeders.Add(new FeederFillService(newConsumer).GetFeeder(index, maxVoltageDrop, length));
            }

            _feeders[_feeders.Count - 1].OwnerId = _busbar.SelfId;
            _feeders[_feeders.Count - 1].SequentialNumber = _feeders.Count;
            _feeders[_feeders.Count - 1].CircuitBreaker.NameOnBus += _feeders.Count;
            FillBusbarParams();
        }

        private void FillBusbarParams() {
            void BasicFilling() {
                _busbar.EmergencyСurrentInputSwitch = _busbar.RatedCurrent;
                _busbar.SectionalCircuitBreaker = null;
                _busbar.EmergencyСurrentSectionalSwitch = 0;
            }

            _busbar.InstalledCapacity = BusbarCalculations.GetInstallCapacity(_consumers, _voltage);
            _busbar.RatedCapacity = BusbarCalculations.ActiveRatedPowerOfTheBus;
            _busbar.PowerFactor = BusbarCalculations.BusPowerFactor;
            _busbar.RatedCurrent = BusbarCalculations.DesignBusbarCurrent;
            _busbar.InputSwitch = GetBusbarInputSwitch();
            _busbar.InputSwitch.NameOnBus = "QS";
            _busbar.Feeders = _feeders;

            BasicFilling();
        }

        private BaseCircuitBreaker GetBusbarInputSwitch() {
            return new CircuitBreakerFillController().GetInputSwitch(_busbar.RatedCurrent);
        }

        /// <summary>
        ///     добавление коллекциия потребителей на шину
        /// </summary>
        /// <param name="consumers">Коллекция экземпляров типа BaseConsumer</param>
        public void AddConsumersListOnBus(IEnumerable<BaseConsumer> consumers) {
            _consumers.AddRange(consumers);
            foreach (var consumer in consumers) {
                const double lenght = 5;
                AddConsumerOnBus(consumer, lenght);
            }
        }

        /// <summary>
        ///     Получить рассчитанную шину все данные уже прогружены
        /// </summary>
        /// <returns>объект класса BaseBusbar</returns>
        public BaseBusbar GetBusbar() {
            return _busbar;
        }

        /// <summary>
        ///     Удаление одного электроприёмника с шины
        /// </summary>
        /// <param name="delConsumer">Экземпляр класса BaseConsumer</param>
        /// <param name="length">Длина от распред щита до потребителя</param>
        /// <param name="maxVoltageDrop">Максимальное падение напряжения в линии до электроприёмника</param>
        public void DelConsumerOnBus(BaseConsumer delConsumer) {
            if (_consumers.Remove(delConsumer)) {
                int index = 0;
                foreach (var feeder in _feeders) {
                    if (feeder.Consumer == delConsumer) {
                        _feeders.RemoveAt(index);
                        break;
                    }

                    index++;
                }

                FillBusbarParams();
            }
            else {
                throw new InvalidOperationException("Ошибка удаляемого объекта с шины");
            }
        }
    }
}