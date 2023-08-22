using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ElectricalEngineeringLiteV1.ViewModel {
    public class ViewModelBase: INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string PropertyChangedEvent) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyChangedEvent));
            }
        }
    }
}