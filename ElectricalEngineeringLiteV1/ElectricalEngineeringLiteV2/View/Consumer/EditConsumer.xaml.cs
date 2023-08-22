using System;
using System.Windows;
using System.Windows.Controls;

namespace ElectricalEngineeringLiteV1.View.Consumer {
    public partial class EditConsumer: Window {
        public EditConsumer() {
            InitializeComponent();
        }

        private void Close_Window(object sender, RoutedEventArgs e) {
            Close();
        }

        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);
            Close();
        }
    }
}