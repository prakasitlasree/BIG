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
    public partial class CameraForm : Form
    {
        WebCam webcam;
        public CameraForm()
        { 
            InitializeComponent(); 
        }
        
        private void bntStart_Click(object sender, EventArgs e)
        {
            try
            { 
                webcam.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bntStop_Click(object sender, EventArgs e)
        {
            webcam.Stop();
        }

        private void bntContinue_Click(object sender, EventArgs e)
        {
            webcam.Continue();
        }

        private void bntCapture_Click(object sender, EventArgs e)
        {
            try
            {
                imgCapture.Image = imgVideo.Image;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bntSave_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgVideo);
        }
    }
}
