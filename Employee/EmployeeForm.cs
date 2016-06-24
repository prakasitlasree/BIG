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
    }
}
