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
    public partial class frmClassVsStruct : Form
    {
       

        public frmClassVsStruct()
        {
            InitializeComponent();
        }

        // global variable for the form
        clsStudent myStud;
        private void frmClassVsStruct_Load(object sender, EventArgs e)
        {
            myStud = new clsStudent();
            

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int day = datBday.Value.Day;
            int month = datBday.Value.Month;
            int year = datBday.Value.Year;

            myStud.Register(name, day, month, year);

            btnRegister.Enabled = false;
        }

        private void btnToGrade_Click(object sender, EventArgs e)
        {
            Single grade = Convert.ToSingle(txtGrade.Text);
             
           if( myStud .ToGrade (grade) == true)
            {
                MessageBox.Show("Grading Succeeded");
            }
            else { MessageBox.Show("Grading Failed - Invalid Grade");  }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            lblInfo.Text = myStud.Display();
        }

        private void txtGrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsDigit(e.KeyChar) == false && Char.IsControl (e.KeyChar )==false)
            {
                e.Handled = true;
            }
           
        }
    }
}
