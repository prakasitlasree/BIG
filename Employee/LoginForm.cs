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

using Neurotec.Biometrics;
namespace BIG.Present
{
    public partial class LoginForm : Form
    {
        Nffv _engine;
        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(Nffv engine)
        {
            _engine = engine;
            InitializeComponent();
        }

        private void bt_logon_Click(object sender, EventArgs e)
        { 
            Login(); 
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void txtusername_Enter(object sender, EventArgs e)
        {

        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {

        }


        private void Login()
        {
            try
            {
                if (txtusername.Text != "" || txtpassword.Text != "")
                {
                    var obj = LogOnServices.Login(txtusername.Text, txtpassword.Text);
                    if (obj)
                    {
                        var main = new MainForm();
                        main.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถเข้าใช้งานระบบได้ กรุณาติดต่อผู้ดูแลระบบ");
                        txtusername.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("กรุณากรอก username และ password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
