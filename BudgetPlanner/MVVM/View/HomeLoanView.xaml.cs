using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for HomeLoanView.xaml
    /// </summary>
    public partial class HomeLoanView : UserControl
    {
        public HomeLoanView()
        {
            InitializeComponent();
        }

        public void OnExpensesReport(object source, EventArgs e)
        {
            MessageBox.Show("HomeLoan: Expenses exceed 75% of Income.");
        }

        private void calculate_btn_Click(object sender, RoutedEventArgs e)
        {         
            try
            {
                HomeLoan hl = new HomeLoan();

                hl.income = Convert.ToDouble(App.Current.Properties["income"]);
                hl.tax = Convert.ToDouble(App.Current.Properties["tax"]);
                hl.expenses = (List<double>)App.Current.Properties["expenses"];

                // Creating Variables for User Inputs
                double price = Convert.ToDouble(property_price_tbx.Text);
                double deposit = Convert.ToDouble(deposit_tbx.Text);
                int months = Convert.ToInt32(months_tbx.Text);
                double income = hl.income;
                double expenses = hl.total(hl.expenses);
                double repayment = hl.repayment;

                double P = price - deposit;
                double i = Convert.ToDouble(interest_tbx.Text) / 100;
                int n = months / 12;

                // Calls method to calculate repayment
                repayment = hl.calc_repayment(P, i, n, months);

                double available = income - expenses - repayment;

                // Prints Report
                MessageBox.Show
                    (
                    "Purchase Price: R " + price + Environment.NewLine +
                    "Total Deposit: R " + deposit + Environment.NewLine +
                    "Interest Rate: " + i * 100 + " %" + Environment.NewLine +
                    "Repayment Period: " + months + Environment.NewLine +
                    "Income: R " + income + Environment.NewLine +
                    "Expenses: R " + expenses + Environment.NewLine +
                    "Monthly Repayment: R " + repayment.ToString("0.00") + Environment.NewLine +
                    "Available Monthly Money: R " + available.ToString("0.00") + Environment.NewLine,
                    "Home Loan Report"
                    );

                // Displays Output
                // Formats Output to 2 Decimal Places
                repayment_lbl.Content = repayment.ToString("0.00");
                available_lbl.Content = available.ToString("0.00");

                // If Statement determines whether to Alert the User
                if (hl.repayment > hl.income / 3)
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
