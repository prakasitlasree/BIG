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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการออกจากโปรแกรม?", "ยินยันการออกจากโปรแกรม", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
                //this.Close();
            }
            else if (result == DialogResult.No)
            {
                //...
            }
            else
            {
                //...
            } 

        }

        private void lnk_employee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var personal = new PersonalForm();
            personal.Show();
        }

        private void btn_employee_Click(object sender, EventArgs e)
        {
            this.Hide();
            var personal = new PersonalForm();
            personal.Show();
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            this.Hide();
            var personal = new TestForm();
            personal.Show();
        }

        private void lnk_setting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var personal = new TestForm();
            personal.Show();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {

            this.Close();
            var frm = new ReportEmployee();
            frm.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            this.Close();
            var frm = new ReportEmployee();
            frm.Show();
        }
         
    }
}
