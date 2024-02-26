using ElectricalEngineering.Domain.Feeder;
using ElectricalEngineering.Domain.Utils;

namespace ElectricalEngineering.Presentation 
{
    public partial class ViewModel 
    {
        private static readonly BaseConsumerConverter Converter = new BaseConsumerConverter();
        private BaseConsumer _addedConsumer;
        private Dictionary<string, object> _electricReceiverFields;

        public Dictionary<string, object> ElectricReceiverFields
        {
            get
            {
                _electricReceiverFields = Converter.ConvertToDictionary(_addedConsumer);
                return _electricReceiverFields;
            }
            set
            {
                _electricReceiverFields = value;
                _addedConsumer = Converter.CreateFromDictionary(_electricReceiverFields);
                OnPropertyChanged(nameof(ElectricReceiverFields));
            }
        }

        public BaseConsumer AddedConsumer
        {
            get => _addedConsumer;
            set
            {
                _addedConsumer = value;
                OnPropertyChanged(nameof(AddedConsumer));
            }
        }
    }
}