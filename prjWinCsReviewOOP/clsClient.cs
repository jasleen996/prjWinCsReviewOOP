using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsReviewOOP
{
    public class clsClient
    {
        private string vNumber;
        private string vName;
        private string vStatus;
        private string vPin;
        private clsListAccount vAccounts;

        public clsClient(string number, string name, string pin, string status, clsListAccount accounts)
        {
            vNumber = number;
            vName = name;
            vPin = pin;
            vStatus = status;
            vAccounts = accounts;
        }

        public clsClient(string number, string name, string pin, string status)
        {
            vNumber = number;
            vName = name;
            vPin = pin;
            vStatus = status;
            vAccounts = new clsListAccount();
        }
        public clsClient()
        {
            vNumber = vName = vStatus = vPin = "not defined";
            vAccounts = new clsListAccount();
        }

        public string Number
        {
            get => vNumber ;            
        }

        public string Name
        {
            get => vName;
            set
            {
                vName = value;
            }
        }

        public string Pin
        {
            get => vPin;
            set
            {
                vPin = value;
            }
        }

        public string Status
        {
            get => vStatus ;
        }

        public clsListAccount Accounts
        {
            get => vAccounts ;
            set
            {
                vAccounts = value;
            }
        }

        public void Register(string number, string name, string pin)
        {
            vNumber = number;
            Name = name;
            Pin = pin;
            vStatus = "active";

        }

        public string Display()
        {
            string info = "\nNumber: " + vNumber + "\nName: " + vName + "\nPin: " + vPin
                + "\nStatus: " + vStatus + "\nAccounts -- :\n " + vAccounts.Display();
            return info;
        }
    }
}