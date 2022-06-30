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
    /// Interaction logic for VehicleView.xaml
    /// </summary>
    public partial class VehicleView : UserControl
    {
        public VehicleView()
        {
            InitializeComponent();
        }

        public void OnExpensesReport(object source, EventArgs e)
        {
            MessageBox.Show("Vehicle: Expenses exceed 75% of Income.");
        }

        private void calculate_btn_Click(object sender, RoutedEventArgs e)
        {      
            try
            {
                Vehicle v = new Vehicle();

                v.income = Convert.ToDouble(App.Current.Properties["income"]);
                v.tax = Convert.ToDouble(App.Current.Properties["tax"]);
                v.expenses = (List<double>)App.Current.Properties["expenses"];

                // Creating Variables for User Inputs
                int REPAYMENT_PERIOD = 5;

                double price = Convert.ToDouble(price_tbx.Text);
                double deposit = Convert.ToDouble(deposit_tbx.Text);
                int months = REPAYMENT_PERIOD * 12;
                double income = v.income;
                double expenses = v.total(v.expenses);
                double repayment = v.repayment;

                double P = price - deposit;
                double i = Convert.ToDouble(interst_tbx.Text) / 100;
                int n = months / 12;
                double insurance = Convert.ToDouble(insurance_tbx.Text);

                // Calls method to calculate repayment
                v.repayment = v.calc_repayment(P, i, n, months, insurance);

                double available = income - expenses - repayment;

                // Prints Report
                MessageBox.Show
                    (
                    "Model and Make: " + model_make_tbx.Text + Environment.NewLine +
                    "Purchase Price: R " + price + Environment.NewLine +
                    "Total Deposit: R " + deposit + Environment.NewLine +
                    "Interest Rate: " + i * 100 + " %" + Environment.NewLine +
                    "Repayment Period: 5 Years" + Environment.NewLine +
                    "Estimated Insurance Premium: R " + insurance + Environment.NewLine +
                    "Income: R " + income + Environment.NewLine +
                    "Expenses: R " + expenses + Environment.NewLine +
                    "Monthly Repayment: R " + repayment.ToString("0.00") + Environment.NewLine +
                    "Available Monthly Money: R " + available.ToString("0.00") + Environment.NewLine,
                    "Vehicle Report"
                    );

                // Displays Output
                repayement_lbl.Content = repayment.ToString("0.00");
                available_lbl.Content = available.ToString("0.00");

                // If Statement determines whether to Alert the User
                if (v.repayment > v.income / 3)
                {
                    MessageBox.Show("You are not Eligable for a Loan");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Numeric Values in all necessary Fields");
            }           
        }
    }
}
