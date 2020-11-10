using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjWinCsReviewOOP
{
    public static class clsDataSource
    {
        // we declare static class to store global variables or functions for the project

        public static clsListClient getAllClients()
        {

            //// --- TEXTFILES VERSION -------
            //clsListClient allclients = new clsListClient();
            //StreamReader myfile = new StreamReader("Clients.txt");
            //while(myfile.EndOfStream == false)
            //{
            //    string num = myfile.ReadLine();
            //    string nam = myfile.ReadLine();
            //    string pin = myfile.ReadLine();
            //    string stat = myfile.ReadLine();

            //    clsClient aclient = new clsClient(num, nam, pin, stat);

            //    allclients.Add(aclient);
            //}
            //myfile.Close();
            //return allclients;

            ////  ----- DATABASE VERSION -------
            clsListClient allclients = new clsListClient();
            OleDbConnection mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\15148\source\repos\2020\group07478\prjWinCsReviewOOP\prjWinCsReviewOOP\databases\DBBank2003.mdb");
            mycon.Open();
            string sql = "SELECT [Number], ClientName, Pin, Status FROM Clients";
            OleDbCommand mycmd = new OleDbCommand(sql, mycon);
            OleDbDataReader myRder = mycmd.ExecuteReader();

            while (myRder.Read())
            {
                string num = myRder["Number"].ToString();
                string nam = myRder["ClientName"].ToString();
                string pin = myRder["Pin"].ToString();
                string stat = myRder["Status"].ToString();

                clsClient aclient = new clsClient(num, nam, pin, stat);

                allclients.Add(aclient);
            }
            myRder.Close();
            mycon.Close();
            return allclients;
        }

        public static clsListAccount getThisClientAccounts(string clientNumber)
        {
            // // TEXT FILES VERSION ----
            //clsListAccount allAccounts = new clsListAccount();
            // StreamReader myfil = new StreamReader("Accounts.txt");
            // while (myfil .EndOfStream == false)
            // {
            //     string num = myfil.ReadLine();
            //     string typ = myfil.ReadLine();
            //     int day = Convert .ToInt32 ( myfil.ReadLine());
            //     int month = Convert.ToInt32(myfil.ReadLine());
            //     int year = Convert.ToInt32(myfil.ReadLine());
            //     string stat = myfil.ReadLine();
            //     decimal bal = Convert.ToDecimal(myfil.ReadLine());

            //     string clientID = myfil.ReadLine();

            //     if(clientID == clientNumber)
            //     {
            //         clsAccount anAcc = new clsAccount(num, typ, day, month, year, stat, bal);
            //         allAccounts.Add(anAcc);
            //     }

            // }
            // myfil.Close();
            // return allAccounts;


            // // ----DATABASE VERSION ---
            clsListAccount allAccounts = new clsListAccount();
            OleDbConnection mycon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\15148\source\repos\2020\group07478\prjWinCsReviewOOP\prjWinCsReviewOOP\databases\DBBank2003.mdb");
            mycon.Open();
            string sql = "SELECT [Number],Type,OpenDay,OpenMonth,OpenYear,Status,Balance,ClientID FROM Accounts WHERE ClientID='" + clientNumber + "'";
            OleDbCommand mycmd = new OleDbCommand(sql, mycon);
            OleDbDataReader myRder = mycmd.ExecuteReader();
            
            while (myRder .Read())
            {
                string num = myRder["Number"].ToString();
                string typ = myRder["Type"].ToString();
                int day = Convert.ToInt32(myRder["OpenDay"].ToString());
                int month = Convert.ToInt32(myRder["OpenMonth"].ToString());
                int year = Convert.ToInt32(myRder["OpenYear"].ToString());
                string stat = myRder["Status"].ToString();
                decimal bal = Convert.ToDecimal(myRder["Balance"].ToString());

                clsAccount anAcc = new clsAccount(num, typ, day, month, year, stat, bal);
                allAccounts.Add(anAcc);
            }
            myRder.Close();
            mycon.Close();
            return allAccounts;
        }

    }
}
