using System.Text;

namespace ElectricalEngineering.Domain.Feeder {
    public class BaseConsumer: DbDependence {
        /// <summary>
        ///     1 Технологический номер оборудования
        /// </summary>
        public string TechnologicalNumber { get; set; } = "";

        /// <summary>
        ///     2 Наименование механизма
        /// </summary>
        public string MechanismName { get; set; } = "";

        /// <summary>
        ///     3 Тип оборудования для расчёта токов в кабеле
        ///     TODO далее можно усложнить расчёт на базе этого элемента для автоподборки коэффициентов
        /// </summary>
        public ConsumerType LoadType { get; set; } = ConsumerType.Technological;


        /// <summary>
        ///     4 Коэффициент (кратность) пускового тока
        /// </summary>
        public double StartingCurrentMultiplicity { get; set; } = 1;

        /// <summary>
        ///     5 Номинальная электрическая мощность кВт
        /// </summary>
        public double RatedElectricPower { get; set; } = 0.1;

        /// <summary>
        ///     6 Коэффициент использования
        /// </summary>
        public double UsageFactor { get; set; } = 0.85;

        /// <summary>
        ///     7 Коэффициент мощности косинус фи
        /// </summary>
        public double PowerFactor { get; set; } = 0.85;

        /// <summary>
        ///     8 Коэффициент мощности тангенс фи
        /// </summary>
        public double TanPowerFactor { get; set; } = 0.01;

        /// <summary>
        ///     9 Коэффициент полезного действия КПД
        /// </summary>
        public double EfficiencyFactor { get; set; } = 0.8;

        /// <summary>
        ///     10 Тип системы заземления TN-C-S
        /// </summary>
        public string TypeGroundingSystem { get; set; } = "TN-C-S";

        /// <summary>
        ///     11 Напряжение В
        /// </summary>
        public double Voltage { get; set; } = 400;

        /// <summary>
        ///     12 Количество фаз
        /// </summary>
        public int PhaseNumber { get; set; } = 3;

        /// <summary>
        ///     13 Количество электроприёмников
        /// </summary>
        public int NumberElectricalReceivers { get; set; } = 1;

        /// <summary>
        ///     14 Количество часов работы в год
        /// </summary>
        public int HoursWorkedPerYear { get; set; } = 1;

        /// <summary>
        ///     15 Номер помещения (оборудования) по генплну в котором расположено оборудование
        /// </summary>
        public string LocationEquipmentInstallation { get; set; } = "";

        /// <summary>
        ///     16 Классификация помещняи по взрыво-,пожароопасности зон
        /// </summary>
        public string ClassificationEquipmentInstallation { get; set; } = "";

        /// <summary>
        ///     17 Квадрат номинальной мощности
        /// </summary>
        public double RatedPowerSquared { get; set; } = 1;

        /// <summary>
        ///     18 Реактивная мощность
        /// </summary>
        public double ReactivePower { get; set; } = 1;

        /// <summary>
        ///     19 Номинальный ток
        /// </summary>
        public double RatedCurrent { get; set; } = 1;

        /// <summary>
        ///     20 Пусковой ток
        /// </summary>
        public double StartingCurrent { get; set; } = 1;

