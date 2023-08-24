namespace ElectricalEngineeringLiteV1.ViewModel.Util {
    public class Row {
        /// <summary>
        ///     Наименование ЭП
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        ///     Кол-во ЭП шт.n
        /// </summary>
        public int NumberOfReceivers { get; set; } = 0;

        /// <summary>
        ///     Номинальная (установленная) мощность, кВт одного ЭП рн
        /// </summary>
        public double RatedPower { get; set; } = 0;

        /// <summary>
        ///     Номинальная (установленная) мощность, кВт общая Рн =n*рн
        /// </summary>
        public double RatedPowerOfIdenticalElectricalReceivers { get; set; } = 0;

        /// <summary>
        ///     Коэф. использования Ки
        /// </summary>
        public double UtilizationFactor { get; set; } = 0;

        /// <summary>
        ///     Коэф. реактивной мощности cos f
        /// </summary>
        public double PowerFactor { get; set; } = 0;

        /// <summary>
        ///     Коэф. реактивной мощности tg f
        /// </summary>
        public double TangentPowerFactor { get; set; } = 0;

        /// <summary>
        ///     Ки*Рн
        /// </summary>
        public double ActiveAverageDesignPower { get; set; } = 0;

        /// <summary>
        ///     Ки*Рн*tgf
        /// </summary>
        public double ReactiveAverageRatedPower { get; set; } = 0;

        /// <summary>
        ///     рн**2*n
        /// </summary>
        public double SquareOfRatedPower { get; set; } = 0;

        /// <summary>
        ///     Эффективное число ЭП nэ
        /// </summary>
        public int EquivalentNumberOfElectricalReceivers { get; set; } = 0;


        /// <summary>
        ///     Коэф. расчетной нагрузки Кр
        /// </summary>
        public double DesignLoadFactor { get; set; } = 0;

        /// <summary>
        ///     Расчетная мощность кВт Рр
        /// </summary>
        public double ActiveRatedPower { get; set; } = 0;

        /// <summary>
        ///     Расчетная мощность кВАр Qp
        /// </summary>
        public double ReactiveRatedPower { get; set; } = 0;

        /// <summary>
        ///     Расчетная мощность кВА Sp
        /// </summary>
        public double TotalDesignPower { get; set; } = 0;

        /// <summary>
        ///     Расчетный ток, А Ip
        /// </summary>
        public double DesignBusbarCurrent { get; set; } = 0;
    }
}