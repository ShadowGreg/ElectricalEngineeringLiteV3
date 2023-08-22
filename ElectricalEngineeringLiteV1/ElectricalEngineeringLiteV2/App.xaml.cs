using System.Windows;
using System.Windows.Threading;

namespace ElectricalEngineeringLiteV1 {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App: Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            // Attach the event handler for unhandled exceptions
            Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        private void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {
            // Handle the unhandled exception here
            MessageBox.Show($"An unhandled exception occurred: {e.Exception.Message}",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            // Prevent the application from terminating
            e.Handled = true;
        }
    }
}