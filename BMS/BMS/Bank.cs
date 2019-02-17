﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BMS
{
    class Bank
    {
        string id;
        public int idnum = 0;

        public string[] myId = new string[100];
        public string[] myName = new string[100];
        public string[] myAccType = new string[100];
        public string[] myDob = new string[100];
        public string[] myNominee = new string[100];
        public double[] myBalance = new double[100];

        IDGenerator Id = new IDGenerator();
        DOB dob = new DOB();
        Credit cr = new Credit();
        Debit db = new Debit();
        Savings sv = new Savings();
  
        public bool val = true;
        public bool debval = true;

        private void GetAcc(string ID)
        {
            ID = this.id;
            myId[idnum] = ID;
            idnum++;

        }
        public void showAll()
        {
            Console.WriteLine("All accounts are:\n");
            for (int i = 0; i < idnum; i++)
            {
                Console.WriteLine(myId[i]);

            }
        }

        public void showInfo()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                Console.WriteLine("Your details: ");
                Console.WriteLine("Name: " + myName[indexNum]);
                Console.WriteLine("Id: " + myId[indexNum]);
                Console.WriteLine("Acc Type: " + myAccType[indexNum]);
                Console.WriteLine("DOB: " + myDob[indexNum]);
                Console.WriteLine("Nominee: " + myNominee[indexNum]);
                Console.WriteLine("Balance: " + myBalance[indexNum]);
            }
            else
            {
                Console.WriteLine("Your id is wrong!");
            }


        }

        public void create_account()
        {

            string accType;
            string name;
            int d, m, y;
            string nominee;
            double balance;
            string input;
            Console.WriteLine("1. Debit Account");
            Console.WriteLine("2. Credit Account");
            Console.WriteLine("3. Savings Account");
            object ob1 = Console.ReadLine();
            input = Convert.ToString(ob1);

            if (input == "1")
            {

                accType = "Debit";
                myAccType[idnum] = accType;
                Console.Write("Name:");

                name = Convert.ToString(Console.ReadLine());
                myName[idnum] = name;
          
                while (val == true)
                {
                    Console.WriteLine("Enter date: ");

                    d = Convert.ToInt32(Console.ReadLine());
                    m = Convert.ToInt32(Console.ReadLine());
                    y = Convert.ToInt32(Console.ReadLine());
                    dob.set(d, m, y);
                    if (dob.printDate() == false)
                    {
                        myDob[idnum] = Convert.ToString(d + "/" + m + "/" + y);
                        val = false;
                    }
                    else val = true;
                }
                val = true; 
                Console.WriteLine("Enter Nominee name: ");
                nominee = Convert.ToString(Console.ReadLine());
                myNominee[idnum] = nominee;
                while (debval == true)
                {
                    Console.WriteLine("Enter account balance: ");
                    balance = Convert.ToDouble(Console.ReadLine());
                    if (balance > db.maxBalance)
                    {
                        Console.WriteLine("Debit Account max value is 100000!");
                        debval = true;
                    }
                    else
                    {
                        myBalance[idnum] = balance;
                        debval = false;
                    }
                }
                debval = true;
                Console.WriteLine("Created debit account successfully...! ");
                id = Id.generate();
                id = id + "Deb";
                Console.WriteLine("Your Account Id : " + id);
                GetAcc(id);

            }
            else if (input == "2")
            {
                accType = "Credit";
                myAccType[idnum] = accType;
                Console.Write("Name:");
                name = Convert.ToString(Console.ReadLine());
                myName[idnum] = name;
                while (val == true)
                {
                    Console.WriteLine("Enter date: ");

                    d = Convert.ToInt32(Console.ReadLine());
                    m = Convert.ToInt32(Console.ReadLine());
                    y = Convert.ToInt32(Console.ReadLine());
                    dob.set(d, m, y);
                    if (dob.printDate() == false)
                    {
                        myDob[idnum] = Convert.ToString(d + "-" + m + "-" + y);
                        val = false;
                    }
                    else val = true;
                }
                val = true;
                Console.WriteLine("Enter Nominee name: ");
                nominee = Convert.ToString(Console.ReadLine());
                myNominee[idnum] = nominee;
                while (debval == true)
                {
                    Console.WriteLine("Enter account balance: ");
                    balance = Convert.ToDouble(Console.ReadLine());
                    if (balance < cr.minBalance)
                    {
                        Console.WriteLine("Credit Account's min val is -100000!");
                        debval = true;
                    }
                    else
                    {
                        myBalance[idnum] = balance;
                        debval = false;
                    }
                }
                debval = true;
                Console.WriteLine("Created Credit account successfully...! ");
                id = Id.generate();
                id = id + "Cre";
                Console.WriteLine("Your Account Id : " + id);
                GetAcc(id);

            }
            else if (input == "3")
            {
                accType = "Savings";
                myAccType[idnum] = accType;
                Console.Write("Name:");

                name = Convert.ToString(Console.ReadLine());
                myName[idnum] = name;
                while (val == true)
                {
                    Console.WriteLine("Enter date: ");

                    d = Convert.ToInt32(Console.ReadLine());
                    m = Convert.ToInt32(Console.ReadLine());
                    y = Convert.ToInt32(Console.ReadLine());
                    dob.set(d, m, y);
                    if (dob.printDate() == false)
                    {
                        myDob[idnum] = Convert.ToString(d + "-" + m + "-" + y);
                        val = false;
                    }
                    else val = true;
                }
                val = true; 
                Console.WriteLine("Enter Nominee name: ");
                nominee = Convert.ToString(Console.ReadLine());
                myNominee[idnum] = nominee;
                Console.WriteLine("Enter account balance: ");
                balance = Convert.ToDouble(Console.ReadLine());
                myBalance[idnum] = balance;
                Console.WriteLine("Created Savings account successfully...! ");
                id = Id.generate();
                id = id + "Sav";
                Console.WriteLine("Your Account Id : " + id);
                GetAcc(id);

            }





        }

        public void deposit()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                Console.WriteLine("Your Balance is: " + myBalance[indexNum]);
                Console.WriteLine("How much you want to deposit: ");
                double depval = Convert.ToDouble(Console.ReadLine());
                if (myAccType[indexNum] == "Debit")
                {
                    db.balance = myBalance[indexNum];
                    db.deposit(depval);
                    myBalance[indexNum] = db.balance;
                }
                else if (myAccType[indexNum] == "Credit")
                {
                    cr.balance = myBalance[indexNum];
                    cr.deposit(depval);
                    myBalance[indexNum] = db.balance;
                }
                else if (myAccType[indexNum] == "Savings")
                {
                    sv.balance = myBalance[indexNum];
                    sv.deposit(depval);
                    myBalance[indexNum] = sv.balance;
                }

            }

            else
            {
                Console.WriteLine("Your id is wrong!");
            }

        }
        public void withdraw()
        {
            int indexNum;
            string inId = Convert.ToString(Console.ReadLine());
            if (myId.Contains(inId))
            {
                indexNum = Array.IndexOf(myId, inId);
                Console.WriteLine("Your Balance is: " + myBalance[indexNum]);
                Console.WriteLine("How much you want to withdraw: ");
                double depval = Convert.ToDouble(Console.ReadLine());
                if (myAccType[indexNum] == "Debit")
                {
                    db.balance = myBalance[indexNum];
                    db.withdraw(depval);
                    myBalance[indexNum] = db.balance;
                }
                else if (myAccType[indexNum] == "Credit")
                {
                    cr.balance = myBalance[indexNum];
                    cr.withdraw(depval);
                    myBalance[indexNum] = cr.balance;
                }
                else if (myAccType[indexNum] == "Savings")
                {
                    sv.balance = myBalance[indexNum];
                    sv.withdraw(depval);
                    myBalance[indexNum] = sv.balance;
                }

            }
            else
            {
                Console.WriteLine("Your id is wrong!");
            }

        }
    }
}

