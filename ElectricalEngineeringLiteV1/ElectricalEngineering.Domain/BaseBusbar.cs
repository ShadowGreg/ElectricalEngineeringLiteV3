using ElectricalEngineering.Domain.Feeder;

namespace ElectricalEngineering.Domain {
    public class BaseBusbar: DbDependence {
        /// <summary>
        ///     Наименование шины
        /// </summary>
        public string BusbarName { get; set; }

        /// <summary>
        ///     Мощность оборудования  установленная на секцию шин кВт
        /// </summary>
        public double InstalledCapacity { get; set; } = 0;

        /// <summary>
        ///     Расчётная мощность оборудования установленного на секцию шин кВт
        /// </summary>
        public double RatedCapacity { get; set; } = 0;

        /// <summary>
        ///     Коэффициент мощности шины
        /// </summary>
        public double PowerFactor { get; set; } = 0;

        /// <summary>
        ///     Расчётный ток на шине
        /// </summary>
        public double RatedCurrent { get; set; } = 0;

        /// <summary>
        ///     Ток короткого замыкания на секции шин
        /// </summary>
        public double ShortCircuitCurrent { get; set; } = 0;

        /// <summary>
        ///     Ввводной выключатель
        /// </summary>
        public BaseCircuitBreaker InputSwitch { get; set; }

        /// <summary>
        ///     Ток в аварийном режиме на вводном выключателе
        /// </summary>
        public double EmergencyСurrentInputSwitch { get; set; } = 0;

        /// <summary>
        ///     Секционный выключатель
        /// </summary>
        public BaseCircuitBreaker SectionalCircuitBreaker { get; set; }

        /// <summary>
        ///     Ток в аварийном режиме на секционном выключателе
        /// </summary>
        public double EmergencyСurrentSectionalSwitch { get; set; } = 0;

        /// <summary>
        ///     Фидеры на секции
        /// </summary>
        public List<BaseFeeder> Feeders { get; set; }
    }
}