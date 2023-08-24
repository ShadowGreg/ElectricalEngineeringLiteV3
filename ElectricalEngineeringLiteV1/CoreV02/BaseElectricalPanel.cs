using System.Collections.Generic;
using CoreV01.Feeder;

namespace CoreV01.Properties {
    public class BaseElectricalPanel: BaseConsumer {
        /// <summary>
        ///     Шины в электрощите
        /// </summary>
        public List<BaseBusbar> BusBars { get; set; }

        /// <summary>
        ///     Число электро приёмников установленных в щите
        /// </summary>
        public double NumberOfElectricalReceiversInstalledInTheSwitchboard { get; set; } = 1;

        /// <summary>
        ///     Установленная электрическая мощность щита
        /// </summary>
        public double InstalledElectricalPowerOfTheSwitchboard { get; set; } = 1;

        /// <summary>
        ///     Коэффициент использования щита
        /// </summary>
        public double ShieldUtilizationFactor { get; set; } = 1;

        /// <summary>
        ///     Коэффициент мощности щита
        /// </summary>
        public double ShieldPowerFactor { get; set; } = 1;

        /// <summary>
        ///     Средняя расчётная активная мощность
        /// </summary>
        public double AverageRatedActivePower { get; set; } = 1;

        /// <summary>
        ///     Средняя расчётная реактивная мощность
        /// </summary>
        public double AverageDesignReactivePower { get; set; } = 1;

        /// <summary>
        ///     Квадрат номинальной мощности щита
        /// </summary>
        public double SquareOfTheRatedPowerOfThePanel { get; set; } = 1;

        /// <summary>
        ///     Эквивалентное число электро приёмников щита
        /// </summary>
        public double EquivalentNumberOfElectricalReceiversOfTheShield { get; set; } = 1;

        /// <summary>
        ///     Коэффициент расчётной нагрузки
        /// </summary>
        public double DesignLoadFactor { get; set; } = 1;

        /// <summary>
        ///     Активная мощность щита
        /// </summary>
        public double ShieldActivePower { get; set; } = 1;

        /// <summary>
        ///     Реактивная мощность щита
        /// </summary>
        public double ReactivePowerOfThePanel { get; set; } = 1;

        /// <summary>
        ///     Полная мощность щита
        /// </summary>
        public double TotalPower { get; set; } = 1;

        /// <summary>
        ///     Расчётный ток щита
        /// </summary>
        public double RatedCurrent { get; set; } = 1;
    }
}