using System;
using System.Collections;
using System.Collections.Generic;

namespace BudgetPlanner
{
    // Child Class of Expense
    class Savings :Expense
    {
        public string reason;
        public double amount;
        public double principal;
        public double interest;
        public int period;

        // Empty Constructor
        public Savings()
        { }

        // Constructor
        public Savings(string reason, double amount, double interest, int period)
        {
            this.reason = reason;
            this.amount = amount;
            this.interest = interest;
            this.period = period;
        }        

        // Method for Calculating Cost of Monthly Repayments
        public double calc_savings( double A, double i, int n)
        {
            principal = (A * (i / n) / (Math.Pow((1 + i / n), n * 12) - 1));
;
            return principal;
        }
    }
}