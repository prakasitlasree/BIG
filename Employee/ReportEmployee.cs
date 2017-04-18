using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIG.Model;
using BIG.Common;
using System.IO;
using BIG.DataService;

namespace BIG.Present
{
    public partial class ReportEmployee : Form
    {
        public ReportEmployee()
        {
            InitializeComponent();
        }

        private string _emp_id = "";
        public ReportEmployee(string emp_id)
        {
            InitializeComponent();
            _emp_id = emp_id;
            txt_emp_id.Text = emp_id;
        }
        private void ReportEmployee_Load(object sender, EventArgs e)
        {
            var emp = EmployeeServices.GetAll();
            var ListEmp = from p in emp
                    select new { p.EMP_ID, FIRSTNAME_TH = string.Format("{0} {1}", p.FIRSTNAME_TH ,p.LASTNAME_TH) };
            var obj = new { EMP_ID = "0", FIRSTNAME_TH = "กรุณาเลือก" };

             
            cbo_name.DataSource = ListEmp.ToList();
            cbo_name.DisplayMember = "FIRSTNAME_TH";
            cbo_name.ValueMember = "EMP_ID";
            cbo_name.Text = "== กรุณาเลือก ==";

            // TODO: This line of code loads data into the 'BIG_DBDataSet.Employee' table. You can move, or remove it, as needed.
            //this.EmployeeTableAdapter.Fill(this.BIG_DBDataSet.Employee);
            try
            {
                this.Cursor = Cursors.WaitCursor;
                BIG_DBDataSet.EnforceConstraints = false;

                this.EmployeeTableAdapter.FillByEmpID(this.BIG_DBDataSet.Employee, txt_emp_id.Text);

                this.PermanentAddressTableAdapter.FillByEmpID(this.BIG_DBDataSet.PermanentAddress, txt_emp_id.Text);

                this.AddressTableAdapter.FillByEmpID(this.BIG_DBDataSet.Address, txt_emp_id.Text);

                this.CurrentImagesTableAdapter.FillByEmpID(this.BIG_DBDataSet.CurrentImages, txt_emp_id.Text);

                this.EducationTableAdapter.FillByEmpID(this.BIG_DBDataSet.Education, txt_emp_id.Text);

                this.ReferencePersonTableAdapter.FillByEmpID(this.BIG_DBDataSet.ReferencePerson, txt_emp_id.Text);

                this.TrainingTableAdapter.FillByEmpID(this.BIG_DBDataSet.Training, txt_emp_id.Text);

                this.WorkExperienceTableAdapter.FillByEmpID(this.BIG_DBDataSet.WorkExperience, txt_emp_id.Text);

                this.FingerScanTableAdapter.FillByEmpID(this.BIG_DBDataSet.FingerScan, txt_emp_id.Text);

                this.ReferenceDocumentsTableAdapter.FillByEmpID(this.BIG_DBDataSet.ReferenceDocuments, txt_emp_id.Text);

                this.CompanyInfoTableAdapter.Fill(this.BIG_DBDataSet.CompanyInfo);

                this.reportViewer1.RefreshReport();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ReportEmployee_Load...." + ex.Message);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_emp_id.Text != string.Empty)
            {
                BIG_DBDataSet.EnforceConstraints = false;

                this.EmployeeTableAdapter.FillByEmpID(this.BIG_DBDataSet.Employee, txt_emp_id.Text);

                this.PermanentAddressTableAdapter.FillByEmpID(this.BIG_DBDataSet.PermanentAddress, txt_emp_id.Text);

                this.AddressTableAdapter.FillByEmpID(this.BIG_DBDataSet.Address, txt_emp_id.Text);

                this.CurrentImagesTableAdapter.FillByEmpID(this.BIG_DBDataSet.CurrentImages, txt_emp_id.Text);

                this.EducationTableAdapter.FillByEmpID(this.BIG_DBDataSet.Education, txt_emp_id.Text);

                this.ReferencePersonTableAdapter.FillByEmpID(this.BIG_DBDataSet.ReferencePerson, txt_emp_id.Text);

                this.TrainingTableAdapter.FillByEmpID(this.BIG_DBDataSet.Training, txt_emp_id.Text);

                this.WorkExperienceTableAdapter.FillByEmpID(this.BIG_DBDataSet.WorkExperience, txt_emp_id.Text);

                this.FingerScanTableAdapter.FillByEmpID(this.BIG_DBDataSet.FingerScan, txt_emp_id.Text);

                this.ReferenceDocumentsTableAdapter.FillByEmpID(this.BIG_DBDataSet.ReferenceDocuments, txt_emp_id.Text);

                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสพนักงาน");
                txt_emp_id.Focus();
            }
        }
        private void cbo_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            var emp_id = cbo_name.SelectedValue.ToString();
            if (cbo_name.SelectedIndex != 0)
            {
                txt_emp_id.Text = "";
            }
            BIG_DBDataSet.EnforceConstraints = false;

            this.EmployeeTableAdapter.FillByEmpID(this.BIG_DBDataSet.Employee, emp_id);

            this.PermanentAddressTableAdapter.FillByEmpID(this.BIG_DBDataSet.PermanentAddress, emp_id);

            this.AddressTableAdapter.FillByEmpID(this.BIG_DBDataSet.Address, emp_id);

            this.CurrentImagesTableAdapter.FillByEmpID(this.BIG_DBDataSet.CurrentImages, emp_id);

            this.EducationTableAdapter.FillByEmpID(this.BIG_DBDataSet.Education, emp_id);

            this.ReferencePersonTableAdapter.FillByEmpID(this.BIG_DBDataSet.ReferencePerson, emp_id);

            this.TrainingTableAdapter.FillByEmpID(this.BIG_DBDataSet.Training, emp_id);

            this.WorkExperienceTableAdapter.FillByEmpID(this.BIG_DBDataSet.WorkExperience, emp_id);

            this.FingerScanTableAdapter.FillByEmpID(this.BIG_DBDataSet.FingerScan, emp_id);

            this.ReferenceDocumentsTableAdapter.FillByEmpID(this.BIG_DBDataSet.ReferenceDocuments, emp_id);

            this.reportViewer1.RefreshReport();
        }
        private void ReportEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void rb_exit_CanvasChanged(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rb_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            var form = new LoginForm();
            form.Show();
        }

        private void rb_home_Click(object sender, EventArgs e)
        {
            this.Close();
            var form = new PersonalForm();
            form.Show();
        }

        private void rb_new_Click(object sender, EventArgs e)
        {
            this.Close();
            var form = new EmployeeForm();
            form.Show();

        }

        private void rb_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rb_personal_Click(object sender, EventArgs e)
        {
            this.Close();
            var frm = new PersonalForm();
            frm.Show();

        }


    }
}
