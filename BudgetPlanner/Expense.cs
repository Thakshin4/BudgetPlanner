using System.Collections.Generic;

namespace BudgetPlanner
{
    // Abstract Parent Class
    abstract class Expense
    {
        // Class Variables
        public double income;
        public double tax;
        public List<double> expenses;

        // Method for Calculating Total of Expenses
        public double total(List<double> expenses)
        {
            // return expenses.Sum();

            double total = 0;

            foreach (var item in expenses)
            { total += item; }

            return total;
        }
    }
}