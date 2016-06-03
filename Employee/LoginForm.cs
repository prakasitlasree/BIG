using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIG.Model;
using BIG.DataService;

namespace BIG.Present
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void bt_logon_Click(object sender, EventArgs e)
        {
            var obj = LogOnServices.Login(txtusername.Text, txtpassword.Text);
            if (obj)
            {
                MessageBox.Show("Hello");
            }
            else
            {
                MessageBox.Show("Bye");
            }
        }
    }
}
