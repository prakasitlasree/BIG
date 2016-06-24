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
        }

        private void btn_load_pid_Click(object sender, EventArgs e)
        {

        }
    }
}
