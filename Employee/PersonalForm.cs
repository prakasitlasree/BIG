using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIG.DataService;
using BIG.Model;
using Neurotec.Biometrics;
using System.IO;

namespace BIG.Present
{
    public partial class PersonalForm : Form
    {
        public PersonalForm()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void PersonalForm_Load(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            
            var lst = EmployeeServices.GetAll();
             
        }

        private void btn_search_Click_1(object sender, EventArgs e)
        {
            var lst = EmployeeServices.GetAll();
            if (txt_name_sname.Text != "")
            {

                var ds = lst.Where(x => x.EMP_ID.Contains(txt_name_sname.Text)).Select(x => new { x.EMP_ID, x.ID_CARD, x.FIRSTNAME_TH, x.LASTNAME_TH, x.FIRSTNAME_EN, x.LASTNAME_EN, x.NATIONALITY, x.RELEGION, x.MOBILE, x.BLOODGROUP }).ToList();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ds;
            }
            else if (txt_pid.Text != "")
            {
                var ds = lst.Where(x => x.ID_CARD.Contains(txt_name_sname.Text)).Select(x => new { x.EMP_ID, x.ID_CARD, x.FIRSTNAME_TH, x.LASTNAME_TH, x.FIRSTNAME_EN, x.LASTNAME_EN, x.NATIONALITY, x.RELEGION, x.MOBILE, x.BLOODGROUP }).ToList();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ds;
            }
            else
            {
                var ds = lst.Select(x => new { x.EMP_ID, x.ID_CARD, x.FIRSTNAME_TH, x.LASTNAME_TH, x.FIRSTNAME_EN, x.LASTNAME_EN, x.NATIONALITY, x.RELEGION, x.MOBILE, x.BLOODGROUP }).ToList();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ds;

            }
          

        }

        private void btn_load_pid_Click(object sender, EventArgs e)
        {

            var empfrm = new EmployeeForm();
            empfrm.Show();
            this.Hide();
        }

        private void left_menu1_Click(object sender, EventArgs e)
        {
          
        }

        private void ribbonOrbMenuItem2_Click(object sender, EventArgs e)
        {
            var emp = new EmployeeForm();
            emp.Show();
            this.Hide();
        }

        private void rb_new_emp_Click(object sender, EventArgs e)
        {
             
        }

        private void rb_load_emp_Click(object sender, EventArgs e)
        {
             
           
        }

        private void rb_home_Click(object sender, EventArgs e)
        {
            Close();
            var mainform = new MainForm();
            mainform.Show();
        }

        private void rb_load_pid_Click(object sender, EventArgs e)
        {
            
        }

        private void rb_new_Click(object sender, EventArgs e)
        { 
             
            Neurotec.Biometrics.Nffv engine = null;
            try
            {

                try
                {
                    engine = new Neurotec.Biometrics.Nffv("FingerprintDB.CSharpSample.dat", "", "UareU");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Failed to initialize Nffv or create/load database.\r\n" +
                    "Please check if:\r\n - Provided password is correct;\r\n - Database filename is correct;\r\n" +
                    " - Scanners are used properly.\r\n", "Nffv C# Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Application.Run(new MainForm(engine, chooseScannerForm.UserDatabase)); 
                
                var personal = new EmployeeForm(engine);
                personal.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("An error has occured: {0}", ex.Message), "Nffv C# Sample",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (engine != null)
                {
                    engine.Dispose();
                }
            } 
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var mainform = new MainForm();
            mainform.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainform = new MainForm();
            mainform.Show();
        }

        private void ribbonButton20_Click(object sender, EventArgs e)
        {
            txt_site_location.Focus();
        }

        private void ribbonButton21_Click(object sender, EventArgs e)
        {
            txt_area.Focus();
        }

        private void ribbonButton14_Click(object sender, EventArgs e)
        {
            txt_name_sname.Focus();
        }

        private void ribbonButton15_Click(object sender, EventArgs e)
        {
            this.Hide();
            var pform = new ReportEmployee();
            pform.Show();
        }

        private void rb_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new LoginForm();
            form.Show();
        }

        private void rb_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
