using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            Application.Current.Properties["income"] = 0;
            Application.Current.Properties["tax"] = 0;
            Application.Current.Properties["expenses"] = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Creating Variables for User Inputs
                double income = Convert.ToDouble(income_tbx.Text);
                double tax = Convert.ToDouble(tax_tbx.Text);
                double groceries = Convert.ToDouble(groceries_tbx.Text);
                double water_elec = Convert.ToDouble(water_elec_tbx.Text);
                double fuel = Convert.ToDouble(fuel_tbx.Text);
                double telephone = Convert.ToDouble(telephone_tbx.Text);
                double other = Convert.ToDouble(other_tbx.Text);
                               

                // List of Expenses (Generic Collection)
                List<double> expenses = new List<double>() { groceries, water_elec, fuel, telephone, other };

                Application.Current.Properties["income"] = income;
                Application.Current.Properties["tax"] = tax;                
                Application.Current.Properties["expenses"] = expenses;

                var expenses_reporter = new ExpensesReporter();

                if (expenses.Sum() >= income * 0.75)
                {
                    expenses_reporter.Report();
                }
                MessageBox.Show("Details Saved Successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("Please Enter Numeric Values in all necessary Fields");
            }
        }
    }
}
