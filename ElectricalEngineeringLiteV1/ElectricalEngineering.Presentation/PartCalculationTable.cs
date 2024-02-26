using System.Collections.ObjectModel;
using ElectricalEngineering.Domain.Feeder;
using ElectricalEngineering.DomainServices.Contrlollers.ElectricalPanel;
using ElectricalEngineering.Presentation.Items;

namespace ElectricalEngineering.Presentation {
    public partial class ViewModel {
        public ObservableCollection<Row> Row
        {
            get => _rows;
            set
            {
                _rows = value;
                OnPropertyChanged(nameof(Row));
                RowsAssembly();
            }
        }

        private void GetNewPanel() {
            _electricalPanelFillController = new ElectricalPanelFillController();
            _electricalPanelFillController.AddOnPanel(_consumers.ToList());
        }

        public void RowsAssembly() {
            ObservableCollection<Row> tempRows = new ObservableCollection<Row>();
            GetNewPanel();
            ElectricalPanel = _electricalPanelFillController.GetPanel();
            tempRows.Add(new Row {
                Name = ElectricalPanel.TechnologicalNumber
            });
            var _busbar = ElectricalPanel.BusBars[0];
            tempRows.Add(new Row {
                Name = _busbar.BusbarName
            });
            List<BaseFeeder> _feeders = _busbar.Feeders;
            foreach (var feeder in _feeders)
                tempRows.Add(new Row {
                    Name = feeder.Consumer.TechnologicalNumber,
                    NumberOfReceivers = feeder.Consumer.NumberElectricalReceivers,
                    RatedPower = feeder.Consumer.RatedElectricPower,
                    RatedPowerOfIdenticalElectricalReceivers = feeder.Consumer.RatedElectricPower,
                    UtilizationFactor = feeder.Consumer.UsageFactor,
                    PowerFactor = feeder.Consumer.PowerFactor,
                    TangentPowerFactor = feeder.Consumer.TanPowerFactor,
                    ActiveAverageDesignPower = feeder.Consumer.UsageFactor * feeder.Consumer.RatedElectricPower,
                    ReactiveAverageRatedPower = feeder.Consumer.ReactivePower,
                    SquareOfRatedPower = feeder.Consumer.RatedPowerSquared * feeder.Consumer.RatedPowerSquared
                });

            var _busbarFillController = _electricalPanelFillController.GetBusbarFillController();
            tempRows.Add(new Row {
                //Name = $"ИТОГО по шине {_busbar.BusbarName}:",
                NumberOfReceivers = _busbarFillController.BusbarCalculations.NumberOfReceivers,
                RatedPower = _busbarFillController.BusbarCalculations.RatedPower,
                RatedPowerOfIdenticalElectricalReceivers =
                    _busbarFillController.BusbarCalculations.RatedPowerOfIdenticalElectricalReceivers,
                UtilizationFactor = _busbarFillController.BusbarCalculations.BusUtilizationFactor,
                PowerFactor = _busbarFillController.BusbarCalculations.BusPowerFactor,
                TangentPowerFactor = _busbarFillController.BusbarCalculations.TangentOfBusPowerFactor,
                ActiveAverageDesignPower = _busbarFillController.BusbarCalculations.ActiveAverageDesignPower,
                ReactiveAverageRatedPower = _busbarFillController.BusbarCalculations.ActiveRatedPowerOfTheBus,
                SquareOfRatedPower = _busbarFillController.BusbarCalculations.SquareOfRatedPower,
                EquivalentNumberOfElectricalReceivers =
                    _busbarFillController.BusbarCalculations.EquivalentNumberOfElectricalReceivers,
                DesignLoadFactor = _busbarFillController.BusbarCalculations.DesignLoadFactor,
                ActiveRatedPower = _busbarFillController.BusbarCalculations.ActiveRatedPowerOfTheBus,
                ReactiveRatedPower = _busbarFillController.BusbarCalculations.ReactiveRatedPowerOfTheBus,
                TotalDesignPower = _busbarFillController.BusbarCalculations.TotalDesignPowerOfTheBus,
                DesignBusbarCurrent = _busbarFillController.BusbarCalculations.DesignBusbarCurrent
            });
            tempRows.Add(new Row {
                //Name = $"ИТОГО по щиту {ElectricalPanel.MechanismName}:",
                NumberOfReceivers = _busbarFillController.BusbarCalculations.NumberOfReceivers,
                RatedPower = _busbarFillController.BusbarCalculations.RatedPower,
                RatedPowerOfIdenticalElectricalReceivers =
                    _busbarFillController.BusbarCalculations.RatedPowerOfIdenticalElectricalReceivers,
                UtilizationFactor = _busbarFillController.BusbarCalculations.BusUtilizationFactor,
                PowerFactor = _busbarFillController.BusbarCalculations.BusPowerFactor,
                TangentPowerFactor = _busbarFillController.BusbarCalculations.TangentOfBusPowerFactor,
                ActiveAverageDesignPower = _busbarFillController.BusbarCalculations.ActiveAverageDesignPower,
                ReactiveAverageRatedPower = _busbarFillController.BusbarCalculations.ActiveRatedPowerOfTheBus,
                SquareOfRatedPower = _busbarFillController.BusbarCalculations.SquareOfRatedPower,
                EquivalentNumberOfElectricalReceivers =
                    _busbarFillController.BusbarCalculations.EquivalentNumberOfElectricalReceivers,
                DesignLoadFactor = _busbarFillController.BusbarCalculations.DesignLoadFactor,
                ActiveRatedPower = _busbarFillController.BusbarCalculations.ActiveRatedPowerOfTheBus,
                ReactiveRatedPower = _busbarFillController.BusbarCalculations.ReactiveRatedPowerOfTheBus,
                TotalDesignPower = _busbarFillController.BusbarCalculations.TotalDesignPowerOfTheBus,
                DesignBusbarCurrent = _busbarFillController.BusbarCalculations.DesignBusbarCurrent
            });
            _rows = tempRows;
            RebaseNode();
            OnPropertyChanged(nameof(Row));
        }

        public void DelConsumer(BaseConsumer consumer) {
            List<BaseConsumer> tempRows = new List<BaseConsumer>();
            var temp = consumer;
            foreach (var item in _consumers)
                if (item != consumer)
                    tempRows.Add(item);

            _consumers = new ObservableCollection<BaseConsumer>(tempRows);
            OnPropertyChanged(nameof(Consumers));
        }
    }
}