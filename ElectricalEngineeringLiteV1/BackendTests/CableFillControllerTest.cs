﻿using System.Collections.Generic;
using BillingFillingController.Contrlollers;
using BillingFillingController.Contrlollers.Cable;
using BillingFillingController.Contrlollers.Consumer;
using CoreV01.Feeder;
using NUnit.Framework;

namespace BackendTests {
    [TestFixture]
    public class CableFillControllerTest {
        private BaseConsumer _consumer;
        private ConsumerFillController _consumerFillController;
        private CableFillController _cableFillController;
        private BaseCable expectedBaseCable;

        [SetUp]
        public void Setup() {
            _consumerFillController = new ConsumerFillController();
            expectedBaseCable = new BaseCable() {
                CableMaterial = Material.Copper,
                SequentialNumber = 0,
                CableName = "{ get; set; } = String.Empty",
                CableBrand = "ВВГнг-",
                CoresNumber = 2,
                CableCrossSection = 2.5,
                NumberInFeeder = 1,
                CableLength = 1,
                CableVoltageLoss = 0.01,
                CableCurrent = 0.01,
                MaxCableCurrent = 0.01,
                ShortCircuitCurrent = 0.01,
            };
        }


        [Test]
        public void Blank_Cable_Creation_Test() {
            // Arrange
            _consumer = new BaseConsumer() {
                TechnologicalNumber = "MXW-250-13C",
                MechanismName = "насос технологический",
                RatedElectricPower = 3.5,
                PowerFactor = 0.85,
                Voltage = 230,
                HoursWorkedPerYear = 8700,
                LocationEquipmentInstallation = "102",
                StartingCurrentMultiplicity = 1
            };
            _consumerFillController.FillConsumerFields(_consumer);

            // Act
            const double cableLength = 120;
            _cableFillController = new CableFillController(_consumer, cableLength);
            const double dropVoltage = 2.3;
            var actualCable = _cableFillController.GetCableValue(dropVoltage);

            // Assert
            Assert.NotNull(actualCable);
        }

        [Test]
        public void Selection_Of_Cable_For_Single_Phase_Electric_Receiver_With_Small_Power_Output_Test() {
            // Arrange
            _consumer = new BaseConsumer() {
                TechnologicalNumber = "MXW-250-13C",
                MechanismName = "насос технологический",
                RatedElectricPower = 3.5,
                PowerFactor = 0.85,
                Voltage = 230,
                HoursWorkedPerYear = 8700,
                LocationEquipmentInstallation = "102",
                StartingCurrentMultiplicity = 1
            };
            _consumerFillController.FillConsumerFields(_consumer);

            BaseCable expectedCable = new BaseCable() {
                CableMaterial = Material.Copper,
                SequentialNumber = 0,
                CableName = "MXW-250-13C-H1",
                CableBrand = "ВВГнг-",
                CoresNumber = 3,
                CableCrossSection = 4,
                NumberInFeeder = 0,
                CableLength = 120,
                CableVoltageLoss = 0.01,
                CableCurrent = 17.902813299232736,
                MaxCableCurrent = 27,
                ShortCircuitCurrent = 0.01,
            };


            // Act
            const double cableLength = 120;
            _cableFillController = new CableFillController(_consumer, cableLength);
            const double dropVoltage = 2.3;
            var actualCable = _cableFillController.GetCableValue(dropVoltage);

            // Assert
            Assert.AreEqual(expectedCable, actualCable);
        }
        
        [Test]
        public void Selection_Of_Cable_For_Tree_Phase_Electric_Receiver_With_Small_Power_Output_Test() {
            // Arrange
            _consumer = new BaseConsumer() {
                TechnologicalNumber = "MXW-250-13C",
                MechanismName = "насос технологический",
                RatedElectricPower = 13.5,
                PowerFactor = 0.85,
                Voltage = 400,
                HoursWorkedPerYear = 8700,
                LocationEquipmentInstallation = "102",
                StartingCurrentMultiplicity = 1
            };
            _consumerFillController.FillConsumerFields(_consumer);

            BaseCable expectedCable = new BaseCable() {
                CableMaterial = Material.Copper,
                SequentialNumber = 0,
                CableName = "MXW-250-13C-H1",
                CableBrand = "ВВГнг-",
                CoresNumber = 5,
                CableCrossSection = 2.5,
                NumberInFeeder = 0,
                CableLength = 120,
                CableVoltageLoss = 0.01,
                CableCurrent = 22.9242018648822,
                MaxCableCurrent = 27,
                ShortCircuitCurrent = 0.01,
            };


            // Act
            const double cableLength = 120;
            _cableFillController = new CableFillController(_consumer, cableLength);
            const double dropVoltage = 2.3;
            var actualCable = _cableFillController.GetCableValue(dropVoltage);

            // Assert
            Assert.AreEqual(expectedCable, actualCable);
        }
    }
}