namespace ElectricalEngineering.DomainServices.Contrlollers.Cable {
    public class CableResistanceCharacteristics {
        /// <summary>
        ///     Активное сопротивление Ro ом/км
        /// </summary>
        public double R0 { get; set; }

        /// <summary>
        ///     Внутренее индуктивное сопротивление X три жилы ом/км
        /// </summary>
        public double X03 { get; set; }

        /// <summary>
        ///     Внутренее индуктивное сопротивление X четыре жилы ом/км
        /// </summary>
        public double X04 { get; set; }

        /// <summary>
        ///     Активное сопротивление Ro петли фаза нуль ом/км
        /// </summary>
        public double R0Loop { get; set; }
    }
}