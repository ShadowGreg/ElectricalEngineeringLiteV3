using System;
using System.Windows;
using ElectricalEngineeringLiteV1.View.Help;
using Microsoft.Win32;

namespace ElectricalEngineeringLiteV1.View {
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        private readonly ViewModel.ViewModel _viewModel;

        public MainWindow() {
            InitializeComponent();
            _viewModel = (ViewModel.ViewModel)Application.Current.Resources["ViewModel"];
        }

        private void CreateCad_OnClick(object sender, RoutedEventArgs e) {
            string filename = GetFilename();

            _viewModel.CadController.DrawPanel(_viewModel.ElectricalPanel, filename);
            MessageBox.Show("Создание схемы завершено",
                "Схема",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private static string GetFilename() {
            var dialog = new SaveFileDialog();
            dialog.FileName = "sample"; // Default file name
            dialog.DefaultExt = ".dxf"; // Default file extension
            dialog.Filter = "DXF documents (.dxf)|*.dxf"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();
            string filename = "sample.dxf";

            // Process save file dialog box results
            if (result == true)
                // Save document
                filename = dialog.FileName;

            return filename;
        }


        private void License_OnClick(object sender, RoutedEventArgs e) {
            Window licenseAgreement = new LicenseAgreement();
            licenseAgreement.Show();
        }

        private void JobDescription_OnClick(object sender, RoutedEventArgs e) {
            Window jobDescription = new JobDescription();
            jobDescription.Show();
        }

        protected override void OnClosed(EventArgs e) {
            base.OnClosed(e);
            Close();
        }
    }
}