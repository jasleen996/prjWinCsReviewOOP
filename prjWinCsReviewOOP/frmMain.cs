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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            string info = "Are you sure to want to qui this program ?";
            string title = "Application Closing Warning";

            if(MessageBox.Show(info,title,MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                Application.Exit();
            }
            

        }

        private void mnuATM_Click(object sender, EventArgs e)
        {
            frmATM myfrm = new frmATM();
            // indicate to frmAtm that it is the child (form) of frmMain
            myfrm.MdiParent = this;
            myfrm.Show();
        }

        private void mnuOOP_Click(object sender, EventArgs e)
        {
            frmClassVsStruct myfrm = new frmClassVsStruct();
            // indicate to frmclassVsStruct that it is the child (form) of frmMain
            myfrm.MdiParent = this;
            myfrm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void mnuDatareader_Click(object sender, EventArgs e)
        {
            frmDatareader fd = new frmDatareader();
            fd.MdiParent = this;
            fd.Show();
        }
    }
}
