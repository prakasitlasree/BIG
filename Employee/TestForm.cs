using BIG.DataService;
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
    public partial class TestForm : Form
    {


        Nffv _engine;
         
        public TestForm()
        {
            InitializeComponent();
        }
        public TestForm(Nffv engine)
		{
			_engine = engine;
            
			InitializeComponent();
		}
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cleardatabase();
                RunWorkerCompletedEventArgs taskResult = BusyForm.RunLongTask("Waiting for fingerprint ...", new DoWorkEventHandler(doEnroll),
                    false, null, new EventHandler(CancelScanningHandler));
                EnrollmentResult enrollmentResult = (EnrollmentResult)taskResult.Result;
                if (enrollmentResult.engineStatus == NffvStatus.TemplateCreated)
                {
                    NffvUser engineUser = enrollmentResult.engineUser;

                     

                }
                else
                {
                    NffvStatus engineStatus = enrollmentResult.engineStatus;
                    MessageBox.Show(string.Format("Enrollment was not finished. Reason: {0}", engineStatus));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
        internal class EnrollmentResult
        {
            public NffvStatus engineStatus;
            public NffvUser engineUser;
        };

        private void CancelScanningHandler(object sender, EventArgs e)
        {
            _engine.Cancel();
        }
        private void doEnroll(object sender, DoWorkEventArgs args)
        {
            EnrollmentResult enrollmentResults = new EnrollmentResult();
            enrollmentResults.engineUser = _engine.Enroll(20000, out enrollmentResults.engineStatus);
            args.Result = enrollmentResults;
        }

        private void cleardatabase()
        {

            _engine.Users.Clear();
             
        }
    }
}
