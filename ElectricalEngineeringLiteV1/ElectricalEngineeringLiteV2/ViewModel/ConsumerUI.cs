using System.Collections.Generic;
using CoreV01.Feeder;
using CoreV01.Properties.Utils;

namespace ElectricalEngineeringLiteV1.ViewModel {
    public partial class ViewModel {
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
            get { return _addedConsumer; }
            set
            {
                _addedConsumer = value;
                OnPropertyChanged(nameof(AddedConsumer));
            }
        }
    }
}