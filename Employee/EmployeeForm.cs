using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIG.BusinessLogic;
using BIG.Model;

namespace BIG.Present
{
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }
        #region ===Method===
        private BIG.Model.Employee getobjectfrominput()
        {

            var emp = new BIG.Model.Employee();
            try
            {

                emp = new BIG.Model.Employee();
                emp.EMP_ID = txt_empid.Text;
                emp.ID_CARD = txt_pid.Text;

                return emp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return emp;
            }

            
        }

        private bool CheckAlreadyEmployee(BIG.Model.Employee emp)
        {
            var result = false;
            try
            {





                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return result;
            }
        }

        private void CreateNewEmployee(BIG.Model.Employee emp)
        {

        }

        private void UpdateEmployee(BIG.Model.Employee emp)
        {

        }

        private bool Save()
        {
            var result = false;
            try
            {
                var empl = getobjectfrominput();
                if (!CheckAlreadyEmployee(empl))
                {
                    //new emp
                    CreateNewEmployee(empl);
                }
                else
                {

                }




                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return result;
            }
        }

        #endregion
        public EmployeeForm(BIG.Model.Employee emp)
        {
            this.employee = emp;
         }

        public BIG.Model.Employee employee { get; set; }

        private void EmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            
            
        }

        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            var pr = new PersonalForm();
            pr.Show();
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
