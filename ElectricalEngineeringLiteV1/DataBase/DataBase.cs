using System.Collections.Generic;
using System.Collections.ObjectModel;
using CoreV01.Feeder;
using CoreV01.Properties;

namespace DataBase {
    public class DataBase: IReadWrite {
        private static List<BaseConsumer> _consumers;

        public DataBase() {
            _consumers = new List<BaseConsumer>() {
                new BaseConsumer() {
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
                new BaseConsumer() {
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
                new BaseConsumer() {
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
                new BaseConsumer() {
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
            };
        }

        public List<BaseConsumer> GetConsumers() {
            new DataBase();
            return _consumers;
        }
    }
}