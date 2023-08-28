using NUnit.Framework;
using System.IO;
using DataBaseSL01.ReadWrite.Write;
using CoreV01.Feeder;

namespace DataBaseSL01.Tests {
    [TestFixture]
    public class ConsumerControllerTests {
        private ConsumerController _consumerController;
        private string _databaseFile;
        private static SqLiteHelper helper;

        [SetUp]
        public void Setup() {
            _databaseFile = "testBD.db";
            helper = new SqLiteHelper(_databaseFile);
            _consumerController = new ConsumerController(_databaseFile);
        }

        [Test]
        public void WriteConsumer_ShouldInsertConsumerIntoDatabase() {
            // Arrange
            BaseConsumer consumer = new BaseConsumer() {
                TechnologicalNumber = "123",
                MechanismName = "Test Mechanism",
                LoadType = ConsumerType.Heating,
                StartingCurrentMultiplicity = 1.5,
                RatedElectricPower = 100,
                UsageFactor = 0.8,
                PowerFactor = 0.9,
                TanPowerFactor = 0.95,
                EfficiencyFactor = 0.85,
                TypeGroundingSystem = "Grounding",
                Voltage = 220,
                PhaseNumber = 3,
                NumberElectricalReceivers = 10,
                HoursWorkedPerYear = 2000,
                LocationEquipmentInstallation = "Location",
                ClassificationEquipmentInstallation = "Classification",
                RatedPowerSquared = 10000,
                ReactivePower = 500,
                RatedCurrent = 50,
                StartingCurrent = 60
            };

            // Act
            _consumerController.WriteConsumer(consumer);

            // Assert
            BaseConsumer retrievedConsumer = _consumerController.ReadConsumer(consumer.SelfId);
            Assert.IsNotNull(retrievedConsumer);
            Assert.AreEqual(consumer.TechnologicalNumber, retrievedConsumer.TechnologicalNumber);
            Assert.AreEqual(consumer.MechanismName, retrievedConsumer.MechanismName);
            Assert.AreEqual(consumer.LoadType, retrievedConsumer.LoadType);
            Assert.AreEqual(consumer.StartingCurrentMultiplicity, retrievedConsumer.StartingCurrentMultiplicity);
            Assert.AreEqual(consumer.RatedElectricPower, retrievedConsumer.RatedElectricPower);
            Assert.AreEqual(consumer.UsageFactor, retrievedConsumer.UsageFactor);
            Assert.AreEqual(consumer.PowerFactor, retrievedConsumer.PowerFactor);
            Assert.AreEqual(consumer.TanPowerFactor, retrievedConsumer.TanPowerFactor);
            Assert.AreEqual(consumer.EfficiencyFactor, retrievedConsumer.EfficiencyFactor);
            Assert.AreEqual(consumer.TypeGroundingSystem, retrievedConsumer.TypeGroundingSystem);
            Assert.AreEqual(consumer.Voltage, retrievedConsumer.Voltage);
            Assert.AreEqual(consumer.PhaseNumber, retrievedConsumer.PhaseNumber);
            Assert.AreEqual(consumer.NumberElectricalReceivers, retrievedConsumer.NumberElectricalReceivers);
            Assert.AreEqual(consumer.HoursWorkedPerYear, retrievedConsumer.HoursWorkedPerYear);
            Assert.AreEqual(consumer.LocationEquipmentInstallation, retrievedConsumer.LocationEquipmentInstallation);
            Assert.AreEqual(consumer.ClassificationEquipmentInstallation,
                retrievedConsumer.ClassificationEquipmentInstallation);
            Assert.AreEqual(consumer.RatedPowerSquared, retrievedConsumer.RatedPowerSquared);
            Assert.AreEqual(consumer.ReactivePower, retrievedConsumer.ReactivePower);
            Assert.AreEqual(consumer.RatedCurrent, retrievedConsumer.RatedCurrent);
            Assert.AreEqual(consumer.StartingCurrent, retrievedConsumer.StartingCurrent);
        }

        [Test]
        public void UpdateConsumer_ShouldInsertConsumerIntoDatabase() {
            // Arrange
            BaseConsumer consumer = new BaseConsumer() {
                TechnologicalNumber = "123",
                MechanismName = "Test Mechanism",
                LoadType = ConsumerType.Heating,
                StartingCurrentMultiplicity = 1.5,
                RatedElectricPower = 100,
                UsageFactor = 0.8,
                PowerFactor = 0.9,
                TanPowerFactor = 0.95,
                EfficiencyFactor = 0.85,
                TypeGroundingSystem = "Grounding",
                Voltage = 220,
                PhaseNumber = 3,
                NumberElectricalReceivers = 10,
                HoursWorkedPerYear = 2000,
                LocationEquipmentInstallation = "Location",
                ClassificationEquipmentInstallation = "Classification",
                RatedPowerSquared = 10000,
                ReactivePower = 500,
                RatedCurrent = 50,
                StartingCurrent = 60
            };

            // Act
            _consumerController.WriteConsumer(consumer);
            consumer.Voltage = 400;
            _consumerController.WriteConsumer(consumer);

            // Assert
            BaseConsumer retrievedConsumer = _consumerController.ReadConsumer(consumer.SelfId);
            Assert.IsNotNull(retrievedConsumer);
            Assert.AreEqual(consumer.TechnologicalNumber, retrievedConsumer.TechnologicalNumber);
            Assert.AreEqual(consumer.MechanismName, retrievedConsumer.MechanismName);
            Assert.AreEqual(consumer.LoadType, retrievedConsumer.LoadType);
            Assert.AreEqual(consumer.StartingCurrentMultiplicity, retrievedConsumer.StartingCurrentMultiplicity);
            Assert.AreEqual(consumer.RatedElectricPower, retrievedConsumer.RatedElectricPower);
            Assert.AreEqual(consumer.UsageFactor, retrievedConsumer.UsageFactor);
            Assert.AreEqual(consumer.PowerFactor, retrievedConsumer.PowerFactor);
            Assert.AreEqual(consumer.TanPowerFactor, retrievedConsumer.TanPowerFactor);
            Assert.AreEqual(consumer.EfficiencyFactor, retrievedConsumer.EfficiencyFactor);
            Assert.AreEqual(consumer.TypeGroundingSystem, retrievedConsumer.TypeGroundingSystem);
            Assert.AreEqual(consumer.Voltage, retrievedConsumer.Voltage);
            Assert.AreEqual(consumer.PhaseNumber, retrievedConsumer.PhaseNumber);
            Assert.AreEqual(consumer.NumberElectricalReceivers, retrievedConsumer.NumberElectricalReceivers);
            Assert.AreEqual(consumer.HoursWorkedPerYear, retrievedConsumer.HoursWorkedPerYear);
            Assert.AreEqual(consumer.LocationEquipmentInstallation, retrievedConsumer.LocationEquipmentInstallation);
            Assert.AreEqual(consumer.ClassificationEquipmentInstallation,
                retrievedConsumer.ClassificationEquipmentInstallation);
            Assert.AreEqual(consumer.RatedPowerSquared, retrievedConsumer.RatedPowerSquared);
            Assert.AreEqual(consumer.ReactivePower, retrievedConsumer.ReactivePower);
            Assert.AreEqual(consumer.RatedCurrent, retrievedConsumer.RatedCurrent);
            Assert.AreEqual(consumer.StartingCurrent, retrievedConsumer.StartingCurrent);
        }
    }
}