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
    public partial class FormAddSite : Form
    {
        public FormAddSite()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_name.Text != "")
            {
                try
                {
                    var obj = new Site();
                    obj.NAME = txt_name.Text;
                    obj.CREATE_DATE = DateTime.Now;
                    DataService.SitesDataService.SaveSites(obj);
                    MessageBox.Show("บันทึกข้อมูลเรียบร้อย");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" btn_save_Click : " + ex.Message);
                    this.Close();
                }
                
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
