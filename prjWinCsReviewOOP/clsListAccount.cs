﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace prjWinCsReviewOOP
{
    public class clsListAccount
    {
        // declaration of private or hidden dictionary to store the goup of account
        Dictionary<string, clsAccount> myList;
        public clsListAccount()
        {
            myList = new Dictionary<string, clsAccount>();
        }

        public int Quantity
        {
            get => myList.Count ;          
        }


        public Dictionary<string, clsAccount>.ValueCollection Elements
        {
            get => myList.Values;
           
        }

        public bool Add(clsAccount account)
        {
            if(Exist(account.Number) == false)
            {
                myList.Add(account.Number, account);
                return true;
            }else { return false; }
            
        }

        public bool Delete(string number)
        {
           return myList.Remove(number);
        }

        public clsAccount Find(string number)
        {
            if (Exist(number) == true)
            {
                return myList[number];
            }
            else { return null; }

        }

        public bool Exist(string number)
        {
          return myList.ContainsKey(number);
        }

        public string Display()
        {
            string info = "\n --- Accounts --- \n";
            foreach (clsAccount itm in myList.Values)
            {
                info += itm.Consult() + "\n";
            }
            return info;
        }
    }
}