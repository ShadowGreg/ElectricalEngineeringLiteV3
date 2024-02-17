using System;
using BillingFillingController.Calculators;
using ElectricalEngineering.Domain.Feeder;

namespace BillingFillingController.Contrlollers.Consumer {
    public class ConsumerFillController {
        private readonly ConsumerCalculator _calculator;

        public ConsumerFillController() {
            _calculator = new ConsumerCalculator();
        }

        /// <summary>
        ///     Обработка подаваемого в метод потребителя - меняются поля внутри
        /// </summary>
        /// <param name="сonsumer">Подаётся объект типа BaseConsumer</param>
        /// <exception cref="FormatException">Пока исключение маленькое по обработке других систем заземления</exception>
        public void FillConsumerFields(BaseConsumer сonsumer) {
            if (сonsumer.TypeGroundingSystem.Contains("TN")) {
                сonsumer.PhaseNumber = PhaseNumber(сonsumer.Voltage);
                сonsumer.TanPowerFactor = _calculator.GetTanPowerFactor(сonsumer.PowerFactor);
                сonsumer.RatedPowerSquared = _calculator.GetRatedPowerSquared(сonsumer.RatedElectricPower);
                сonsumer.ReactivePower = _calculator.GetReactivePower(сonsumer);
                сonsumer.RatedCurrent = _calculator.GetRatedCurrent(сonsumer);
                сonsumer.StartingCurrent = _calculator.StartingCurrent(сonsumer);
            }
            else {
                throw new FormatException("Не рализована система заземления IT");
            }
        }

        private int PhaseNumber(double сonsumerVoltage) {
            return сonsumerVoltage < 380 ? 1 : 3;
        }
    }
}