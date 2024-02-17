using System.Data;
using ElectricalEngineering.Domain.Feeder;

namespace ElectricalEngineering.Domain.Contrlollers.Breakers {
    public class CircuitBreakerFillController {
        private readonly BreakerData _breakerData = new BreakerData();

        public BaseCircuitBreaker GetInputSwitch(double inRatedCurrent) {
            double switchKey = GetKey(_breakerData._theePolesBreakerData, inRatedCurrent);
            return _breakerData._theePolesBreakerData[switchKey];
        }

        public BaseCircuitBreaker BreakerSelect(BaseConsumer consumer, BaseCable cable) {
            if (consumer.Voltage < 380) return GetSinglePolesBreaker(consumer, cable);

            return GetTreePolesBreaker(consumer, cable);
        }

        private BaseCircuitBreaker GetTreePolesBreaker(BaseConsumer consumer, BaseCable cable) {
            double consumerCurrent = consumer.RatedCurrent;
            double cableCurrent = cable.MaxCableCurrent;
            if (consumerCurrent < cableCurrent) {
                double key = GetKey(_breakerData._theePolesBreakerData, consumerCurrent);
                return _breakerData._theePolesBreakerData[key];
            }

            throw new DataException("GetTreePolesBreaker ошибка в обработке");
        }

        private BaseCircuitBreaker GetSinglePolesBreaker(BaseConsumer consumer, BaseCable cable) {
            double consumerCurrent = consumer.RatedCurrent;
            double cableCurrent = cable.MaxCableCurrent;
            if (consumerCurrent < cableCurrent) {
                double key = GetKey(_breakerData._singlePolesBreakerData, consumerCurrent);
                return _breakerData._singlePolesBreakerData[key];
            }

            throw new DataException("GetSinglePolesBreaker ошибка в обработке");
        }

        private double GetKey(Dictionary<double, BaseCircuitBreaker> somePolesBreakerData, double consumerCurrent) {
            double maxKey = 0;
            double maxValue = double.MaxValue;
            List<double> keys = new List<double>(somePolesBreakerData.Keys);
            for (int i = 0; i < keys.Count; i++) {
                double key = keys[i];
                double value = somePolesBreakerData[key].RatedCurrent;
                if (value > consumerCurrent && i < 2) {
                    maxKey = key;
                    maxValue = value;
                    break;
                }

                if (value > consumerCurrent && consumerCurrent > somePolesBreakerData[keys[i - 1]].RatedCurrent) {
                    maxKey = key;
                    maxValue = value;
                    break;
                }
            }

            return maxKey;
        }
    }
}