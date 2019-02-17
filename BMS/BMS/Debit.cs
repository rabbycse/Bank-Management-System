﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BMS
{
    class Debit:Account
    {
        public double maxBalance = 100000;
        private double dailyTransLimit = 20000;

        public Debit() : base()
        {

        }

        public Debit(string name, DOB DOB, string nominee, double balance) : base(name, DOB, nominee, balance)
        {

        }

        public override bool deposit(double amount)
        {
            this.ammount = amount;
            if (amount > maxBalance)
            {
                Console.WriteLine("You can not deposit more than 100000!");
                return false;
            }
            else
            {
                this.balance = balance + ammount;
                Console.WriteLine("You account balance has been deposited.Balance is: " + balance);
                return true;
            }
        }

        public override bool withdraw(double amount)
        {
            this.ammount = amount;

            if (amount > dailyTransLimit)
            {
                Console.WriteLine("You can not withdraw more than 20000.");
                return false;

            }
            else if (amount > maxBalance)
            {
                Console.WriteLine("You can not withdraw that ammount of money!");
                return false;
            }
            else
            {
                this.balance = balance - ammount;
                Console.WriteLine("You account balance has been withdrawed.Balance is: " + balance);
                return true;
            }
        }
    }
}

