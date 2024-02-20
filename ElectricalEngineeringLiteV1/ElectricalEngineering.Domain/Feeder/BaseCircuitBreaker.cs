namespace ElectricalEngineering.Domain.Feeder {
    public class BaseCircuitBreaker: DbDependence {
        private string _nameOnBus = "QF";

        /// <summary>
        ///     Наименование автомата на шине
        /// </summary>
        public string NameOnBus
        {
            get => _nameOnBus;
            set
            {
                if (value == string.Empty) return;
                _nameOnBus = value;
                Name = value;
            }
        }

        /// <summary>
        ///     Тип автоматического выключателя по каталогу производителя
        /// </summary>
        public string Type { get; set; } = "АВ";

        /// <summary>
        ///     Габарит автомтаического выключателя
        /// </summary>
        public string Dimensions { get; set; } = "160";

        /// <summary>
        ///     Кривая срабатывания автоматического выключателя
        /// </summary>
        public string ResponseCurve { get; set; } = "C";

        /// <summary>
        ///     Номинальный ток автоматического выключателя
        /// </summary>
        public double RatedCurrent { get; set; } = 1;

        /// <summary>
        ///     Число полюсов автоматического выключателя
        /// </summary>
        public int NumberPoles { get; set; } = 3;

        /// <summary>
        ///     Коммутационная способность автоматического выключателя кА
        /// </summary>
        public double SwitchingCapacity { get; set; } = 4.5;
    }
}