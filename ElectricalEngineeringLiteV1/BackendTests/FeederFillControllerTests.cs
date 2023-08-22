using System.Collections.Generic;
using BillingFillingController.Contrlollers.Consumer;
using BillingFillingController.Contrlollers.Feeder;
using CoreV01.Feeder;
using NUnit.Framework;

namespace BackendTests {
    [TestFixture]
    public class FeederFillControllerTests {
        private List<BaseConsumer> _consumers;
        private ConsumerFillController _consumerFillController;

        [SetUp]
        public void Setup() {
            _consumers = new DataBase.DataBase().GetConsumers();
            _consumerFillController = new ConsumerFillController();
            foreach (var consumer in _consumers) {
                _consumerFillController.FillConsumerFields(consumer);
            }
        }

        [Test]
        public void FeederFillController_Test() {
            // Arrange
            FeederFillController controller = new FeederFillController(_consumers[0]);

            // Act
            var feeder = controller.GetFeeder(1, 2.3, 20);

            // Assert
            Assert.NotNull(feeder);
        }

        [Test]
        public void On_A_Single_Phase_Electric_Receiver_Test() {
            // Arrange
            BaseConsumer testConsumer = new BaseConsumer() {
                TechnologicalNumber = "MXW-250-13C",
                MechanismName = "насос технологический",
                RatedElectricPower = 3.5,
                PowerFactor = 0.85,
                Voltage = 230,
                HoursWorkedPerYear = 8700,
                LocationEquipmentInstallation = "102",
                StartingCurrentMultiplicity = 1
            };
            BaseCable expectedCable = new BaseCable() { };
            FeederFillController controller = new FeederFillController(testConsumer);

            // Act
            var feeder = controller.GetFeeder(1, 2.3, 20);

            // Assert
            Assert.NotNull(feeder);
        }
    }
}