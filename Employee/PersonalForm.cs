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

namespace BIG.Present
{
    public partial class PersonalForm : Form
    {
        public PersonalForm()
        {
            InitializeComponent();
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
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lst;

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
            var emp = new EmployeeForm();
            emp.Show();
            this.Hide();
        }

        private void rb_load_emp_Click(object sender, EventArgs e)
        {
            var emp = new EmployeeForm();
            emp.LoadPID();
            emp.Show();
            this.Hide();
        }
    }
}
