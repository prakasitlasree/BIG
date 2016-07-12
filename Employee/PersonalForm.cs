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
        private const int BUTTON_VIEW_COLUMN_INDEX = 8;

        private void PersonalForm_Load(object sender, EventArgs e)
        {

        }

        private void SetColumnHeader()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Index == 0)
                {
                    col.Width = 100;
                    col.HeaderText = "รหัสพนักงาน";
                }
                if (col.Index == 1)
                {
                    col.Width = 150;
                    col.HeaderText = "หมายเลขบัตรประชาชน";
                }
                if (col.Index == 2)
                {
                    col.Width = 170;
                    col.HeaderText = "ชื่อ(TH)";
                }
                if (col.Index == 3)
                {
                    col.Width = 170;
                    col.HeaderText = "นามสกุล(TH)";
                }
                if (col.Index == 4)
                {
                    col.Width = 150;
                    col.HeaderText = "ชื่อ(EN)";
                }
                if (col.Index == 5)
                {
                    col.Width = 150;
                    col.HeaderText = "นามสกุล(EN)";
                } 
                if (col.Index == 6)
                {
                    col.Width = 120;
                    col.HeaderText = "หมายเลขโทรศัพท์";
                }
                if (col.Index == 7)
                {
                    col.HeaderText = "กรุ๊ปเลือด";
                } 
            }
        }
        private void BindDataGrid(TextBox tx)
        {
            var lst = EmployeeServices.GetAll(); 
            var ds = lst.Where(x => x.FIRSTNAME_TH.Contains(txt_name_sname.Text) || x.FIRSTNAME_EN.Contains(txt_name_sname.Text) || x.LASTNAME_TH.Contains(txt_name_sname.Text) || x.LASTNAME_EN.Contains(txt_name_sname.Text)).Select(x => new
            { x.EMP_ID, x.ID_CARD, x.FIRSTNAME_TH, x.LASTNAME_TH, x.FIRSTNAME_EN, x.LASTNAME_EN, x.MOBILE, x.BLOODGROUP }).ToList();
            var searchcol = new DataGridViewButtonColumn();
            searchcol.Name = "View";
            searchcol.Text = "View";
            var printcol = new DataGridViewButtonColumn();
            printcol.Name = "Print";
            printcol.Text = "Print"; 
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ds; 
            dataGridView1.Refresh();
            if (dataGridView1.Columns["Search"] == null)
            {
                dataGridView1.Columns.Insert(BUTTON_VIEW_COLUMN_INDEX, searchcol);
            }
            if (dataGridView1.Columns["Print"] == null)
            {
                dataGridView1.Columns.Insert(BUTTON_VIEW_COLUMN_INDEX + 1, printcol);
            }

            SetColumnHeader();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCell cell = row.Cells[BUTTON_VIEW_COLUMN_INDEX];//Column Index
                cell.Value = "View";
                
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCell cell = row.Cells[BUTTON_VIEW_COLUMN_INDEX + 1];//Column Index
                cell.Value = "Print";
            }
        }
       
        private void btn_search_Click_1(object sender, EventArgs e)
        {
            if (txt_name_sname.Text != "")
            {  
                BindDataGrid(txt_name_sname);
            }
            else if (txt_pid.Text != "")
            {
                BindDataGrid(txt_pid);
            }
            else
            {
                BindDataGrid(txt_site_location);
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

                var emp = new EmployeeForm(engine);
                emp.Show();
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
        private void btn_load_Click(object sender, EventArgs e)
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

                if (txt_pid.Text != "")
                {
                    var emp = new EmployeeForm(engine, txt_pid.Text);
                    emp.Show();
                    this.Hide();
                }
                else
                {
                    var emp = new EmployeeForm(engine);
                    emp.Show();
                    this.Hide();
                }

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == BUTTON_VIEW_COLUMN_INDEX && e.RowIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        this.UseWaitCursor = true;
                        var emp_id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        var form = new EmployeeForm(emp_id);
                        form.Show();
                        this.UseWaitCursor = false;
                        Close();

                    }
                     
                }
                //Perform on button click code
            }
        }


    }
}
