using System.Windows.Controls;

namespace ElectricalEngineeringLiteV1.View.CenterFrame {
    public partial class CalculationTableOfDistributionNetwork: Page {
        public CalculationTableOfDistributionNetwork() {
            InitializeComponent();
        }

        private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e) {
            string corpString =
                "Наименование ЭП Кол-во ЭП шт.n Номинальная (установленная) мощность, кВт одного ЭП рн Номинальная (установленная) мощность, кВт общая Рн =n*рн Коэф. использования Ки";
            if (corpString.Contains(e.Column.Header.ToString())) e.Handled = true;
        }
    }
}