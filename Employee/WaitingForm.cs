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

    public partial class WaitingForm : Form
    {

        private RunWorkerCompletedEventArgs results;
        public WaitingForm()
        {
            InitializeComponent();
            Shown += new EventHandler(WaitingForm_Shown);

            // To report progress from the background worker we need to set this property
            backgroundWorker1.WorkerReportsProgress = true;
            // This event will be raised on the worker thread when the worker starts
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            // This event will be raised when we call ReportProgress
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
        }

        private void WaitingForm_Shown(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            { 
                backgroundWorker1.RunWorkerAsync();
            }
        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Your background task goes here
            for (int i = 0; i <= 10; i++)
            {
                // Report progress to 'UI' thread
                backgroundWorker1.ReportProgress(i * 10);
                // Simulate long task
                System.Threading.Thread.Sleep(1000);
            }
        }
        // Back on the 'UI' thread so we can update the progress bar
        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // The progress percentage is a property of e
            progressBar.Value = e.ProgressPercentage;
        }

    }
}
