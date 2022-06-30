using System;
using System.Collections;
using System.Collections.Generic;

namespace BudgetPlanner
{
    // Child Class of Expense
    class Vehicle : Expense
    {
        public double repayment;
        public double insurance;

        // Empty Constructor
        public Vehicle()
        { }

        // Constructor
        public Vehicle(double income, double tax, List<double> expenses)
        {
            this.income = income;
            this.tax = tax;
            this.expenses = expenses;
        }

        // Method for Calculating Cost of Monthly Repayments
        public double calc_repayment(double P, double i, double n, int months, double insurance)
        {
            this.insurance = insurance;

            double A = P * (1 + (i * n));
            repayment = (A / months) + insurance;

            return repayment;
        }
    }
}