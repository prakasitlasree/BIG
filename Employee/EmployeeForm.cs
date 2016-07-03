﻿using System;
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
using System.Globalization;
using System.Threading;

namespace BIG.Present
{
    public partial class EmployeeForm : Form
    {
        private ThaiIDCard CardID = new ThaiIDCard();

        public EmployeeForm()
        {
            InitializeComponent();
            initialCombobox(); 

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        #region ===Properties===

        private byte[] _photo;

        public byte[] EmployeePhoto
        {
            get { return _photo; }
            set { _photo = value; }
        }

        public List<Province> ListProvince { get; set; }

        #endregion

        #region ===Method===

        private void initialCombobox()
        {
            //Province
            this.InitialProvince();

            //Possition
            this.InitialPosition();

            //birth place
            cbo_bp_ctr.Items.Clear();
            cbo_bp_ctr.Items.Add("ไทย");
            cbo_bp_ctr.SelectedIndex = 0;

            //Site Location
            this.ReloadSites();

            //amphur
            this.InitialAmphur();

            //addrestype
            this.InitialAddressType();
             
            //etc
            
            if (c_add_type.Items.Count > 0)
            {
                c_add_type.SelectedIndex = 0;
            }
            if (cbo_race.Items.Count > 0)
            {
                cbo_race.SelectedIndex = 0;
            }
            if (cbo_relegion.Items.Count > 0)
            {
                cbo_relegion.SelectedIndex = 0;
            }
            if (cbo_nationality.Items.Count > 0)
            {
                cbo_nationality.SelectedIndex = 0;
            } 
        }

        private void InitialProvince()
        {
            var listprov = DataService.ProvinceServices.GetListProvince();

            var prov1 = listprov.Select(x => new { x.PROVINCE_ID,x.PROVINCE_NAME}).ToList();

            var prov2 = listprov.Select(x => new { x.PROVINCE_ID, x.PROVINCE_NAME }).ToList();

            var prov3 = listprov.Select(x => new { x.PROVINCE_ID, x.PROVINCE_NAME }).ToList();
             
            cbo_bp_prov.Items.Clear();
            c_cbo_prov.Items.Clear();
            p_cbo_prov.Items.Clear();
            cbo_bp_prov.DataSource = prov1;
            cbo_bp_prov.DisplayMember = "PROVINCE_NAME";
            cbo_bp_prov.ValueMember = "PROVINCE_ID";

            c_cbo_prov.DataSource = prov2;
            c_cbo_prov.DisplayMember = "PROVINCE_NAME";
            c_cbo_prov.ValueMember = "PROVINCE_ID";

            p_cbo_prov.DataSource = prov3;
            p_cbo_prov.DisplayMember = "PROVINCE_NAME";
            p_cbo_prov.ValueMember = "PROVINCE_ID";

            cbo_bp_prov.SelectedIndex = 0;
            c_cbo_prov.SelectedIndex = 0;
            p_cbo_prov.SelectedIndex = 0;
        }

        private void InitialAmphur()
        {
           
            if (p_cbo_prov.SelectedItem != null)
            { 
                var listamp = ProvinceServices.GetListAmphur(Convert.ToInt16(p_cbo_prov.SelectedValue.ToString()));

                p_cbo_amp.DataSource = listamp;
                p_cbo_amp.DisplayMember = "AMPHUR_NAME";
                p_cbo_amp.ValueMember = "AMPHUR_ID"; 
            }
            if (c_cbo_prov.SelectedItem != null)
            { 
                var listamp = ProvinceServices.GetListAmphur(Convert.ToInt16(c_cbo_prov.SelectedValue.ToString()));
                c_cbo_amp.DataSource = listamp;
                c_cbo_amp.DisplayMember = "AMPHUR_NAME";
                c_cbo_amp.ValueMember = "AMPHUR_ID"; 
            } 
        }

        private void InitialAddressType()
        {
            var addrType = DataService.AddressServices.GetAddressTypeList();
            c_add_type.Items.Clear();
            foreach (var item in addrType) 
            {
                c_add_type.Items.Add(item.NAME);
            }
        }

        private void InitialPosition()
        { 
            var lstpos = PossitionDataService.GetAll();
            cbo_possition.Items.Clear();
            foreach (var item in lstpos)
            {
                var cbitem = new ComboboxItem();
                cbitem.Text = item.NAME;
                cbitem.Value = item.ID;
                cbo_possition.Items.Add(cbitem);
            }
            if (cbo_possition.Items.Count > 0)
            {
                cbo_possition.SelectedIndex = 0;
            }

        }

        private BIG.Model.Employee getEmployeefrominput()
        {

            var emp = new BIG.Model.Employee();
            try
            {

                //General 
                emp = new BIG.Model.Employee();
                emp.EMP_ID = txt_empid.Text; //รหัสพนักงาน
                emp.ID_CARD = txt_pid.Text; // บัตรประชาชน
                emp.TITLE_ID = Convert.ToInt32(cbo_title_th.SelectedIndex + 1); //คำนำหน้า
                emp.FIRSTNAME_TH = txt_emp_fname_th.Text; //ชื่อไทย
                emp.LASTNAME_TH = txt_emp_lname_th.Text; //นามสกุลไทย
                emp.FIRSTNAME_EN = txt_emp_fname_en.Text; //ชื่ออังกฤษ
                emp.LASTNAME_EN = txt_emp_lname_en.Text; //นามสกุลอังกฤษ
                emp.NICKNAME_TH = txt_nick_th.Text; //ชื่อเล่น
                emp.NICKNAME_EN = txt_possition.Text; //ตำแหน่ง
                emp.DATEOFBIRTH = Convert.ToDateTime(dob.Text);//ว ด ป เกิด
                emp.BIRTH_PLACE_PROVINCE = (cbo_bp_prov.SelectedItem as ComboboxItem).Text; //จังหวัดที่เกิด
                emp.BIRTH_PLACE_CONTRY = cbo_bp_ctr.SelectedItem.ToString(); //ปรเเทศ เกิด
                emp.GENDER_ID = Convert.ToInt32(cbo_sex.SelectedIndex + 1); //เพศ
                emp.HEIGHT = Convert.ToInt32(txt_height.Text); //สูง
                emp.WEIGHT = Convert.ToInt32(txt_weight.Text); //น้ำหนัก
                emp.RACE = cbo_race.SelectedItem.ToString(); //เชื้อชาติ
                emp.NATIONALITY = cbo_nationality.SelectedItem.ToString();//สัญชาติ
                emp.RELEGION = cbo_relegion.SelectedItem.ToString(); //ศาสนา
                emp.MARITAL_ID = 1; //สถานะสมรส
                emp.POSITION_ID = Convert.ToInt16((cbo_possition.SelectedItem as ComboboxItem).Value); //ตำแหน่ง

                return emp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return emp;
            }


        }

        public void ReloadSites()
        {
            cbo_site.Items.Clear();
            var lstSite = DataService.SitesDataService.GetListSiteLocation().OrderByDescending(x => x.CREATE_DATE).ToList();
            foreach (var item in lstSite)
            {
                cbo_site.Items.Add(item.NAME);
            }
            if (cbo_site.Items.Count > 0)
            {
                cbo_site.SelectedIndex = 0;
            }
        }

        private System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
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
            catch (Exception) { throw; }
            return Ret;
        }

