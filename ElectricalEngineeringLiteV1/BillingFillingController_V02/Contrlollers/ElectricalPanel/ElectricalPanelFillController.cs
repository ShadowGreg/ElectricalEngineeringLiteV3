using System;
using System.Collections.Generic;
using System.Linq;
using BillingFillingController.Calculators;
using BillingFillingController.Contrlollers.BusBars;
using CoreV01.Feeder;
using CoreV01.Properties;

namespace BillingFillingController.Contrlollers.ElectricalPanel {
    public class ElectricalPanelFillController {
        private static BaseElectricalPanel _electricalPanel;
        private static BusbarFillController _busbarFillController;

        public ElectricalPanelFillController(double voltage = 400, string name = "Новый щит ЩР1") {
            _electricalPanel = new BaseElectricalPanel {
                TechnologicalNumber = name,
                BusBars = new List<BaseBusbar>()
            };
            _busbarFillController = new BusbarFillController(voltage);
            _electricalPanel.BusBars.Add(new BaseBusbar {
                SequentialNumber = 1
            });
        }

        public static RMTCalculation PanelCalculations { get; set; }

        private void AddConsumerOnPanel(BaseConsumer newConsumer, double length = 5, double maxVoltageDrop = 2.5,
            int busbarNum = 0) {
            string ConvertToRoman(int number) {
                if (number < 0 || number > 3) throw new ArgumentOutOfRangeException("Number must be between 1 and 4");

                switch (number) {
                    case 0:
                        return "I";
                    case 1:
                        return "II";
                    case 2:
                        return "III";
                    case 3:
                        return "IV";
                    default:
                        return "";
                }
            }

            _busbarFillController.AddConsumerOnBus(newConsumer, length, maxVoltageDrop);
            _electricalPanel.BusBars[busbarNum] = _busbarFillController.GetBusbar();

            _electricalPanel.BusBars[busbarNum].BusbarName = ConvertToRoman(busbarNum) + " СШ";
            _electricalPanel.BusBars[busbarNum].OwnerId = _electricalPanel.SelfId;
            PanelCalculations = new RMTCalculation();
            List<BaseConsumer> localConsumers = new List<BaseConsumer>();
            foreach (var busbar in _electricalPanel.BusBars)
                localConsumers.AddRange(busbar.Feeders.Select(feeder => feeder.Consumer));

            PanelCalculations.GetInstallCapacity(localConsumers, _electricalPanel.Voltage);
        }

        private void GetCalculationBusbar(List<BaseConsumer> consumers,
            int busbarNum) {
            if (consumers.Count() == 1)
                AddConsumerOnPanel(consumers[0], busbarNum: busbarNum);
            else
                foreach (var consumer in consumers)
                    AddConsumerOnPanel(consumer, busbarNum: busbarNum);
        }

        private static void CalculatePanelFields() {
            _electricalPanel.NumberOfElectricalReceiversInstalledInTheSwitchboard = GetNumberOfReceivers();
            _electricalPanel.InstalledElectricalPowerOfTheSwitchboard = GetInstalledPowerOfSwitchboard();
            _electricalPanel.ShieldUtilizationFactor = GetShieldUtilizationFactor();
            _electricalPanel.ShieldPowerFactor = GetShieldPowerFactor();
            _electricalPanel.AverageRatedActivePower = GetAverageRatedActivePower();
            _electricalPanel.AverageDesignReactivePower = GetAverageDesignReactivePower();
            _electricalPanel.SquareOfTheRatedPowerOfThePanel = GetSquareOfTheRatedPowerOfThePanel();
            _electricalPanel.EquivalentNumberOfElectricalReceiversOfTheShield =
                GetEquivalentNumberOfElectricalReceivers();
            _electricalPanel.DesignLoadFactor = GetDesignLoadFactor();
            _electricalPanel.ShieldActivePower = GetShieldActivePower();
            _electricalPanel.ReactivePowerOfThePanel = GetReactivePowerOfThePanel();
            _electricalPanel.TotalPower = GetTotalPowerPanel();
            _electricalPanel.RatedCurrent = GetRatedCurrent();
        }

        private static double GetNumberOfReceivers() {
            return _electricalPanel.BusBars.Sum(busbar => busbar.Feeders.Count());
        }

        private static double GetInstalledPowerOfSwitchboard() {
            return _electricalPanel.BusBars.Sum(busBar =>
                busBar.Feeders.Sum(feeder =>
                    feeder.Consumer.RatedElectricPower * feeder.Consumer.NumberElectricalReceivers));
        }

        private static double GetShieldUtilizationFactor() {
            double coefficient = 0;
            coefficient = _electricalPanel.BusBars.Sum(busBar => busBar.InstalledCapacity)
                          / _electricalPanel.BusBars.Sum(busBar => busBar.RatedCapacity);
            return coefficient;
        }

        private static double GetShieldPowerFactor() {
            return PanelCalculations.BusPowerFactor;
        }

        private static double GetAverageRatedActivePower() {
            return PanelCalculations.ActiveAverageDesignPower;
        }

        private static double GetAverageDesignReactivePower() {
            return PanelCalculations.ReactiveAverageRatedPower;
        }

        private static double GetSquareOfTheRatedPowerOfThePanel() {
            return PanelCalculations.SquareOfRatedPower;
        }

        private static double GetEquivalentNumberOfElectricalReceivers() {
            return PanelCalculations.EquivalentNumberOfElectricalReceivers;
        }

        private static double GetDesignLoadFactor() {
            return PanelCalculations.DesignLoadFactor;
        }

        private static double GetShieldActivePower() {
            return PanelCalculations.ActiveRatedPowerOfTheBus;
        }

        private static double GetReactivePowerOfThePanel() {
            return PanelCalculations.ReactiveRatedPowerOfTheBus;
        }

        private static double GetTotalPowerPanel() {
            return PanelCalculations.TotalDesignPowerOfTheBus;
        }

        private static double GetRatedCurrent() {
            return PanelCalculations.DesignBusbarCurrent;
        }


        public void AddOnPanel(List<BaseConsumer> consumers, int busbarNum = 0) {
            switch (busbarNum) {
                case 0:
                    GetCalculationBusbar(consumers, busbarNum);
                    break;
            }

            ///TODO потом пререписать систему  так что бы можно было спокойно переключаться - предположительно словарь
            CalculatePanelFields();
        }

        public BaseElectricalPanel GetPanel() {
            CalculatePanelFields();
            return _electricalPanel;
        }

        public BusbarFillController GetBusbarFillController() {
            return _busbarFillController;
        }
    }
}