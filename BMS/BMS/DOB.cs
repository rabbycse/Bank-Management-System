using System;
using System.Collections.Generic;
using System.Text;

namespace BMS
{
    class DOB
    {
        public int day;
        private int month;
        private int year;
   
        public void set(int d, int m, int y)
        {

            this.day = d;
            this.month = m;
            this.year = y;


        }
        public bool checkDate()
        {
            if (day > 31 || month > 12 || year > 2016)
            {
                Console.WriteLine("Invalid date ");
                return false;

            }
            else
                return true;

        }
        public bool printDate()
        {


            if (checkDate() == true)
            {
                Console.WriteLine("Date is : " + day + "-" + month + "-" + year);
                return false;
            }
            else
                Console.WriteLine("please enter date again");
            return true;


        }
    }
}

