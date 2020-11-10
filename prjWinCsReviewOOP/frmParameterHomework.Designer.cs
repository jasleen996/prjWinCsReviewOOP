namespace prjWinCsReviewOOP
{
    partial class frmParameterHomework
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridStudents = new System.Windows.Forms.DataGridView();
            this.btnFind = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkProgram = new System.Windows.Forms.CheckBox();
            this.chkGrade = new System.Windows.Forms.CheckBox();
            this.cboPrograms = new System.Windows.Forms.ComboBox();
            this.cboGrades = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridStudents)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridStudents
            // 
            this.gridStudents.AllowUserToAddRows = false;
            this.gridStudents.AllowUserToDeleteRows = false;
            this.gridStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStudents.Location = new System.Drawing.Point(28, 364);
            this.gridStudents.Name = "gridStudents";
            this.gridStudents.ReadOnly = true;
            this.gridStudents.RowHeadersWidth = 82;
            this.gridStudents.RowTemplate.Height = 33;
            this.gridStudents.Size = new System.Drawing.Size(1198, 458);
            this.gridStudents.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(907, 188);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(219, 78);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find Students";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1009, 51);
            this.label1.TabIndex = 3;
            this.label1.Text = "THE PARAMETER OBJECT OF THE COMMAND";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboGrades);
            this.groupBox1.Controls.Add(this.cboPrograms);
            this.groupBox1.Controls.Add(this.chkGrade);
            this.groupBox1.Controls.Add(this.chkProgram);
            this.groupBox1.Location = new System.Drawing.Point(36, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(816, 189);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criterias ";
            // 
            // chkProgram
            // 
            this.chkProgram.AutoSize = true;
            this.chkProgram.Location = new System.Drawing.Point(37, 59);
            this.chkProgram.Name = "chkProgram";
            this.chkProgram.Size = new System.Drawing.Size(156, 29);
            this.chkProgram.TabIndex = 0;
            this.chkProgram.Text = "By Program";
            this.chkProgram.UseVisualStyleBackColor = true;
            // 
            // chkGrade
            // 
            this.chkGrade.AutoSize = true;
            this.chkGrade.Location = new System.Drawing.Point(37, 117);
            this.chkGrade.Name = "chkGrade";
            this.chkGrade.Size = new System.Drawing.Size(226, 29);
            this.chkGrade.TabIndex = 1;
            this.chkGrade.Text = "By Minimum Grade";
            this.chkGrade.UseVisualStyleBackColor = true;
            // 
            // cboPrograms
            // 
            this.cboPrograms.FormattingEnabled = true;
            this.cboPrograms.Location = new System.Drawing.Point(305, 55);
            this.cboPrograms.Name = "cboPrograms";
            this.cboPrograms.Size = new System.Drawing.Size(395, 33);
            this.cboPrograms.TabIndex = 2;
            // 
            // cboGrades
            // 
            this.cboGrades.FormattingEnabled = true;
            this.cboGrades.Location = new System.Drawing.Point(305, 110);
            this.cboGrades.Name = "cboGrades";
            this.cboGrades.Size = new System.Drawing.Size(394, 33);
            this.cboGrades.TabIndex = 3;
            // 
            // frmParameterHomework
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 857);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.gridStudents);
            this.Name = "frmParameterHomework";
            this.Text = "frmParameterHomework";
            this.Load += new System.EventHandler(this.frmParameterHomework_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridStudents)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridStudents;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboGrades;
        private System.Windows.Forms.ComboBox cboPrograms;
        private System.Windows.Forms.CheckBox chkGrade;
        private System.Windows.Forms.CheckBox chkProgram;
    }
}