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
    public partial class EmployeeForm : Form
    {
        private ThaiIDCard CardID = new ThaiIDCard();

        public EmployeeForm()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        #region ===Properties===

        private byte[] _photo;

        public byte[] EmployeePhoto
        {
            get { return _photo; }
            set { _photo = value; }
        }

        #endregion
        #region ===Method===

        private void initialCombobox()
        {
            //en_title 
            var listprov = DataService.ProvinceServices.GetListProvince();
            var list = new List<string>();
            cbo_bp_prov.Items.Clear();
            c_cbo_prov.Items.Clear();
            p_cbo_prov.Items.Clear();
            foreach (var item in listprov)
            {
                cbo_bp_prov.Items.Add("จังหวัด" + item.NAME_TH);
                p_cbo_prov.Items.Add("จังหวัด" + item.NAME_TH);
                c_cbo_prov.Items.Add("จังหวัด" + item.NAME_TH);
            }

            cbo_bp_prov.SelectedIndex = 1;
            cbo_bp_ctr.Items.Clear();
            cbo_bp_ctr.Items.Add("ไทย");
            cbo_bp_ctr.SelectedIndex = 0;


            //amphur
            var listamp = DataService.ProvinceServices.GetListAmphur(cbo_bp_prov.SelectedItem.ToString());
            p_cbo_amp.Items.Clear();
            c_cbo_amp.Items.Clear();
            foreach (var item in listamp)
            {
                p_cbo_amp.Items.Add("อำเภอ" + item.NAME_TH);
                c_cbo_amp.Items.Add("อำเภอ" + item.NAME_TH);
            }

            //addrestype
            var addrType = DataService.AddressServices.GetAddressTypeList();
            c_add_type.Items.Clear();
            foreach (var item in addrType)
            {
                c_add_type.Items.Add(item.NAME);
            }
            c_add_type.SelectedIndex = 0;

            //etc
            cbo_race.SelectedIndex = 0;
            cbo_relegion.SelectedIndex = 0;
            cbo_nationality.SelectedIndex = 0;

        }

        private BIG.Model.Employee getEmployeefrominput()
        {

            var emp = new BIG.Model.Employee();
            try
            {

                //General 
                emp = new BIG.Model.Employee();
                emp.EMP_ID = txt_empid.Text;
                emp.ID_CARD = txt_pid.Text;
                emp.TITLE_ID = Convert.ToInt32(cbo_title_th.SelectedIndex + 1);
                emp.FIRSTNAME_TH = txt_emp_fname_th.Text;
                emp.LASTNAME_TH = txt_emp_lname_th.Text;
                emp.FIRSTNAME_EN = txt_emp_fname_en.Text;
                emp.LASTNAME_EN = txt_emp_lname_en.Text;
                emp.NICKNAME_TH = txt_nick_th.Text;
                emp.NICKNAME_EN = txt_nick_en.Text;
                emp.DATEOFBIRTH = Convert.ToDateTime(dob.Text);
                emp.BIRTH_PLACE_PROVINCE_ID = "02";//cbo_bp_ctr.SelectedItem.ToString();
                emp.BIRTH_PLACE_CONTRY = cbo_bp_ctr.SelectedItem.ToString();
                emp.GENDER_ID = Convert.ToInt32(cbo_sex.SelectedIndex + 1);
                emp.HEIGHT = Convert.ToInt32(txt_height.Text);
                emp.WEIGHT = Convert.ToInt32(txt_weight.Text);
                emp.RACE = cbo_race.SelectedItem.ToString();
                emp.NATIONALITY = cbo_nationality.SelectedItem.ToString();
                emp.RELEGION = cbo_relegion.SelectedItem.ToString();
                emp.MARITAL_ID = 1;
                emp.POSITION_ID = 1;

                return emp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return emp;
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

        private Emp_Images getPhotoEmployee()
        {
            var ret = new Emp_Images();

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

        private bool CheckAlreadyEmployee(BIG.Model.Employee emp)
        {
            var result = false;
            try
            {
                var listemp = DataService.EmployeeServices.GetListPID();
                var obj = listemp.Where(x => x.ID_CARD == emp.ID_CARD).FirstOrDefault();
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

        public void LoadPID()
        {
            this.UseWaitCursor = true;

            try
            {
                 
                initialCombobox();
                var idcard = CardID.readAll(true);
                if (idcard != null)
                {
                    var lastemp_id = DataService.EmployeeServices.GetLastEmployeeID();
                     
                    lastemp_id = DateTime.Now.ToString("yyMMddHHmm");
                     

                    txt_empid.Text = lastemp_id;
                    txt_pid.Text = idcard.Citizenid;
                    cbo_title_th.SelectedItem = idcard.Th_Prefix;
                    txt_emp_fname_th.Text = idcard.Th_Firstname;
                    txt_emp_lname_th.Text = idcard.Th_Lastname;
                    txt_emp_fname_en.Text = idcard.En_Firstname;
                    txt_emp_lname_en.Text = idcard.En_Lastname;
                    dob.Value = idcard.Birthday;
                    cbo_bp_ctr.SelectedValue = idcard.addrProvince;

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
                    c_cbo_prov.SelectedItem = idcard.addrProvince;
                    c_cbo_amp.SelectedItem = idcard.addrAmphur;

                    //permanent address
                    p_txt_no.Text = idcard.addrHouseNo + " " + idcard.addrVillageNo + " " + idcard.addrLane + " " + idcard.addrRoad;
                    p_txt_road.Text = idcard.addrRoad;
                    p_txt_soi.Text = "";
                    p_txt_tumbol.Text = idcard.addrTambol;
                    p_cbo_prov.SelectedItem = idcard.addrProvince;
                    p_cbo_amp.SelectedItem = idcard.addrAmphur;
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

                    MessageBox.Show("โหลดข้อมูลบัตรประชาชนเรียบร้อย!!!");
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
                //Add Employee
                var employee = getEmployeefrominput();

                if (!CheckAlreadyEmployee(employee))
                {
                    //new emp
                    CreateNewEmployee(employee);

                }
                else
                {
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

        private bool UploadPhoto(Emp_Images Img)
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

        public EmployeeForm(BIG.Model.Employee emp)
        {
            this.employee = emp;
        }

        public BIG.Model.Employee employee { get; set; }

        private void EmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {



        }

        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("คุณต้องการบันทึกข้อมูลพนักงาน?", "Confirmation", MessageBoxButtons.YesNoCancel);
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
            var listamp = DataService.ProvinceServices.GetListAmphur(c_cbo_prov.SelectedItem.ToString());
            c_cbo_amp.SelectedItem = null;
            c_cbo_amp.Items.Clear();
            foreach (var item in listamp)
            {
                c_cbo_amp.Items.Add("อำเภอ" + item.NAME_TH);
            }

        }

        private void p_cbo_prov_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listamp = DataService.ProvinceServices.GetListAmphur(p_cbo_prov.SelectedItem.ToString());
            p_cbo_amp.SelectedItem = null;
            p_cbo_amp.Items.Clear();
            foreach (var item in listamp)
            {
                p_cbo_amp.Items.Add("อำเภอ" + item.NAME_TH);
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
                        var myThumbnail = myBitmap.GetThumbnailImage(150, 187, myCallback, IntPtr.Zero);
                        pic_emp.Image = myThumbnail;

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
            pic_emp.Image = BIG.Present.Properties.Resources.ee;
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
            this.Close();

        }

    }
}
