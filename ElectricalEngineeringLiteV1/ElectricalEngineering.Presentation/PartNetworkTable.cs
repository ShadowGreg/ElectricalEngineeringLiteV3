using System.Collections.ObjectModel;
using ElectricalEngineering.CADCore;
using ElectricalEngineering.Domain;
using ElectricalEngineering.Domain.Abstractions.Repositories;
using ElectricalEngineering.Domain.Feeder;
using ElectricalEngineering.DomainServices.Contrlollers.ElectricalPanel;
using ElectricalEngineering.Presentation.Items;
using ElectricalEngineeringLiteV1.ViewModel;

namespace ElectricalEngineering.Presentation
{
    public partial class ViewModel : ViewModelBase
    {
        private ElectricalPanelFillController _electricalPanelFillController;
        private Node _node;
        private ObservableCollection<Row> _rows;


        public ViewModel(IRepository<BaseConsumer> consumers)
        {
            _consumers = new ObservableCollection<BaseConsumer>(consumers.GetAllAsync().Result);
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

        public void RebaseNode()
        {
            Node = new Node(ElectricalPanel);
            OnPropertyChanged("Node");
        }
    }
}