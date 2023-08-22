using System.Collections.Generic;
using System.Collections.ObjectModel;
using BillingFillingController.Contrlollers.ElectricalPanel;
using CADCore;
using CoreV01.Feeder;
using CoreV01.Properties;
using ElectricalEngineeringLiteV1.View.CenterFrame.DistributionNetworkTable;
using ElectricalEngineeringLiteV1.ViewModel.Util;

namespace ElectricalEngineeringLiteV1.ViewModel {
    public partial class ViewModel: ViewModelBase {
        private ElectricalPanelFillController _electricalPanelFillController;
        private ObservableCollection<Row> _rows;
        private Node _node;
        public DXFController CadController { get; }
        public BaseElectricalPanel ElectricalPanel { get; set; }

        public Node Node
        {
            get => _node;
            set
            {
                _node = value;
                OnPropertyChanged("Node");
            }
        }

        public ViewModel() {
            _consumers = new ObservableCollection<BaseConsumer>(new DataBase.DataBase().GetConsumers());
            _actual = new Selected(_consumers[0]);
            _addedConsumer = new BaseConsumer();
            _electricReceiverFields = new Dictionary<string, object>();
            GetNewPanel();
            ElectricalPanel = _electricalPanelFillController.GetPanel();
            _rows = new ObservableCollection<Row>();
            RowsAssembly();
            Node = new Node(ElectricalPanel);
            CadController = new DXFController();
        }

        public void RebaseNode() {
            Node = new Node(ElectricalPanel);
            OnPropertyChanged("Node");
        }
    }
}