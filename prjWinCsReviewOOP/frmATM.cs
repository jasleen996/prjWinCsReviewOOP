using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWinCsReviewOOP
{
    public partial class frmATM : Form
    {
        

        public frmATM()
        {
            InitializeComponent();
        }

        // Declaration of global variables
        clsATM myBank;
        clsClient currentClient;
        clsAccount currentAccount;

        private void frmATM_Load(object sender, EventArgs e)
        {
            txtDeposit.Visible = false;
            lblDeposit.Visible = false;
            txtWithdraw.Visible = false;
            lblWithdraw.Visible = false;

            this.Height = 175;

            // initialization of the ATM with the content of the datasource
            clsListClient allClients = clsDataSource.getAllClients();       
            myBank = new clsATM("111", "TD", "CLasalle", "active", allClients , 200000);
          
        }

        private void radDeposit_CheckedChanged(object sender, EventArgs e)
        {
            txtDeposit.Visible = true;
            lblDeposit.Visible = true;
            txtWithdraw.Visible = false;
            lblWithdraw.Visible = false;
            txtDeposit.Focus();
        }

        private void radWithdraw_CheckedChanged(object sender, EventArgs e)
        {
            txtDeposit.Visible = false;
            lblDeposit.Visible = false ;
            txtWithdraw.Visible = true ;
            lblWithdraw.Visible = true;
            txtWithdraw.Focus();
        }

        private void radConsult_CheckedChanged(object sender, EventArgs e)
        {
            //txtDeposit.Visible = false;
            //lblDeposit.Visible = false;
            //txtWithdraw.Visible = false;
            //lblWithdraw.Visible = false;
            txtDeposit.Visible = lblDeposit.Visible = txtWithdraw.Visible = lblWithdraw.Visible = false;

        }

        private void btnNextNumber_Click(object sender, EventArgs e)
        {
            string number = txtNumber.Text.Trim();
            currentClient = myBank.Clients.Find(number);
            if(currentClient == null)
            {
                MessageBox.Show("Client Number Not Found, Try again.", "TD: Identification Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumber.Focus();
                return;
            }
            else
            {
                this.Height = 273;
                lblWelcome.Text = "Welcome " + currentClient.Name;
                txtPin.Focus();
              
            }             
        }

        private void btnNextPin_Click(object sender, EventArgs e)
        {
            string pin = txtPin.Text.Trim();
            if(currentClient .Pin != pin)
            {
                MessageBox.Show("Client Pin Incorrect, Try again.", "TD: Pin Verification Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPin.Clear();
                txtPin.Focus();
                return;
            }
            else
            {
                this.Height = 348;
                currentClient.Accounts = clsDataSource.getThisClientAccounts(currentClient.Number);
                foreach (clsAccount acc in currentClient .Accounts .Elements)
                {
                    cboAccounts.Items.Add(acc.Type);
                }
                cboAccounts.SelectedIndex = 0;

               
            }

            
        }

        private void btnNextAccount_Click(object sender, EventArgs e)
        {

            foreach (clsAccount itm in currentClient .Accounts.Elements)
            {
                if (itm.Type == cboAccounts.SelectedItem.ToString())
                {
                    currentAccount = itm;
                }
            }
            this.Height = 464;
            //MessageBox.Show(currentAccount.Consult());
        }

       

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            this.Height = 175;
            txtNumber.Clear();
            txtNumber.Focus();
        }

        private void btnNextTransaction_Click(object sender, EventArgs e)
        {
            
            if(radDeposit.Checked)
            {
                decimal amount = Convert.ToDecimal(txtDeposit.Text);
               if( currentAccount.Deposit(amount) == false)
                {
                    MessageBox.Show("Deposit Fails: The amount must be between 2$ and 20000$.", 
                    "TD: Deposit Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDeposit.Focus();
                    return;
                }
            }
            
            else if (radWithdraw.Checked)
            {
                decimal amount = Convert.ToDecimal(txtWithdraw.Text);
                int result = currentAccount.Withdraw(amount);
                switch (result)
                {
                    case 1:
                        MessageBox.Show("Withdraw Fails: The Maximum amount to withdraw is 500$.",
                        "TD: Withdraw Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtWithdraw.Focus();
                        return;
                    case 2:
                        MessageBox.Show("Withdraw Fails: The Minimum amount to withdraw is 20$.",
                        "TD: Withdraw Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtWithdraw.Focus();
                        return;
                    case -1:
                        MessageBox.Show("Withdraw Fails: The amount to withdraw must be a multiple of 20$.",
                        "TD: Withdraw Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtWithdraw.Focus();
                        return;
                    case -2:
                        MessageBox.Show("Withdraw Fails: Insufisant funds, your balance is " + currentAccount.Balance,
                        "TD: Withdraw Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtWithdraw.Focus();
                        return;
                }
            }    
            this.Height = 620;
            lblAccountInfo.Text = currentAccount.Consult();
        }

        private void txtDeposit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl (e.KeyChar) ==false)
            {
                 e.Handled = true; // blocking the caracter typed by the key
            }  
        }

        private void txtWithdraw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true; // blocking the caracter typed by the key
            }



        }
    }
}