        public override bool Equals(object other) {
            var toCompare = other as BaseConsumer;
            if (toCompare == null) return false;
            const double TOLERANCE = 0.001;
            var nonMatchingFields = new StringBuilder();

            if (TechnologicalNumber != toCompare.TechnologicalNumber)
                nonMatchingFields.AppendLine(
                    $"TechnologicalNumber: {TechnologicalNumber} != {toCompare.TechnologicalNumber}");
            if (MechanismName != toCompare.MechanismName)
                nonMatchingFields.AppendLine($"MechanismName: {MechanismName} != {toCompare.MechanismName}");
            if (LoadType != toCompare.LoadType)
                nonMatchingFields.AppendLine($"LoadType: {LoadType} != {toCompare.LoadType}");
            if (Math.Abs(StartingCurrentMultiplicity - toCompare.StartingCurrentMultiplicity) >= TOLERANCE)
                nonMatchingFields.AppendLine(
                    $"StartingCurrentMultiplicity: {StartingCurrentMultiplicity} != {toCompare.StartingCurrentMultiplicity}");
            if (Math.Abs(RatedElectricPower - toCompare.RatedElectricPower) >= TOLERANCE)
                nonMatchingFields.AppendLine(
                    $"RatedElectricPower: {RatedElectricPower} != {toCompare.RatedElectricPower}");
            if (Math.Abs(UsageFactor - toCompare.UsageFactor) >= TOLERANCE)
                nonMatchingFields.AppendLine($"UsageFactor: {UsageFactor} != {toCompare.UsageFactor}");
            if (Math.Abs(PowerFactor - toCompare.PowerFactor) >= TOLERANCE)
                nonMatchingFields.AppendLine($"PowerFactor: {PowerFactor} != {toCompare.PowerFactor}");
            if (Math.Abs(TanPowerFactor - toCompare.TanPowerFactor) >= TOLERANCE)
                nonMatchingFields.AppendLine($"TanPowerFactor: {TanPowerFactor} != {toCompare.TanPowerFactor}");
            if (Math.Abs(EfficiencyFactor - toCompare.EfficiencyFactor) >= TOLERANCE)
                nonMatchingFields.AppendLine($"EfficiencyFactor: {EfficiencyFactor} != {toCompare.EfficiencyFactor}");
            if (TypeGroundingSystem != toCompare.TypeGroundingSystem)
                nonMatchingFields.AppendLine(
                    $"TypeGroundingSystem: {TypeGroundingSystem} != {toCompare.TypeGroundingSystem}");
            if (Math.Abs(Voltage - toCompare.Voltage) >= TOLERANCE)
                nonMatchingFields.AppendLine($"Voltage: {Voltage} != {toCompare.Voltage}");
            if (PhaseNumber != toCompare.PhaseNumber)
                nonMatchingFields.AppendLine($"PhaseNumber: {PhaseNumber} != {toCompare.PhaseNumber}");
            if (NumberElectricalReceivers != toCompare.NumberElectricalReceivers)
                nonMatchingFields.AppendLine(
                    $"NumberElectricalReceivers: {NumberElectricalReceivers} != {toCompare.NumberElectricalReceivers}");
            if (HoursWorkedPerYear != toCompare.HoursWorkedPerYear)
                nonMatchingFields.AppendLine(
                    $"HoursWorkedPerYear: {HoursWorkedPerYear} != {toCompare.HoursWorkedPerYear}");
            if (LocationEquipmentInstallation != toCompare.LocationEquipmentInstallation)
                nonMatchingFields.AppendLine(
                    $"LocationEquipmentInstallation: {LocationEquipmentInstallation} != {toCompare.LocationEquipmentInstallation}");
            if (ClassificationEquipmentInstallation != toCompare.ClassificationEquipmentInstallation)
                nonMatchingFields.AppendLine(
                    $"ClassificationEquipmentInstallation: {ClassificationEquipmentInstallation} != {toCompare.ClassificationEquipmentInstallation}");
            if (Math.Abs(RatedPowerSquared - toCompare.RatedPowerSquared) >= TOLERANCE)
                nonMatchingFields.AppendLine(
                    $"RatedPowerSquared: {RatedPowerSquared} != {toCompare.RatedPowerSquared}");
            if (Math.Abs(ReactivePower - toCompare.ReactivePower) >= TOLERANCE)
                nonMatchingFields.AppendLine($"ReactivePower: {ReactivePower} != {toCompare.ReactivePower}");
            if (Math.Abs(RatedCurrent - toCompare.RatedCurrent) >= TOLERANCE)
                nonMatchingFields.AppendLine($"RatedCurrent: {RatedCurrent} != {toCompare.RatedCurrent}");
            if (Math.Abs(StartingCurrent - toCompare.StartingCurrent) >= TOLERANCE)
                nonMatchingFields.AppendLine($"StartingCurrent: {StartingCurrent} != {toCompare.StartingCurrent}");

            if (nonMatchingFields.Length > 0) Console.WriteLine($"Fields do not match:\n{nonMatchingFields}");

            return true;
        }

        ///TODO дописать методы сравнения - для реализации поиска и удаления потребителя из массива потребителей
        
    }

    public enum ConsumerType {
        Technological,
        Sanitary,
        Lighting,
        Heating,
        ElectricHeating,
        Other,
        Reserve,
        ReactivePowerCompensation
    }
}