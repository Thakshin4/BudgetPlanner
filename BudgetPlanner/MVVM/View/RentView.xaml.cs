using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudgetPlanner.MVVM.View
{
    /// <summary>
    /// Interaction logic for RentView.xaml
    /// </summary>
    public partial class RentView : UserControl
    {
        public RentView()
        {
            InitializeComponent();
        }

        public void OnExpensesReport(object source, EventArgs e)
        {
            MessageBox.Show("Rent: Expenses exceed 75% of Income.");
        }

        private void calculate_btn_Click(object sender, RoutedEventArgs e)
        {           
            try
            {
                Rent r = new Rent();

                r.income = Convert.ToDouble(App.Current.Properties["income"]);
                r.tax = Convert.ToDouble(App.Current.Properties["tax"]);
                r.expenses = (List<double>)App.Current.Properties["expenses"];

                // Calculates Monthly Available Money
                double income = r.income;
                double expenses = r.total(r.expenses);
                double rent = Convert.ToDouble(rent_tbx.Text);

                double available = income - expenses - rent;

                // Prints Report
                MessageBox.Show
                    (
                    "Rent Price: R " + rent + Environment.NewLine +
                    "Income: R " + income + Environment.NewLine +
                    "Expenses: R " + expenses + Environment.NewLine +
                    "Available Monthly Money: R " + available.ToString("0.00") + Environment.NewLine,
                    "Rent Report"
                    );

                // Displays Output
                available_lbl.Content = available.ToString("0.00");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Numeric Values in all necessary Fields");
            }
        }
    }
}
