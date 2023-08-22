using CoreV01.Properties;

namespace CoreV01.Feeder {
    public class BaseCircuitBreaker: DBDependence {
        /// <summary>
        /// Наименование автомата на шине 
        /// </summary>
        public string NameOnBus { get; set; } = "QF";

        /// <summary>
        /// Тип автоматического выключателя по каталогу производителя
        /// </summary>
        public string Type { get; set; } = "АВ";

        /// <summary>
        /// Габарит автомтаического выключателя
        /// </summary>
        public string Dimensions { get; set; } = "160";

        /// <summary>
        /// Кривая срабатывания автоматического выключателя
        /// </summary>
        public string ResponseCurve { get; set; } = "C";

        /// <summary>
        /// Номинальный ток автоматического выключателя
        /// </summary>
        public double RatedCurrent { get; set; } = 1;

        /// <summary>
        /// Число полюсов автоматического выключателя
        /// </summary>
        public int NumberPoles { get; set; } = 3;

        /// <summary>
        /// Коммутационная способность автоматического выключателя кА
        /// </summary>
        public double SwitchingCapacity { get; set; } = 4.5;
    }
}