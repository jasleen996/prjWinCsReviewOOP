﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsReviewOOP
{
    public class clsATM
    {
        private string vNumber;
        private string vCompany;
        private string vLocation;
        private string vStatus;
        private clsListClient vClients;
        private decimal vBalance;

        public clsATM(string number, string company, string location, string status, clsListClient clients, decimal balance)
        {
            vNumber = number;
            vCompany = company;
            vLocation = location;
            vStatus = status;
            vClients = clients;
            vBalance = balance;
        }

        public clsATM()
        {
            vNumber = vCompany = vLocation = vStatus = "not defined";
            vClients = new clsListClient();
            vBalance = -1;
        }

        public string Number
        {
            get => vNumber ;
            set
            {
                vNumber = value;
            }
        }

        public string Company
        {
            get => vCompany ;
            set
            {
                vCompany = value;
            }
        }

        public string Location
        {
            get => vLocation;
            set
            {
                vLocation = value;
            }
        }

        public string Status
        {
            get => vStatus ;
            set
            {
                vStatus = value;
            }
        }

        public clsListClient Clients
        {
            get => vClients ;
            set
            {
                vClients = value;
            }
        }

        public decimal Balance
        {
            get => vBalance;
            
        }

        public void Open()
        {
            throw new System.NotImplementedException();
        }

        public void Fill(decimal amount)
        {
            vBalance = vBalance + amount;
        }

        public void Close()
        {
            vStatus = "closed";
        }

        public string Display()
        {
            string info = "\nATM\nNumber: " + vNumber + "\nCompany:" + vCompany + "\nLocation: " +
                vLocation + "\nStatus: " + vStatus + "\nBalance: " + vBalance +
                "\n\nClients: \n" + vClients.Display();
            return info;
        }
    }
}