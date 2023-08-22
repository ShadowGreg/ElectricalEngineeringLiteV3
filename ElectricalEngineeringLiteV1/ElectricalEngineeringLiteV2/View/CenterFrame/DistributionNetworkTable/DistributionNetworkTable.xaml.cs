using System.Windows;
using System.Windows.Controls;
using CoreV01.Feeder;
using ElectricalEngineeringLiteV1.View.Consumer;
using ElectricalEngineeringLiteV1.View.EditElements;
using ElectricalEngineeringLiteV1.ViewModel;

namespace ElectricalEngineeringLiteV1.View.CenterFrame.DistributionNetworkTable {
    public partial class DistributionNetworkTable: Page {
        private ViewModel.ViewModel _viewModel;

        public DistributionNetworkTable() {
            InitializeComponent();
            _viewModel = (ViewModel.ViewModel)Application.Current.Resources["ViewModel"];
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e) {
            var temp2 = e;
            _viewModel.SelectedObject = ((Node)e.NewValue).BaseNode;
        }

        private void Edit_Click(object sender, RoutedEventArgs e) {
            _viewModel = (ViewModel.ViewModel)Application.Current.Resources["ViewModel"];
            var temp = ((Selected)_viewModel.SelectedObject).Obj;
            if (temp.GetType() == typeof(BaseFeeder)) {
                MessageBox.Show("Редактировать можно объекты ниже по уровню вложенности",
                    "Информация",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            else if (temp.GetType() == typeof(BaseConsumer)) {
                Window editConsumer = new EditConsumer();
                editConsumer.Show();
            }
            else if (temp.GetType() == typeof(BaseCable)) {
                Window editCable = new EditCable();
                editCable.Show();
            }
            else if (temp.GetType() == typeof(BaseCircuitBreaker)) {
                Window editCircuitBreaker = new EditCircuitBreaker();
                editCircuitBreaker.Show();
            }

            var test = "";
        }
    }
}