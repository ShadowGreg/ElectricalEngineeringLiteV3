using System;
using System.Windows;

namespace ElectricalEngineeringLiteV1.View.EditElements {
    public partial class EditCable: Window {
        private ViewModel.ViewModel _viewModel;

        public EditCable() {
            InitializeComponent();
        }

        private void Close_Window(object sender, RoutedEventArgs e) {
            _viewModel = (ViewModel.ViewModel)Application.Current.Resources["ViewModel"];
            _viewModel.OnPropertyChanged("SelectedObject");
            Close();
        }
        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);
            Close();
        }
    }
}