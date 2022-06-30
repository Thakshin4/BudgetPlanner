using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner
{
    // Child Class of Expense
    class HomeLoan : Expense
    {
        public double repayment;

        // Empty Constructor
        public HomeLoan()
        { }

        // Constructor
        public HomeLoan(double income, double tax, List<double> expenses)
        {
            this.income = income;
            this.tax = tax;
            this.expenses = expenses;
        }

        // Method for Calculating Cost of Monthly Repayments
        public double calc_repayment(double P, double i, double n, int months)
        {
            double A = P * (1 + (i * n));
            repayment = A / months;

            return repayment;
        }
    }
}