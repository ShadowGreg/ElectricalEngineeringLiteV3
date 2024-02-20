using System.Text;

namespace ElectricalEngineering.Domain.Feeder {
    public class BaseCable: DbDependence {
        /// <summary>
        ///     Материал кабеля медь или аллюминий
        /// </summary>
        public Material CableMaterial { get; set; }

        /// <summary>
        ///     Порядковый номер в шине - что бы при
        ///     восстановлении данных не менялся порядок приёмнтков
        /// </summary>
        /// TODO нужно ли это потому что в последующем включить все элементы в фидер
        public int SequentialNumber { get; set; } = 0;

        /// <summary>
        ///     Наименование кабеля - пока решение ручной ввод
        /// </summary>
        public string CableName { get; set; } = string.Empty;

        /// <summary>
        ///     Марка кабеля - пока вводится в ручную
        /// </summary>
        public string CableBrand { get; set; } = "ВВГнг-";

        /// <summary>
        ///     Число жил в кабеле
        /// </summary>
        public int CoresNumber { get; set; } = 2;

        /// <summary>
        ///     Сечение кабеля в соответствии с ГОСТ и каталогом производителя
        /// </summary>
        public double CableCrossSection { get; set; } = 2.5;

        /// <summary>
        ///     Потребное количество кабелей в фидере для питания потребителя
        /// </summary>
        public int NumberInFeeder { get; set; } = 1;

        /// <summary>
        ///     Длинна кабеля на участке в м
        /// </summary>
        public double CableLength { get; set; } = 5;

        /// <summary>
        ///     Потеря напряжения в кабеле по длине %
        /// </summary>
        public double CableVoltageLoss { get; set; } = 0.01;

        /// TODO добавить падение напряжения при пуске потребителя
        /// <summary>
        ///     Номинальный ток питания потребителя А
        /// </summary>
        public double CableCurrent { get; set; } = 0.01;

        /// <summary>
        ///     Максимальный допустимый ток в кабеле А при температуре ...
        /// </summary>
        public double MaxCableCurrent { get; set; } = 0.01;

        /// <summary>
        ///     Ток короткого замыкания кА
        /// </summary>
        public double ShortCircuitCurrent { get; set; } = 0.01;

        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) return false;

            return Equals(obj as BaseCable);
        }

        private bool Equals(BaseCable other) {
            if (other == null) return false;

            return ToString() == other.ToString();
        }

        public override int GetHashCode() {
            return ToString().GetHashCode();
        }

        public override string ToString() {
            var tempString = new StringBuilder();
            tempString.Append(" " + CableMaterial);
            tempString.Append(" " + SequentialNumber);
            tempString.Append(" " + CableName);
            tempString.Append(" " + CableBrand);
            tempString.Append(" " + CoresNumber);
            tempString.Append(" " + CableCrossSection);
            tempString.Append(" " + NumberInFeeder);
            tempString.Append(" " + CableLength);
            tempString.Append(" " + CableVoltageLoss);
            tempString.Append(" " + CableCurrent);
            tempString.Append(" " + MaxCableCurrent);
            tempString.Append(" " + ShortCircuitCurrent);

            return tempString.ToString();
        }
    }

    public enum Material {
        Copper,
        Aluminum
    }
}