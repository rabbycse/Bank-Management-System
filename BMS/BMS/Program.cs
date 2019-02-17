using System;

namespace BMS
{
    class Program
    {
        static void Main(string[] args)
        {
            String input;
            DOB dob = new DOB();
            IDGenerator id = new IDGenerator();
            Credit cr = new Credit();
            Debit db = new Debit();
            Savings sv = new Savings();
            Bank bn = new Bank();
            Console.WriteLine("****  Welcome to Bank Management System  ***");
            while (true)
            {
                Console.WriteLine("\nWhat you want to do:");
                Console.WriteLine("1. Create account");
                Console.WriteLine("2. Show account information");
                Console.WriteLine("3. Deposit from account");
                Console.WriteLine("4. Withdraw from account");
                Console.WriteLine("5. Show all account with id");
                Console.WriteLine("6. Clear screen");
                Console.WriteLine("7. Exit");
                object ob1 = Console.ReadLine();
                input = Convert.ToString(ob1);

                if (input == "1")
                {
                    Console.WriteLine("Enter account Type :");
                    bn.create_account();

                }
                else if (input == "2")
                {
                    Console.Write("Enter account Number :");
                    bn.showInfo();
                }
                else if (input == "3")
                {
                    Console.WriteLine("Enter Account Id: ");
                    bn.deposit();
                }
                else if (input == "4")
                {
                    Console.WriteLine("Enter Account Id: ");
                    bn.withdraw();
                }
                else if (input == "5")
                {
                    bn.showAll();
                }
                else if (input == "6")
                {
                    Console.Clear();
                }
                else if (input == "7")
                {
                    Environment.Exit(0);
                }
                Console.ReadKey();


            }

        }

    }
}
    
