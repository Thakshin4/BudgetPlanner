using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    // Child Class of Expense
    class Rent : Expense
    {
        // Empty Constructor
        public Rent()
        { }

        // Constructor
        public Rent(double income, double tax, List<double> expenses)
        {
            this.income = income;
            this.tax = tax;
            this.expenses = expenses;
        }
    }
}
