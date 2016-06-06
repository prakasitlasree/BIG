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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
        private void SplashScreen_Shown(object sender, EventArgs e)
        {
            //set time interval 3 sec
            timer1.Interval = 500;
            //starts the timer
            timer1.Start();
            timer1.Tick += tmr_Tick;
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            //display mainform
            LoginForm mf = new LoginForm();
            mf.Show();
            //hide this form
            this.Hide();
        }
    }
}