        private List<BIG.Model.Address> getAddressListfrominput()
        {

            var listAddress = new List<BIG.Model.Address>();
            try
            {
                //Current Address
                var current_addr = new BIG.Model.Address();

                current_addr.EMP_ID = txt_empid.Text;
                current_addr.NAME = c_txt_no.Text + " " + c_txt_soi.Text + " " + c_txt_rd.Text + " " + c_txt_tumbol.Text + " ";
                current_addr.AMPHUR_ID = c_cbo_amp.SelectedValue.ToString();
                current_addr.PROVINCE_ID = c_cbo_prov.SelectedValue.ToString();
                current_addr.POSTCODE = "00000";

                //Permanent Address
                var permanent_addr = new BIG.Model.Address();

                permanent_addr.EMP_ID = txt_empid.Text;
                permanent_addr.NAME = p_txt_no.Text + " " + p_txt_soi.Text + " " + p_txt_road.Text + " " + p_txt_tumbol.Text + " ";
                permanent_addr.AMPHUR_ID = p_cbo_amp.SelectedValue.ToString();
                permanent_addr.PROVINCE_ID = p_cbo_prov.SelectedValue.ToString();
                permanent_addr.POSTCODE = "00000";

                listAddress.Add(current_addr);
                listAddress.Add(permanent_addr);

                return listAddress;
            }
            catch (Exception ex)
            {
                return listAddress;
            }
        }

