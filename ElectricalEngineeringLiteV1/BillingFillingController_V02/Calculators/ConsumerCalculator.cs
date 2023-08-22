using System;
using CoreV01.Feeder;

namespace BillingFillingController.Calculators {
    public class ConsumerCalculator {
        public void Fill(BaseConsumer consumer) {
            if (consumer.TypeGroundingSystem.Contains("TN")) { }

            throw new FormatException("Не рализована система заземления IT");
        }

        public double GetTanPowerFactor(double сonsumerPowerFactor) {
            return Math.Atan(Math.Sqrt(1 - Math.Pow(сonsumerPowerFactor, 2)) / сonsumerPowerFactor);
        }

        public double GetRatedPowerSquared(double сonsumerRatedElectricPower) {
            return сonsumerRatedElectricPower * сonsumerRatedElectricPower;
        }

        public double GetReactivePower(BaseConsumer сonsumer) {
            return сonsumer.RatedElectricPower * сonsumer.TanPowerFactor;
        }

        public double GetRatedCurrent(BaseConsumer сonsumer) {
            switch (сonsumer.PhaseNumber) {
                case 1:
                    return сonsumer.RatedElectricPower * 1000 / сonsumer.Voltage / сonsumer.PowerFactor;
                case 3:
                    return сonsumer.RatedElectricPower * 1000 / сonsumer.Voltage / сonsumer.PowerFactor / Math.Sqrt(3);
            }

            throw new Exception("GetRatedCurrent даёт ошибку");
        }

        public double StartingCurrent(BaseConsumer сonsumer) {
            return сonsumer.RatedCurrent * сonsumer.StartingCurrentMultiplicity;
        }
    }
}