using System.Collections.Generic;
using BillingFillingController.Contrlollers.Consumer;
using BillingFillingController.Contrlollers.ElectricalPanel;
using CoreV01.Feeder;
using NUnit.Framework;

namespace BackendTests.Properties {
    [TestFixture]
    public class CalculationsTests {
        [SetUp]
        public void Setup() {
            _electricalPanelFillController = new ElectricalPanelFillController();
        }

        private List<BaseConsumer> _consumers;
        private ElectricalPanelFillController _electricalPanelFillController;

        [Test]
        public void Calculation_Of_The_Parameters_Of_The_Electrical_Receiver_Test() {
            // Arrange
            var consumerController = new ConsumerFillController();
            var actualConsumer = new BaseConsumer {
                TechnologicalNumber = "030-Р-008A",
                MechanismName = "Насос Xylem, LOWARA",
                RatedElectricPower = 10,
                UsageFactor = 0.85,
                PowerFactor = 0.93,
                Voltage = 400,
                HoursWorkedPerYear = 8700,
                LocationEquipmentInstallation = "102",
                StartingCurrentMultiplicity = 11
            };
            var expectedConsumer = new BaseConsumer {
                TechnologicalNumber = "030-Р-008A",
                MechanismName = "Насос Xylem, LOWARA",
                RatedElectricPower = 10,
                UsageFactor = 0.85,
                PowerFactor = 0.93,
                Voltage = 400,
                HoursWorkedPerYear = 8700,
                LocationEquipmentInstallation = "102",
                StartingCurrentMultiplicity = 11,
                TanPowerFactor = 0.376383482317728,
                RatedPowerSquared = 100,
                ReactivePower = 3.76383482317728,
                RatedCurrent = 15.5201685266028,
                StartingCurrent = 170.721853792631
            };


            // Act
            consumerController.FillConsumerFields(actualConsumer);


            // Assert
            Assert.AreEqual(actualConsumer, expectedConsumer);
        }

        [Test]
        public void Basic_Calculations_For_Asingle_Electrical_Receiver_Test() {
            // Arrange
            _electricalPanelFillController.AddOnPanel(new List<BaseConsumer> {
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
                }
            });
            const double expectedRatedCurrentOnPanel = 15.301461463655684d;

            // Act
            double actualRatedCurrentOnPanel = _electricalPanelFillController.GetPanel().RatedCurrent;

            // Assert
            Assert.AreEqual(actualRatedCurrentOnPanel, expectedRatedCurrentOnPanel);
        }

        [Test]
        public void Calculation_Of_Electrical_Panel_Parameters_For_Multiple_Receivers_Test() {
            // Arrange
            _electricalPanelFillController.AddOnPanel(new List<BaseConsumer> {
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
                    TechnologicalNumber = "030-Р-008C",
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
                    TechnologicalNumber = "030-Р-008D",
                    MechanismName = "Насос Xylem, LOWARA",
                    RatedElectricPower = 10,
                    UsageFactor = 0.85,
                    PowerFactor = 0.93,
                    Voltage = 400,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 10
                }
            });
            const double expectedRatedCurrentOnPanel = 53.114551365702411d;

            // Act
            double actualRatedCurrentOnPanel = _electricalPanelFillController.GetPanel().RatedCurrent;

            // Assert
            Assert.AreEqual(actualRatedCurrentOnPanel, expectedRatedCurrentOnPanel);
        }


        [Test]
        public void Calculation_Of_Parameters_Of_Electric_Panel_With_Several_Receivers_Two_Of_Them_Single_Phase_Test() {
            // Arrange
            _electricalPanelFillController.AddOnPanel(new List<BaseConsumer> {
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
                    Voltage = 220,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 10
                },
                new BaseConsumer {
                    TechnologicalNumber = "030-Р-008C",
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
                    TechnologicalNumber = "030-Р-008D",
                    MechanismName = "Насос Xylem, LOWARA",
                    RatedElectricPower = 10,
                    UsageFactor = 0.85,
                    PowerFactor = 0.93,
                    Voltage = 220,
                    HoursWorkedPerYear = 8700,
                    LocationEquipmentInstallation = "102",
                    StartingCurrentMultiplicity = 10
                }
            });
            const double expectedRatedCurrentOnPanel = 53.114551365702411d;

            // Act
            double actualRatedCurrentOnPanel = _electricalPanelFillController.GetPanel().RatedCurrent;

            // Assert
            ///TODO отдельное упоминание - сейчас не счиатется однофазные электроприёмники нормально их - надо сделать 
            Assert.AreEqual(actualRatedCurrentOnPanel, expectedRatedCurrentOnPanel);
        }
    }
}