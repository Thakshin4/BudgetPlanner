using System;
using System.Windows;

namespace BudgetPlanner
{
    public class ExpensesReporter
    {
        // Delegate        
        public delegate void ExpensesReportEventHandler(object course, EventArgs e);

        // Event
        public event ExpensesReportEventHandler ExpensesReport;

        public void Report()
        {
            MessageBox.Show("Expenses exceed 75% of Income.");

            OnExpensesReport();
        }

        protected virtual void OnExpensesReport()
        {
            if (ExpensesReport != null)
            { ExpensesReport(this, EventArgs.Empty); }
        }
    }
}
