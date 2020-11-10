using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsReviewOOP
{
    public class clsAccount
    {
        // -- FIELDS will store the values of PROPERTIES
        private string vNumber;
        private string vType;
        private clsDate vOpenDate;
        private string vStatus;
        private decimal vBalance;


        //  --  CONSTRUCTORS  
        public clsAccount()
        {
            vNumber = vType = vStatus = "Not defined";
            vOpenDate = new clsDate();
            vBalance = -1;
        }

        public clsAccount(string number, string type, int day, int month, int year, string status, decimal balance)
        {
            vNumber = number;
            vType = type;
            vOpenDate = new clsDate(day, month, year);
            vStatus = status;
            vBalance = balance;
        }


        //  -- PROPERTIES 
        public string Number  // read only
        {
            get { return vNumber; }            
        }

        public string Type
        {
            get => vType ;
            set
            {
                vType = value;
            }
        }

        public clsDate OpenDate  // read only
        {
            get => vOpenDate;           
        }

        public string Status
        {
            get => vStatus ;
        }

        public decimal Balance  // read only
        {
            get => vBalance;           
        }


        //  --  METHODS 
        public void Open(string number, string type)
        {
            vNumber = number;
            Type = type;
            vOpenDate.Initialize(DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year);
            vStatus = "active";
            vBalance = 0;
        }
        /// <summary>
        /// Returns true if amount is between 2 and 20000 else false
        /// </summary>
        public bool Deposit(decimal amount)
        {
            if(amount >= 2 && amount <= 20000)
            {
               vBalance = vBalance + amount;   // vBalance += amount
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Returns 0 (for Success), 1 (for Maximum), 2 (for Minimum), -1(for Multiple 20), -2(for insufisant funds)
        /// </summary>
        public int Withdraw(decimal amount)
        {
           if(amount > 500) { return 1; }
            else if (amount < 20) { return 2; }
            else if ((amount % 20) != 0) { return -1; }
            else if (amount > vBalance) { return -2; }
            else
            {
                vBalance = vBalance - amount;  // vBalance -= amount
                return 0;
            }
        }

        public string Consult()
        {
            string info = "Number: " + vNumber + "\nType: " + vType + "\nOpen Date: " +
                vOpenDate.ToNumber() + "\nStatus: " + vStatus + "\nBalance: " + vBalance + " $\n";
            return info;
        }

        public void Close()
        {
            vStatus = "closed";
        }
    }
}