        private EmployeeImage getPhotoEmployee()
        {
            var ret = new EmployeeImage();

            try
            {
                var myBitmap = pic_emp.Image;
                ret.EMP_ID = txt_empid.Text;
                ret.PIC_PROFILE = ConvertImageToByteArray(myBitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
                ret.TYPE = System.Drawing.Imaging.ImageFormat.Jpeg.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
            return ret;
        }

        private bool CheckAlreadyEmployee(string idcard)
        {
            var result = false;
            try
            {
                var obj = DataService.EmployeeServices.GetEmployeeByIDCard(idcard); 
                if (obj != null)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return result;
            }
            return result;
        }

        private Model.Employee GetEmployeeByIDCard(string idcard)
        {
            var ret = new Model.Employee();
            try
            {
                var obj = DataService.EmployeeServices.GetEmployeeByIDCard(idcard); 
                if (obj != null)
                {
                    ret = obj;
                } 
                else
                {
                    return obj;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                 
            }
            return ret;
        }

        private void CreateNewEmployee(BIG.Model.Employee emp)
        {
            EmployeeServices.AddEmployee(emp);
        }

        private void UpdateEmployee(BIG.Model.Employee emp)
        {
            EmployeeServices.UpdateEmployee(emp);
        }

        private void CreateAddress(List<BIG.Model.Address> listAddress)
        {
            DataService.AddressServices.SaveAddress(listAddress);
        }
         
        private string GenNewEmployeeID()
        {
            var ret = "";
            try
            {
                var lastemp_id = DataService.EmployeeServices.GetLastEmployeeID();
                var running = lastemp_id.Substring(lastemp_id.Length - 3, 3);
                var nextnumber = Convert.ToDecimal(running) + 1;
                lastemp_id = DateTime.Now.ToString("yyMMdd") + String.Format("{0:000}", nextnumber); ;
                ret = "BIGS" + lastemp_id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ret;
        }

        public void LoadPID()
        {
            this.UseWaitCursor = true;

            try
            {

                //initialCombobox();
                var idcard = CardID.readAll(true);
                if (idcard != null)
                {
                    
                    var empObj = GetEmployeeByIDCard(idcard.Citizenid);

                    //มีข้อมูลพนักงานอยู่ในระบบ
                    if (empObj != null)
                    {
                        MessageBox.Show("      พบข้อมูลอยู่ในระบบ" + "\r\n\n" + "     รหัสบัตรประชาชน => " + idcard.Citizenid + "\n\n" + "     ชื่อ-สกุล" + empObj.FIRSTNAME_TH + " " + empObj.LASTNAME_TH);
                        lb_isnewemp.Text = "*มีอยู่แล้วในระบบ";
                    }
                    else
                    {
                        MessageBox.Show("     ไม่พบข้อมูลพนักงาน" + "\n\n" + "     รหัสบัตรประชาชน => " + idcard.Citizenid + "\n\n" + "     ชื่อ-สกุล =>" + idcard.Th_Firstname + " " + idcard.Th_Lastname);
                        //ไม่มีข้อมูลพนักงานอยู่ในระบบ
                        lb_isnewemp.Text = "*พนักงานใหม่";
                        txt_empid.Text = GenNewEmployeeID();
                        txt_pid.Text = idcard.Citizenid;
                        cbo_title_th.SelectedItem = idcard.Th_Prefix;
                        cbo_title_en.SelectedItem = idcard.En_Prefix;
                        txt_emp_fname_th.Text = idcard.Th_Firstname;
                        txt_emp_lname_th.Text = idcard.Th_Lastname;
                        txt_emp_fname_en.Text = idcard.En_Firstname;
                        txt_emp_lname_en.Text = idcard.En_Lastname;
                        dob.Value = idcard.Birthday;
                        cbo_bp_ctr.SelectedValue = idcard.addrProvince;


                        //Gender
                        if (idcard.Sex == "1")
                        {
                            cbo_sex.SelectedIndex = 0;
                        }
                        else
                        { cbo_sex.SelectedIndex = 1; }

                        //Cureent Address

                        c_txt_no.Text = idcard.addrHouseNo + " " + idcard.addrVillageNo + " " + idcard.addrLane + " " + idcard.addrRoad;
                        c_txt_rd.Text = idcard.addrRoad;
                        c_txt_soi.Text = "";
                        c_txt_tumbol.Text = idcard.addrTambol;
                        c_cbo_prov.SelectedText = idcard.addrProvince;
                        c_cbo_amp.SelectedText = idcard.addrAmphur;

                        //permanent address
                        p_txt_no.Text = idcard.addrHouseNo + " " + idcard.addrVillageNo + " " + idcard.addrLane + " " + idcard.addrRoad;
                        p_txt_road.Text = idcard.addrRoad;
                        p_txt_soi.Text = "";
                        p_txt_tumbol.Text = idcard.addrTambol;
                        p_cbo_prov.SelectedText = idcard.addrProvince;
                        p_cbo_amp.SelectedText = idcard.addrAmphur;
                        //image
                        if (idcard.PhotoRaw != null)
                        {
                            this.EmployeePhoto = idcard.PhotoRaw;

                            //add to picture box
                            var myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                            var myBitmap = new Bitmap(byteArrayToImage(idcard.PhotoRaw));
                            var myThumbnail = myBitmap.GetThumbnailImage(150, 187, myCallback, IntPtr.Zero);
                            pic_emp.Image = myThumbnail;
                        }
                    } 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.UseWaitCursor = false;
            }
        }

        private bool Save()
        {
            var result = false;
            try
            {
                //Get Object Employee
                var employee = getEmployeefrominput();

                if (!CheckAlreadyEmployee(employee.ID_CARD))
                {
                    //add new employee
                    CreateNewEmployee(employee);

                }
                else
                {
                    //update employee
                    UpdateEmployee(employee);
                }


                var photo = getPhotoEmployee();
                UploadPhoto(photo);

                //Save Address
                var listAddress = getAddressListfrominput();
                CreateAddress(listAddress);

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return result;
            }
        }

        private bool UploadPhoto(EmployeeImage Img)
        {
            var result = false;
            try
            {
                ProfileImageDataService.DeletePhoto(Img);
                ProfileImageDataService.UploadPhoto(Img);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        #endregion

        #region ===Events===
         
        public EmployeeForm(BIG.Model.Employee emp)
        {
            this.employee = emp;
        }

        public BIG.Model.Employee employee { get; set; }
  
        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการออกจากโปรแกรมจัดการข้อมูลลพนักงานหรือไม่?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                //...
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการบันทึกข้อมูลพนักงาน?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Save();
                MessageBox.Show("บันทึกข้อมูลบัตรประชาชนเรียบร้อย!!!");
                this.Hide();
                var fm = new EmployeeForm();
                fm.Show();
            }
            else if (result == DialogResult.No)
            {
                //...
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void ribbon_tab_load_pid_ActiveChanged(object sender, EventArgs e)
        {
            LoadPID();
        }

        private void ribbon_tab_load_pid_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void ribbon_tab_load_pid_OwnerChanged(object sender, EventArgs e)
        {


        }

        private void rb_new_emp_Click(object sender, EventArgs e)
        {
            this.Hide();
            var fm = new EmployeeForm();
            fm.Show();
        }

        private void rb_load_emp_Click(object sender, EventArgs e)
        {
            LoadPID();
        }

        private void rb_save_emp_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการบันทึกข้อมูลพนักงาน?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                this.Save();
                MessageBox.Show("บันทึกข้อมูลบัตรประชาชนเรียบร้อย!!!");
            }
            else if (result == DialogResult.No)
            {
                //...
            }
        }

        private void rb_close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการออกจากโปรแกรม?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else if (result == DialogResult.No)
            {
                //...
            }
        }

        private void c_cbo_prov_SelectedIndexChanged(object sender, EventArgs e)
        {
            var province_id = 0;
            int.TryParse(c_cbo_prov.SelectedValue.ToString(), out province_id);

            if (province_id != 0)
            {
                c_cbo_prov.SelectedIndex = 1;
                var listamp1 = ProvinceServices.GetListAmphur(province_id);
                c_cbo_amp.DataSource = listamp1;
                c_cbo_amp.DisplayMember = "AMPHUR_NAME";
                c_cbo_amp.ValueMember = "AMPHUR_ID";
            } 

            txt_postcode.Focus();
        }

        private void p_cbo_prov_SelectedIndexChanged(object sender, EventArgs e)
        {
            var province_id = 0;
            int.TryParse(p_cbo_prov.SelectedValue.ToString(), out province_id);

            if (province_id != 0)
            {
                var listamp2 = ProvinceServices.GetListAmphur(province_id);

                p_cbo_amp.DataSource = listamp2;
                p_cbo_amp.DisplayMember = "AMPHUR_NAME";
                p_cbo_amp.ValueMember = "AMPHUR_ID";
            }
             
        }

        private void btn_new_img_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";

            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Select Photo";

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
                        pic_current.Image = myThumbnail;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        private void btn_delete_img_Click(object sender, EventArgs e)
        {
            pic_current.Image = BIG.Present.Properties.Resources.big_employee;
        }

        private void rb_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainform = new MainForm();
            mainform.Show();

        }

        private void rb_new_Click(object sender, EventArgs e)
        {
            this.Hide();
            var emp_frm = new EmployeeForm();
            emp_frm.Show();
        }

        private void rb_load_pid_Click(object sender, EventArgs e)
        {

            LoadPID();
        }

        private void rb_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void rb_save_Click(object sender, EventArgs e)
        {

        }

        private void rb_logout_Click(object sender, EventArgs e)
        {
            this.Close();
            var frm = new LoginForm();
            frm.Show();
        }

        private void btn_add_site_Click(object sender, EventArgs e)
        {
            var frm = new FormAddSite();
            frm.Show();
        }

        private void btn_refresh_site_Click(object sender, EventArgs e)
        {
            ReloadSites();
        }

        #endregion
    }
}
