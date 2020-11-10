using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prjWinCsReviewOOP
{
    public class clsListClient
    {

        // declaration of private or hidden dictionary to store the goup of client
        Dictionary<string, clsClient> myList;
       
        public clsListClient()
        {
            myList = new Dictionary<string, clsClient>();
        }

        public int Quantity
        {
            get => myList.Count;
        }


        public Dictionary<string, clsClient>.ValueCollection Elements
        {
            get => myList.Values;

        }

        public bool Add(clsClient client)
        {
            if (Exist(client.Number) == false)
            {
                myList.Add(client.Number, client);
                return true;
            }
            else { return false; }

        }

        public bool Delete(string number)
        {
            return myList.Remove(number);
        }

        public clsClient Find(string number)
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
            string info = "\n --- Clients --- \n";
            foreach (clsClient  itm in myList.Values)
            {
                info += itm.Display() + "\n";
            }
            return info;
        }

    }
}