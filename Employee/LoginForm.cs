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
            try
            {
                var obj = LogOnServices.Login(txtusername.Text, txtpassword.Text);
                if (obj)
                {
                    var main = new MainForm();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถเข้าใช้งานระบบได้ กรุณาติดต่อผู้ดูแลระบบ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
             
        }
    }
}
