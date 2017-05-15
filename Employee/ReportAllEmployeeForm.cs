using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BIG.Present
{
    public partial class ReportAllEmployeeForm : Form
    {

        #region Ribbon Event

        public ReportAllEmployeeForm()
        {
            InitializeComponent();
        }

        private void rb_home_Click(object sender, EventArgs e)
        {
            var form = new MainForm();
            form.Show();
            Hide();
        }

        private void rb_new_Click(object sender, EventArgs e)
        {
            var form = new EmployeeForm();
            form.Show();
            Hide();
        }

        private void rb_print_Click(object sender, EventArgs e)
        {
            var form = new ReportEmployee();
            form.Show();
            Hide();
        }

        private void rb_logout_Click(object sender, EventArgs e)
        {
            var form = new LoginForm();
            form.Show();
            Hide();
        }

        private void rb_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ribbon_personale_detail_Click(object sender, EventArgs e)
        {
            var form = new ReportEmployee();
            form.Show();
            Hide();
        }

        private void ribbonSearchbyPID_Click(object sender, EventArgs e)
        {
            var form = new PersonalForm();
            form.Show();
            Hide();
        }

        private void ribbonSearchbyName_Click(object sender, EventArgs e)
        {
            var form = new PersonalForm();
            form.Show();
            Hide();
        }

        private void ribbonAllReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("กรุณาค้นหาข้อมูลตามต้องการ");
        }

        #endregion

        private void ReportAllEmployeeForm_Load(object sender, EventArgs e)
        {
            
            try
            {
                this.Cursor = Cursors.WaitCursor; 
                // TODO: This line of code loads data into the 'AllEmployeeDS.EmployeeReport' table. You can move, or remove it, as needed.

                this.EmployeeReportTableAdapter.Fill(this.AllEmployeeDS.EmployeeReport);

                this.reportViewer1.RefreshReport();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ReportEmployee_Load...." + ex.Message);
            }
        }

        private void ReportAllEmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = new PersonalForm();
            form.Show();
            this.Hide();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // TODO: This line of code loads data into the 'AllEmployeeDS.EmployeeReport' table. You can move, or remove it, as needed.

                this.EmployeeReportTableAdapter.FillByDateStartWork(this.AllEmployeeDS.EmployeeReport, Convert.ToDateTime(start_date.Value), Convert.ToDateTime(end_date.Value));

                this.reportViewer1.RefreshReport();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ReportEmployee_Load...." + ex.Message);
            }
        }

        private void Btn_ShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // TODO: This line of code loads data into the 'AllEmployeeDS.EmployeeReport' table. You can move, or remove it, as needed.

                this.EmployeeReportTableAdapter.Fill(this.AllEmployeeDS.EmployeeReport);

                this.reportViewer1.RefreshReport();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ReportEmployee_Load...." + ex.Message);
            }
        }


    }
}
