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
    /// Interaction logic for SavingsView.xaml
    /// </summary>
    public partial class SavingsView : UserControl
    {
        public SavingsView()
        {
            InitializeComponent();
        }

        private void calculate_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Savings s = new Savings();

                // Creating Variables for User Inputs
                string reason = reason_tbx.Text;
                double amount = Convert.ToDouble(amount_tbx.Text);
                double interest = Convert.ToDouble(interest_tbx.Text) / 100;
                int period = Convert.ToInt32(period_tbx.Text);

                // Calls method to calculate repayment
                double principal = s.calc_savings(amount, interest, period);

                // Prints Report
                MessageBox.Show
                    (
                    "Reason for Saving: " + reason + Environment.NewLine +
                    "Amount to Save: R " + amount + Environment.NewLine +
                    "Annual Interest Rate: " + interest * 100 + " %" + Environment.NewLine +
                    "Saving Period: " + period * 12 + " months" + Environment.NewLine +
                    "Required Monthly Savings: R " + principal.ToString("0.00") + Environment.NewLine,
                    "Savings Report"
                    );

                // Displays Output
                monthly_savings_lbl.Content = "R " + principal.ToString("0.00");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Numeric Values in all necessary Fields");
            }
        }
    }
}
