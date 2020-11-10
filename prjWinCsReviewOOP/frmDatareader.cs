using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace prjWinCsReviewOOP
{
    public partial class frmDatareader : Form
    {
        public frmDatareader()
        {
            InitializeComponent();
        }
        // global variable
        OleDbConnection myCon;
        string mode = "";
        private void frmDatareader_Load(object sender, EventArgs e)
        {
            // first task : Connect to the database
            myCon = new OleDbConnection();
            myCon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\15148\source\repos\2020\group07478\prjWinCsReviewOOP\prjWinCsReviewOOP\databases\DBBank2003.mdb";
            myCon.Open();

            // second task : recuperate the data
            OleDbCommand myCmd = new OleDbCommand();
            myCmd.CommandText = "SELECT Number FROM Clients";
            myCmd.Connection = myCon;

            // third task : store the data
            OleDbDataReader myRder = myCmd.ExecuteReader();

            while (myRder.Read())
            {
                lstNumbers.Items.Add(myRder["Number"].ToString());
            }



            // fill the grid with all accounts
            OleDbCommand myCmd2 = new OleDbCommand();
            myCmd2.CommandText = "SELECT Number,Type,OpenDay,OpenMonth,OpenYear,Status,Balance,ClientID FROM Accounts";
            
            myCmd2.Connection = myCon;

            OleDbDataReader myRder2 = myCmd2.ExecuteReader();


            // gridResult.DataSource = myRder2;
            DataTable tmp = new DataTable();
            tmp.Load(myRder2);
            gridResult.DataSource = tmp;


       


        }

        private void lstNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
  
            string selectNB = lstNumbers.SelectedItem.ToString();

            //// Loop VERSION Not the best
            //string sql = "SELECT Number,ClientName,Pin,Status FROM Clients";
            //OleDbCommand myCmd = new OleDbCommand();
            //myCmd.CommandText = sql;
            //myCmd.Connection = myCon;

            //OleDbDataReader myRder = myCmd.ExecuteReader();

            //while (myRder .Read())
            //{
            //    if(selectNB == myRder ["Number"].ToString())
            //    {
            //        txtNumber.Text = myRder["Number"].ToString();
            //        txtName.Text = myRder["ClientName"].ToString();
            //        txtPin.Text = myRder["Pin"].ToString();
            //        txtStatus.Text = myRder["Status"].ToString();
            //    }
            //}


            //   SQL VERSION
            string sql = "SELECT Number,ClientName,Pin,Status FROM Clients WHERE Number='" + selectNB + "'";
            OleDbCommand myCmd = new OleDbCommand();
            myCmd.CommandText = sql;
            myCmd.Connection = myCon;

            OleDbDataReader myRder = myCmd.ExecuteReader();
            if (myRder.Read())
            {
                txtNumber.Text = myRder["Number"].ToString();
                txtName.Text = myRder["ClientName"].ToString();
                txtPin.Text = myRder["Pin"].ToString();
                txtStatus.Text = myRder["Status"].ToString();
            }

            // Homework :display all accounts of the selected client
sql = "SELECT Number,Type,OpenDay,OpenMonth,OpenYear,Status,Balance,ClientID FROM Accounts WHERE ClientID='" + selectNB + "'";
            OleDbCommand mycmd2 = new OleDbCommand(sql, myCon);
            OleDbDataReader myrder2 = mycmd2.ExecuteReader();

            DataTable tmp = new DataTable();
            tmp.Load(myrder2);
            gridResult.DataSource = tmp;
            myRder.Close();
            }

        private void btnWriteOnlyDB_Click(object sender, EventArgs e)
        {
            //// first task : Connect to the database
            //myCon = new OleDbConnection();
            //myCon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\15148\source\repos\2020\group07478\prjWinCsReviewOOP\prjWinCsReviewOOP\databases\DBBank2003.mdb";
            //myCon.Open();

            // second task ; Write in the database
            OleDbCommand myCmd = new OleDbCommand();

            //// add a new record
            //myCmd.CommandText = "INSERT INTO Clients([Number],ClientName,Pin,Status) VALUES('c5c5','HarsKumar','coucous','active')";

            //// update an existing record
            //myCmd.CommandText = "UPDATE Clients SET Pin='milk' WHERE [Number]='c3c3'";


            //// delete an existing record
            //myCmd.CommandText = "DELETE FROM Clients WHERE [Number]='c5c5'";


            //myCmd.Connection = myCon;

            //myCmd.ExecuteNonQuery();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtName.Text = txtNumber.Text = txtPin.Text = "";
            txtStatus.Text = "active";
            txtNumber.Focus();

            // activate buttons
            btnAdd.Enabled = btnEdit .Enabled = btnDelete .Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            string num = txtNumber.Text;
            string nam = txtName.Text;
            string pin = txtPin.Text;
            string stat = txtStatus.Text;
            string sql = "";

            if (mode == "add") 
            { 
                //save the adding
                if(lstNumbers.Items.Contains(num)==true)
                {
                    MessageBox.Show("This client's Number already exists", "Adding Error");
                    txtNumber.Focus();
                    return;
                }
                else
                {
                    sql = "INSERT INTO Clients([Number],ClientName,Pin,Status) VALUES('" + num + 
                    "', '" + nam + "', '" + pin + "', '" + stat + "')";
                    OleDbCommand myCmd = new OleDbCommand(sql,myCon);
                    myCmd.ExecuteNonQuery();
                    lstNumbers.Items.Add(num);

                }
            }
            else if (mode == "edit")
            {
                //save the editing
                sql = "UPDATE Clients SET ClientName = '" + nam + "', Pin = '" + pin
                    + "', Status = '" + stat + "' WHERE [Number]='" + num + "'";
                OleDbCommand myCmd = new OleDbCommand(sql, myCon);
                myCmd.ExecuteNonQuery();
                txtNumber.Enabled = true;
            }

            mode = "";

            // activate buttons
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtNumber.Enabled = false;
            txtName.Focus();

            // activate buttons
            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox .Show ("Are you sure to want to delete this client ?", "Delete Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string num = txtNumber.Text;
                //// delete an existing record
                OleDbCommand myCmd = new OleDbCommand();
                myCmd.CommandText = "DELETE FROM Clients WHERE [Number]='" + num + "'";
                myCmd.Connection = myCon;
                myCmd.ExecuteNonQuery();
                
                lstNumbers.SelectedIndex = 0; // select the first element
                lstNumbers.Items.Remove(num);
            }
        }
    }
}
