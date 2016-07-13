using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BIG.BusinessLogic;
using BIG.Model;
using BIG.Common;
using System.IO;
using BIG.DataService;

namespace BIG.Present
{
    public partial class CompanyInfoForm : Form
    {
        public CompanyInfoForm()
        {
            InitializeComponent();
        }


        private void CompanyInfoForm_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var obj = CompanyInfoServices.Get();
            if (obj != null)
            {
                txt_com_name_th.Text = obj.NAME_TH;
                txt_comname_en.Text = obj.NAME_EN;
                txt_location.Text = obj.LOCATION;
                txt_tel.Text = obj.TELEPHONE;
                if (obj.LOGO != null)
                {
                    pic_company.Image = GetImage(obj.LOGO, 150, 150);
                }
                if (obj.RIGHT_LOGO_1 != null)
                {
                    pic_logo_1.Image = GetImage(obj.RIGHT_LOGO_1, 158, 128);
                }
                if (obj.RIGHT_LOGO_2 != null)
                {
                    pic_logo_2.Image = GetImage(obj.RIGHT_LOGO_2, 158, 128);
                }
                label1.Focus();
                this.Cursor = Cursors.Default;
            }
        }
        private Image GetImage(byte[] PHOTO, int width, int height)
        {
            var myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            var myBitmap = new Bitmap(byteArrayToImage(PHOTO));
            var myThumbnail = myBitmap.GetThumbnailImage(width, height, myCallback, IntPtr.Zero);
            return myThumbnail;
        }
        private System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert, System.Drawing.Imaging.ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception ex) { throw ex; }
            return Ret;
        }

        private void btn_upload_1_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        var myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                        var myBitmap = new Bitmap(file);
                        var myThumbnail = myBitmap.GetThumbnailImage(150, 149, myCallback, IntPtr.Zero);
                        pic_company.Image = myThumbnail;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error pic_company: " + ex.Message);
                    }
                }
            }
        }

        private void btn_upload_2_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        var myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                        var myBitmap = new Bitmap(file);
                        var myThumbnail = myBitmap.GetThumbnailImage(150, 149, myCallback, IntPtr.Zero);
                        pic_logo_1.Image = myThumbnail;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error pic_logo_1: " + ex.Message);
                    }
                }
            }
        }

        private void btn_upload_3_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        var myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                        var myBitmap = new Bitmap(file);
                        var myThumbnail = myBitmap.GetThumbnailImage(150, 149, myCallback, IntPtr.Zero);
                        pic_logo_2.Image = myThumbnail;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error pic_logo_2: " + ex.Message);
                    }
                }
            }
        }

        private void rb_save_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (worker_save.IsBusy == false)
            {
                worker_save.RunWorkerAsync();
            } 
        }

        private void rb_home_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var frm = new MainForm();
            frm.Show();
            Close();
        }

        private void rb_new_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (backgroundWorker1.IsBusy == false)
            { 
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                var frm = new EmployeeForm();
                frm.Show();
                
            })); 
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            Close();
        }

        private void worker_save_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var company = new CompanyInfo();
                company.NAME_EN = txt_comname_en.Text;
                company.NAME_TH = txt_com_name_th.Text;
                company.LOCATION = txt_location.Text;
                company.TELEPHONE = txt_tel.Text;
                company.LOGO = ConvertImageToByteArray(pic_company.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
                company.RIGHT_LOGO_1 = ConvertImageToByteArray(pic_logo_1.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
                company.RIGHT_LOGO_2 = ConvertImageToByteArray(pic_logo_2.Image, System.Drawing.Imaging.ImageFormat.Jpeg);

                CompanyInfoServices.Add(company);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            finally
            {
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย!!!");
                //this.Cursor = Cursors.Default;
            }
        }

        private void worker_save_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void rb_logout_Click(object sender, EventArgs e)
        {
            var frm = new LoginForm();
            frm.Show();
            Close();
        }

        private void rb_exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการออกจากโปรแกรมจัดการข้อมูลลพนักงานหรือไม่?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void rb_personal_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var frm = new PersonalForm();
            frm.Show();
            Close();
        }
    }
}
