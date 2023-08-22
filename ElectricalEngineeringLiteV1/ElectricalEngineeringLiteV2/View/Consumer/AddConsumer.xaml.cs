using System;
using System.Windows;
using System.Windows.Controls;
using BillingFillingController.Contrlollers.Consumer;
using CoreV01.Feeder;

namespace ElectricalEngineeringLiteV1.View.Consumer {
    public partial class AddConsumer: Window {
        private ViewModel.ViewModel _viewModel;
        private ConsumerFillController _consumerFillController;

        public AddConsumer() {
            InitializeComponent();
            _viewModel = (ViewModel.ViewModel)Application.Current.Resources["ViewModel"];
            _viewModel.AddedConsumer = new BaseConsumer();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            _consumerFillController = new ConsumerFillController();
            var addedConsumer = _viewModel.AddedConsumer;
            _consumerFillController.FillConsumerFields(addedConsumer);
            _viewModel.AddConsumer(addedConsumer);
            _viewModel.RebaseNode();
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e) {
            _viewModel = (ViewModel.ViewModel)Application.Current.Resources["ViewModel"];
            TextBox textBox = (TextBox)sender;
            _viewModel.AddedConsumer.TechnologicalNumber = textBox.Text;
        }
        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);
            Close();
        }
    }
}