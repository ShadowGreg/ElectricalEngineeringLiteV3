using System.Collections.Generic;
using BillingFillingController.Contrlollers.BusBars;
using BillingFillingController.Contrlollers.Consumer;
using CoreV01.Feeder;
using NUnit.Framework;

namespace BackendTests {
    public class BusbarFillControllerTests {
        private ConsumerFillController _consumerFillController;
        private List<BaseConsumer> _consumers;

        [SetUp]
        public void Setup() {
            _consumers = new List<BaseConsumer> {
                new BaseConsumer {
                    TechnologicalNumber = "MXW-250-13C",
                    MechanismName = "насос технологический",
                    RatedElectricPower = 3.5,
                    PowerFactor = 0.85,
                    Voltage = 230,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 1
                },
                new BaseConsumer {
                    TechnologicalNumber = "MXW-250-13A",
                    MechanismName = "насос технологический",
                    RatedElectricPower = 13.5,
                    PowerFactor = 0.85,
                    Voltage = 400,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 1
                },
                new BaseConsumer {
                    TechnologicalNumber = "MXW-250-13D",
                    MechanismName = "насос технологический",
                    RatedElectricPower = 1.5,
                    PowerFactor = 0.85,
                    Voltage = 400,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 1
                },
                new BaseConsumer {
                    TechnologicalNumber = "MXW-250-13K",
                    MechanismName = "насос технологический",
                    RatedElectricPower = 30.5,
                    PowerFactor = 0.85,
                    Voltage = 400,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 1
                }
            };
            _consumerFillController = new ConsumerFillController();
            foreach (var consumer in _consumers) _consumerFillController.FillConsumerFields(consumer);
        }

        [Test]
        public void Checking_The_Functionality_Of_Adding_One_At_A_Time_Test() {
            // Arrange
            const double voltage = 400;
            var busbarFillController = new BusbarFillController(voltage);

            // Act
            foreach (var consumer in _consumers) busbarFillController.AddConsumerOnBus(consumer, 5);

            var fillingBusBar = busbarFillController.GetBusbar();

            // Assert
            Assert.NotNull(fillingBusBar);
        }

        [Test]
        public void Loading_The_Consumer_Data_Sheet_Test() {
            // Arrange
            const double voltage = 400;
            var busbarFillController = new BusbarFillController(voltage);

            // Act
            busbarFillController.AddConsumersListOnBus(_consumers);
            var fillingBusBar = busbarFillController.GetBusbar();

            // Assert
            Assert.NotNull(fillingBusBar);
        }

        [Test]
        public void Checking_The_Relevance_Of_The_Calculation_Test() {
            // Arrange
            var testConsumer = new BaseConsumer {
                TechnologicalNumber = "MXW-250-13C",
                MechanismName = "насос технологический",
                RatedElectricPower = 3.5,
                PowerFactor = 0.85,
                Voltage = 400,
                HoursWorkedPerYear = 8700,
                LocationEquipmentInstallation = "102",
                StartingCurrentMultiplicity = 1
            };
            _consumerFillController.FillConsumerFields(testConsumer);
            const double voltage = 400;
            var busbarFillController = new BusbarFillController(voltage);
            double expectedSwitchCurrent = 63.0d;

            // Act
            for (int i = 0; i < 10; i++) busbarFillController.AddConsumerOnBus(testConsumer, 5);

            var fillingBusBar = busbarFillController.GetBusbar();
            double actualSwitchCurrent = fillingBusBar.InputSwitch.RatedCurrent;

            // Assert
            Assert.AreEqual(expectedSwitchCurrent, actualSwitchCurrent);
        }

        [Test]
        public void Checking_Removing_The_Electrical_Receiver_From_The_Bus_Test() {
            // Arrange
            const double voltage = 400;
            var busbarFillController = new BusbarFillController(voltage);
            _consumerFillController.FillConsumerFields(_consumers[0]);
            const int expectedFeedersNum = 3;


            // Act
            foreach (var consumer in _consumers) busbarFillController.AddConsumerOnBus(consumer, 5);

            busbarFillController.DelConsumerOnBus(_consumers[0]);
            var newBusBar = busbarFillController.GetBusbar();
            int actualFeederNum = newBusBar.Feeders.Count;

            // Assert
            Assert.AreEqual(expectedFeedersNum, actualFeederNum);
        }
    }
}