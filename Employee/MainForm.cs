using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Neurotec.Biometrics;
namespace BIG.Present
{
    public partial class MainForm : Form
    {

        Nffv _engine;
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(Nffv engine)
        {
            _engine = engine;
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการออกจากโปรแกรม?", "ยินยันการออกจากโปรแกรม", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
                //this.Close();
            }
            else if (result == DialogResult.No)
            {
                //...
            }
            else
            {
                //...
            } 

        }

        private void lnk_employee_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var personal = new PersonalForm();
            personal.Show();
        }

        private void btn_employee_Click(object sender, EventArgs e)
        {
            this.Hide();
            var personal = new PersonalForm();
            personal.Show();
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            Neurotec.Biometrics.Nffv engine = null;
            try
            {

                try
                {
                    engine = new Neurotec.Biometrics.Nffv("FingerprintDB.CSharpSample.dat", "", "UareU");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Failed to initialize Nffv or create/load database.\r\n" +
                    "Please check if:\r\n - Provided password is correct;\r\n - Database filename is correct;\r\n" +
                    " - Scanners are used properly.\r\n", "Nffv C# Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Application.Run(new MainForm(engine, chooseScannerForm.UserDatabase)); 
                this.Hide();
                var personal = new TestForm(engine);
                personal.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("An error has occured: {0}", ex.Message), "Nffv C# Sample",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (engine != null)
                {
                    engine.Dispose();
                }
            } 
        }

        private void lnk_setting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Neurotec.Biometrics.Nffv engine = null;
            try
            {

                try
                {
                    engine = new Neurotec.Biometrics.Nffv("FingerprintDB.CSharpSample.dat", "", "UareU");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "Failed to initialize Nffv or create/load database.\r\n" +
                    "Please check if:\r\n - Provided password is correct;\r\n - Database filename is correct;\r\n" +
                    " - Scanners are used properly.\r\n", "Nffv C# Sample", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Application.Run(new MainForm(engine, chooseScannerForm.UserDatabase)); 
                this.Hide();
                var personal = new TestForm(engine);
                personal.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("An error has occured: {0}", ex.Message), "Nffv C# Sample",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (engine != null)
                {
                    engine.Dispose();
                }
            } 
        }

        private void btn_report_Click(object sender, EventArgs e)
        {

            this.Close();
            var frm = new ReportEmployee();
            frm.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            this.Close();
            var frm = new ReportEmployee();
            frm.Show();
        }
         
    }
}
