using ElectricalEngineering.Domain;
using ElectricalEngineering.Domain.Feeder;

namespace ElectricalEngineering.Data.Data {
    public partial class FakeDataBase {
        public static List<BaseConsumer> Consumers = [
            #region Consumers

            new BaseConsumer {
                TechnologicalNumber = "030-Р-008A",
                MechanismName = "Насос Xylem, LOWARA",
                RatedElectricPower = 10,
                UsageFactor = 0.85,
                PowerFactor = 0.93,
                Voltage = 400,
                HoursWorkedPerYear = 8700,
                LocationEquipmentInstallation = "102",
                StartingCurrentMultiplicity = 11
            },

            new BaseConsumer {
                TechnologicalNumber = "030-Р-008B",
                MechanismName = "Насос Xylem, LOWARA",
                RatedElectricPower = 10,
                UsageFactor = 0.85,
                PowerFactor = 0.93,
                Voltage = 400,
                HoursWorkedPerYear = 8700,
                LocationEquipmentInstallation = "102",
                StartingCurrentMultiplicity = 10
            },

            new BaseConsumer {
                TechnologicalNumber = "030-Р-008С",
                MechanismName = "Насос Xylem, LOWARA",
                RatedElectricPower = 10,
                UsageFactor = 0.85,
                PowerFactor = 0.93,
                Voltage = 400,
                HoursWorkedPerYear = 8700,
                LocationEquipmentInstallation = "102",
                StartingCurrentMultiplicity = 7
            },

            new BaseConsumer {
                TechnologicalNumber = "030-Р-008D",
                MechanismName = "насос технологический",
                RatedElectricPower = 10,
                UsageFactor = 0.85,
                PowerFactor = 0.93,
                Voltage = 400,
                HoursWorkedPerYear = 8700,
                LocationEquipmentInstallation = "102",
                StartingCurrentMultiplicity = 1
            }

            #endregion
        ];

        public static List<BaseCable> Cables = [
            #region Cables

            new BaseCable {
                CableMaterial = Material.Copper,
                SequentialNumber = 1,
                CableName = "030-Р-008A-H1",
                CableBrand = "ВВГнг-",
                CoresNumber = 3,
                CableCrossSection = 35.0,
            },
            new BaseCable {
                CableMaterial = Material.Copper,
                SequentialNumber = 1,
                CableName = "030-Р-008B-H1",
                CableBrand = "ВВГнг-",
                CoresNumber = 3,
                CableCrossSection = 35.0,
            },
            new BaseCable {
                CableMaterial = Material.Copper,
                SequentialNumber = 1,
                CableName = "030-Р-008C-H1",
                CableBrand = "ВВГнг-",
                CoresNumber = 3,
                CableCrossSection = 35.0,
            },
            new BaseCable {
                CableMaterial = Material.Copper,
                SequentialNumber = 1,
                CableName = "030-Р-008D-H1",
                CableBrand = "ВВГнг-",
                CoresNumber = 3,
                CableCrossSection = 35.0,
            }

            #endregion
        ];

        public static List<BaseCircuitBreaker> CircuitBreakers = [
            #region CircuitBreakers

            new BaseCircuitBreaker {
                NameOnBus = "QF1",
            },
            new BaseCircuitBreaker {
                NameOnBus = "QF2",
            },
            new BaseCircuitBreaker {
                NameOnBus = "QF3",
            },
            new BaseCircuitBreaker {
                NameOnBus = "QF4",
            }

            #endregion
        ];

        public static List<BaseFeeder> BaseFeeders = [
            #region Feeders

            new BaseFeeder {
                CircuitBreaker = CircuitBreakers[0],
                Cable = Cables[0],
                Consumer = Consumers[0],
            },

            new BaseFeeder {
                CircuitBreaker = CircuitBreakers[1],
                Cable = Cables[1],
                Consumer = Consumers[1],
            },

            new BaseFeeder {
                CircuitBreaker = CircuitBreakers[2],
                Cable = Cables[2],
                Consumer = Consumers[2],
            },

            new BaseFeeder {
                CircuitBreaker = CircuitBreakers[3],
                Cable = Cables[3],
                Consumer = Consumers[3],
            }

            #endregion
        ];

        public static List<BaseBusbar> BusBars = [
            #region Busbars

            new BaseBusbar {
                BusbarName = "СШ1",
                Feeders = BaseFeeders
            }

            #endregion
        ];

        public static List<BaseElectricalPanel> ElectricalPanels = [
            #region ElectricalPanels

            new BaseElectricalPanel {
                BusBars = [BusBars[0]]
            }

            #endregion
        ];
    }
}