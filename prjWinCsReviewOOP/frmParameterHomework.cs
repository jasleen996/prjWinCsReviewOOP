using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWinCsReviewOOP
{
    public partial class frmParameterHomework : Form
    {
        public frmParameterHomework()
        {
            InitializeComponent();
        }

        OleDbConnection myCon;
        private void frmParameterHomework_Load(object sender, EventArgs e)
        {
            

            myCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\14383\Downloads\prjWinCsReviewOOP(5)latest\prjWinCsReviewOOP\prjWinCsReviewOOP\databases\DBBank2003.mdb");
            myCon.Open();

            // fill the combobox with the programs
            OleDbCommand mycmd = new OleDbCommand("SELECT DISTINCT Program FROM STUDENTS", myCon);
            OleDbDataReader myrder = mycmd.ExecuteReader();
            while (myrder .Read())
            {
                cboPrograms.Items.Add(myrder["Program"].ToString());
            }
            myrder.Close();

            // fill the combobox with the grades
            OleDbCommand mycmd2 = new OleDbCommand("SELECT DISTINCT Grade FROM STUDENTS", myCon);
            OleDbDataReader myrder2 = mycmd2.ExecuteReader();
            while (myrder2.Read())
            {
                cboGrades.Items.Add(myrder2["Grade"].ToString());
            }
            myrder2.Close();

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string sql = "";
            OleDbCommand myCmd = new OleDbCommand();
            myCmd.Connection = myCon;

            if(chkProgram.Checked == false && chkGrade.Checked == false)
            {
                sql = "SELECT StudentName,Gender,Grade,Program FROM Students";
            }
            else if (chkProgram.Checked == true && chkGrade.Checked == false)
            {
                sql = "SELECT StudentName,Gender,Grade,Program FROM Students WHERE Program = @prg";
                myCmd.Parameters.AddWithValue("@prg", cboPrograms.SelectedItem.ToString());
            }
            else if (chkProgram.Checked == false && chkGrade.Checked == true)
            {
                sql = "SELECT StudentName,Gender,Grade,Program FROM Students WHERE Grade >= @grd";
                myCmd.Parameters.AddWithValue("@grd", Convert.ToSingle(cboGrades.SelectedItem.ToString()));
            }
            else if (chkProgram.Checked == true && chkGrade.Checked == true)
            {
                sql = "SELECT StudentName,Gender,Grade,Program FROM Students WHERE Grade >= @grd AND Program = @prg";
                myCmd.Parameters.AddWithValue("@grd", Convert.ToSingle(cboGrades.SelectedItem.ToString()));
                myCmd.Parameters.AddWithValue("@prg", cboPrograms.SelectedItem.ToString());
            }

            myCmd.CommandText = sql;
            OleDbDataReader myRder = myCmd.ExecuteReader();

            DataTable tmp = new DataTable();
            tmp.Load(myRder);
            gridStudents.DataSource = tmp;

        }
    }
}
