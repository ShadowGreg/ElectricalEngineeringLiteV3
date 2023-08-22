using System;
using System.Collections.Generic;
using System.Linq;
using CoreV01.Feeder;

namespace BillingFillingController.Calculators {
    public class RMTCalculation {
        private List<BaseConsumer> _consumers;

        /// <summary>
        /// Физическое число электроприёмников
        /// </summary>
        public int NumberOfReceivers { get; set; } = 0;

        /// <summary>
        /// номинальная мощность
        /// </summary>
        public double RatedPower { get; private set; } = 0;

        /// <summary>
        /// номинальная мощность одинаковых электро приёмников
        /// </summary>
        public double RatedPowerOfIdenticalElectricalReceivers { get; private set; } = 0;

        /// <summary>
        /// коэффициент использования шины
        /// </summary>
        public double BusUtilizationFactor { get; private set; } = 0;

        /// <summary>
        /// коэффициента мощности шины
        /// </summary>
        public double BusPowerFactor { get; private set; } = 0;

        /// <summary>
        /// Тангенс коэффициента мощности шины
        /// </summary>
        public double TangentOfBusPowerFactor { get; private set; } = 0;

        /// <summary>
        /// активная средняя расчётная мощность
        /// </summary>
        public double ActiveAverageDesignPower { get; private set; } = 0;

        /// <summary>
        /// реактивная средняя расчётная мощность 
        /// </summary>
        public double ReactiveAverageRatedPower { get; private set; } = 0;

        /// <summary>
        /// Эквивалентное число электро приёмников на шине
        /// </summary>
        public int EquivalentNumberOfElectricalReceivers { get; private set; } = 0;

        /// <summary>
        /// квадрат номинальной мощности 
        /// </summary>
        public double SquareOfRatedPower { get; private set; } = 0;

        /// <summary>
        /// коэффициент расчётной нагрузки
        /// </summary>
        public double DesignLoadFactor { get; private set; } = 0;

        /// <summary>
        /// активная расчётная мощность шины
        /// </summary>
        public double ActiveRatedPowerOfTheBus { get; private set; } = 0;

        /// <summary>
        /// реактивная расчётная мощность шины 
        /// </summary>
        public double ReactiveRatedPowerOfTheBus { get; private set; } = 0;

        /// <summary>
        /// полная расчётная мощность шины 
        /// </summary>
        public double TotalDesignPowerOfTheBus { get; private set; } = 0;

        /// <summary>
        /// Расчётный ток на шине
        /// </summary>
        public double DesignBusbarCurrent { get; private set; } = 0;

        public double GetInstallCapacity(List<BaseConsumer> consumers, double voltage) {
            _consumers = consumers;
            NumberOfReceivers = consumers.Count;
            RatedPower = 0;
            foreach (var VARIABLE in consumers) {
                RatedPower += VARIABLE.RatedElectricPower;
            }

            RatedPowerOfIdenticalElectricalReceivers = 0;
            foreach (var VARIABLE in consumers) {
                RatedPowerOfIdenticalElectricalReceivers += VARIABLE.RatedElectricPower;
            }

            BusUtilizationFactor = consumers.Sum(consumer => consumer.UsageFactor * consumer.RatedElectricPower) /
                                   consumers.Sum(consumer => consumer.RatedElectricPower);
            ActiveAverageDesignPower = consumers.Sum(consumer => consumer.UsageFactor * consumer.RatedElectricPower);
            ReactiveAverageRatedPower = consumers.Sum(consumer =>
                consumer.UsageFactor * consumer.RatedElectricPower * consumer.TanPowerFactor);
            SquareOfRatedPower = consumers.Sum(consumer => Math.Pow(consumer.RatedElectricPower, 2));
            EquivalentNumberOfElectricalReceivers = GetEquivalentNumberOfElectricalReceivers();
            DesignLoadFactor = GetDesignLoadFactor(EquivalentNumberOfElectricalReceivers, BusUtilizationFactor);
            ActiveRatedPowerOfTheBus = GetActiveRatedPowerOfTheBus();
            ReactiveRatedPowerOfTheBus = GetReactiveRatedPowerOfTheBus();
            TotalDesignPowerOfTheBus = Math.Sqrt(ActiveRatedPowerOfTheBus * ActiveRatedPowerOfTheBus +
                                                 ReactiveRatedPowerOfTheBus * ReactiveRatedPowerOfTheBus);

            TangentOfBusPowerFactor = ReactiveRatedPowerOfTheBus / ActiveRatedPowerOfTheBus;
            BusPowerFactor = Math.Cos(Math.Atan(TangentOfBusPowerFactor));
            DesignBusbarCurrent = TotalDesignPowerOfTheBus / Math.Sqrt(3) / voltage * 1000;
            return consumers.Sum(consumer => consumer.NumberElectricalReceivers * consumer.RatedElectricPower);
        }

        private double GetReactiveRatedPowerOfTheBus() {
            double sum = _consumers.Sum(consumer =>
                consumer.RatedElectricPower * consumer.UsageFactor * consumer.TanPowerFactor);
            if (EquivalentNumberOfElectricalReceivers <= 10) {
                return 1.1 * sum;
            }

            return sum;
        }

        private double GetActiveRatedPowerOfTheBus() {
            double maxPower = _consumers.Max(consumer => consumer.RatedElectricPower);
            double sumPower = DesignLoadFactor *
                              _consumers.Sum(consumer => consumer.UsageFactor * consumer.RatedElectricPower);
            return maxPower > sumPower ? maxPower : sumPower;
        }

        private double GetDesignLoadFactor(int equivalentNumberOfElectricalReceivers, double busUtilizationFactor) {
            return new DesignLoadFactorData().GetData(equivalentNumberOfElectricalReceivers, busUtilizationFactor);
        }


        private int GetEquivalentNumberOfElectricalReceivers() {
            double temp = Math.Pow(_consumers.Sum(consumer => consumer.RatedElectricPower), 2) /
                          SquareOfRatedPower;
            if (temp < 0) {
                return 1;
            }

            return (int)Math.Floor(temp);
        }
    }
}