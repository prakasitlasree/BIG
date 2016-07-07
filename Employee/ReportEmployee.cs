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
    public partial class ReportEmployee : Form
    {
        public ReportEmployee()
        {
            InitializeComponent();
        }

        private void ReportEmployee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'BIG_DBDataSet.Employee' table. You can move, or remove it, as needed.
            //this.EmployeeTableAdapter.Fill(this.BIG_DBDataSet.Employee);
         
            BIG_DBDataSet.EnforceConstraints = false; 

            this.EmployeeTableAdapter.FillByEmpID(this.BIG_DBDataSet.Employee, txt_emp_id.Text);

            this.PermanentAddressTableAdapter.FillByEmpID(this.BIG_DBDataSet.PermanentAddress, txt_emp_id.Text);

            this.AddressTableAdapter.FillByEmpID(this.BIG_DBDataSet.Address, txt_emp_id.Text);

            this.CurrentImagesTableAdapter.FillByEmpID(this.BIG_DBDataSet.CurrentImages, txt_emp_id.Text);

            this.EducationTableAdapter.FillByEmpID(this.BIG_DBDataSet.Education, txt_emp_id.Text);
            
            this.ReferencePersonTableAdapter.FillByEmpID(this.BIG_DBDataSet.ReferencePerson, txt_emp_id.Text);

            this.TrainingTableAdapter.FillByEmpID(this.BIG_DBDataSet.Training, txt_emp_id.Text);

            this.WorkExperienceTableAdapter.FillByEmpID(this.BIG_DBDataSet.WorkExperience, txt_emp_id.Text);

            this.FingerScanTableAdapter.FillByEmpID(this.BIG_DBDataSet.FingerScan,txt_emp_id.Text);
             
            this.reportViewer1.RefreshReport();
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

                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสพนักงาน");
                txt_emp_id.Focus();
            }
        }
    }
}
