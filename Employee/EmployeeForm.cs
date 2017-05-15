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
using System.Globalization;
using System.Threading;
using Neurotec.Biometrics;
using System.Diagnostics;
namespace BIG.Present
{
    
    public partial class EmployeeForm : Form
    {
        WebCam webcam;
        private ThaiIDCard CardID = new ThaiIDCard();
        public string currentImgName = "";
        Nffv _engine;
         
        public EmployeeForm()
        {
            
            InitializeComponent(); 
            initialCombobox();

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        public EmployeeForm(Nffv engine)
        { 
            _engine = engine;
            InitializeComponent();
            initialCombobox();

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        public EmployeeForm(Nffv engine, string pid)
        { 
            _engine = engine;
            InitializeComponent();
            initialCombobox();

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            SearchPID(pid);
        }

        public EmployeeForm(BIG.Model.Employee emp)
        { 
            this.employee = emp;
        }

        public EmployeeForm(string emp_id, string mode)
        { 
            InitializeComponent();
            initialCombobox();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            SearchEmpID(emp_id);
            if (mode == "View")
            {

                EmployeeMode(false);
            }
            else
            {
                EmployeeMode(true);
            }

        }
        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            webcam = new WebCam();
            webcam.InitializeWebCam(ref imgVideo);
        }
        #region ===Properties===

        private byte[] _photo;

        public byte[] EmployeePhoto
        {
            get { return _photo; }
            set { _photo = value; }
        }

        private List<Province> _province;

        public List<Province> ListProvinces
        {
            get
            {
                if (_province != null || _province.Count == 0)
                {

                    _province = ProvinceServices.GetListProvince().ToList();

                }
                return _province;

            }
            set { _province = value; }
        }

        private List<OtherDocument> _otherdoc;

        public List<OtherDocument> OtherDoc
        {
            get
            {
                if (_otherdoc == null)
                {
                    _otherdoc = new List<OtherDocument>();
                }
                return _otherdoc;
            }
            set
            {
                _otherdoc = value;
            }
        }

        private List<ReferenceDocument> _refdoc;

        public List<ReferenceDocument> RefDoc
        {
            get
            {
                if (_refdoc == null)
                {
                    _refdoc = new List<ReferenceDocument>();
                }
                return _refdoc;
            }
            set
            {
                _refdoc = value;
            }
        }
        private FingerScan _finger;

        public FingerScan FingerScans
        {
            get
            {
                if (_finger == null)
                {
                    _finger = new FingerScan();
                }
                return _finger;
            }
            set
            {
                _finger = value;
            }
        }
        #endregion

        #region ===Method===

        private void EmployeeMode(bool isEnable)
        {
            gb_emp_1.Enabled = isEnable;
            gb_emp2.Enabled = isEnable;
            gb_left_finger.Enabled = isEnable;
            gb_right_finger.Enabled = isEnable;
            gb_current_addr.Enabled = isEnable;
            gb_p_addr.Enabled = isEnable;
            gb_edu_1.Enabled = isEnable;
            gb_edu_2.Enabled = isEnable;
            gb_edu_3.Enabled = isEnable;
            gb_tn_1.Enabled = isEnable;
            gb_train_2.Enabled = isEnable;
            gb_train_3.Enabled = isEnable;
            gb_exp_1.Enabled = isEnable;
            gb_exp_2.Enabled = isEnable;
            gb_exp_3.Enabled = isEnable;
            gb_ref_1.Enabled = isEnable;
            gb_ref_2.Enabled = isEnable;
            gb_ref_3.Enabled = isEnable;
            gb_sso.Enabled = isEnable;
            gb_copy_idcard.Enabled = isEnable;
            gb_copyhome.Enabled = isEnable;
            gb_copymiritaly.Enabled = isEnable;
            gb_otherdoc_1.Enabled = isEnable;
            gb_otherdoc_2.Enabled = isEnable;
            gb_otherdoc_3.Enabled = isEnable;
            gb_equip_1.Enabled = isEnable;
            gb_equip_2.Enabled = isEnable;
            btn_save.Enabled = isEnable;
            btn_cancle.Enabled = isEnable;
            rb_save.Enabled = isEnable;
        }

        private void initialCombobox()
        {
            //GenEmployeeIDSamutSakorn();
             GenEmployeeID();

            //Province
            this.InitialProvince();

            //Title
            this.InitialTitle();

            //Possition
            this.InitialPosition();

            //Status
            this.initialEmpStatus();

            //birth place
            cbo_bp_ctr.Items.Clear();
            cbo_bp_ctr.Items.Add("ไทย");
            cbo_bp_ctr.SelectedIndex = 0;

            //Site Location
            this.ReloadSites();

            //amphur
            this.InitialAmphur();

            //District
            this.InitialDistrict();


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
            cbo_sex.SelectedIndex = 0;
        }

        private void InitialProvince()
        {
            var listprov = ProvinceServices.GetListProvince();

            var listprov2 = ProvinceServices.GetListProvince();

            var listprov3 = ProvinceServices.GetListProvince();

            ListProvinces = listprov;

            var prov1 = listprov.Select(x => new { x.PROVINCE_ID, x.PROVINCE_NAME }).ToList();

            var prov2 = listprov2.Select(x => new { x.PROVINCE_ID, x.PROVINCE_NAME }).ToList();

            var prov3 = listprov3.Select(x => new { x.PROVINCE_ID, x.PROVINCE_NAME }).ToList();

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
                var amp1 = listamp.Select(x => new { x.AMPHUR_ID, x.AMPHUR_NAME }).ToList();
                p_cbo_amp.DataSource = amp1;
                p_cbo_amp.DisplayMember = "AMPHUR_NAME";
                p_cbo_amp.ValueMember = "AMPHUR_ID";
                if (amp1.Count > 0)
                {
                    p_cbo_amp.SelectedIndex = 0;
                }
            }
            if (c_cbo_prov.SelectedItem != null)
            {
                var listamp = ProvinceServices.GetListAmphur(Convert.ToInt16(c_cbo_prov.SelectedValue.ToString()));
                var amp1 = listamp.Select(x => new { x.AMPHUR_ID, x.AMPHUR_NAME }).ToList();
                c_cbo_amp.DataSource = amp1;
                c_cbo_amp.DisplayMember = "AMPHUR_NAME";
                c_cbo_amp.ValueMember = "AMPHUR_ID";
                if (amp1.Count > 0)
                {
                    c_cbo_amp.SelectedIndex = 0;
                }
            }
        }

        private void InitialDistrict()
        {
            if (c_cbo_amp.SelectedItem != null)
            {
                var listDistrict = DistrictService.GetDistrictByAmphurID(Convert.ToInt16(c_cbo_prov.SelectedValue.ToString()), Convert.ToInt16(c_cbo_amp.SelectedValue.ToString()));
                var ds = listDistrict.Select(x => new { x.DISTRICT_ID, x.DISTRICT_NAME }).ToList();
                c_cbo_distict.DataSource = ds;
                c_cbo_distict.DisplayMember = "DISTRICT_NAME";
                c_cbo_distict.ValueMember = "DISTRICT_ID";
                if (ds.Count > 0)
                {
                    c_cbo_distict.SelectedIndex = 0;
                }
            }
            if (p_cbo_amp.SelectedItem != null)
            {
                var listDistrict = DistrictService.GetDistrictByAmphurID(Convert.ToInt16(p_cbo_prov.SelectedValue.ToString()), Convert.ToInt16(p_cbo_amp.SelectedValue.ToString()));
                var ds = listDistrict.Select(x => new { x.DISTRICT_ID, x.DISTRICT_NAME }).ToList();
                p_cbo_district.DataSource = ds;
                p_cbo_district.DisplayMember = "DISTRICT_NAME";
                p_cbo_district.ValueMember = "DISTRICT_ID";
                if (ds.Count > 0)
                {
                    p_cbo_district.SelectedIndex = 0;
                }
            }
        }

        private void InitialTitle()
        {

            var listtitle = CommonServices.GetTitleList("TH");
            var tt = listtitle.Select(x => new { x.ID, x.NAME }).ToList();
            cbo_title_th.DataSource = tt;
            cbo_title_th.DisplayMember = "NAME";
            cbo_title_th.ValueMember = "ID";

            var listen = CommonServices.GetTitleList("EN");
            var te = listen.Select(x => new { x.ID, x.NAME }).ToList();
            cbo_title_en.DataSource = te;
            cbo_title_en.DisplayMember = "NAME";
            cbo_title_en.ValueMember = "ID";
        }

        private void InitialSSOProvince()
        {
            var list = CommonServices.GetProvinceHospitalList();
            cbo_sso_prov.DataSource = list;
            cbo_sso_prov.SelectedIndex = 0;
        }

        private void InitialAddressType()
        {
            var addrType = DataService.AddressServices.GetAddressTypeList();
            c_add_type.Items.Clear();
            c_add_type.DataSource = addrType;
            c_add_type.DisplayMember = "NAME";
            c_add_type.ValueMember = "ID";

        }

        private void InitialPosition()
        {
            var lstpos = PossitionDataService.GetAll();
            cbo_possition.Items.Clear();
            cbo_possition.DataSource = lstpos;
            cbo_possition.DisplayMember = "NAME";
            cbo_possition.ValueMember = "ID";

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
                emp.EMP_ID = txt_empid.Text; //รหัสพนักงาน
                emp.ID_CARD = txt_pid.Text; // บัตรประชาชน
                emp.TITLE_ID = Convert.ToInt32(cbo_title_th.SelectedValue.ToString()); //คำนำหน้า
                emp.TITLE_ID_EN = Convert.ToInt32(cbo_title_en.SelectedValue.ToString()); //คำนำหน้า

                emp.FIRSTNAME_TH = txt_emp_fname_th.Text; //ชื่อไทย
                emp.LASTNAME_TH = txt_emp_lname_th.Text; //นามสกุลไทย
                emp.FIRSTNAME_EN = txt_emp_fname_en.Text; //ชื่ออังกฤษ
                emp.LASTNAME_EN = txt_emp_lname_en.Text; //นามสกุลอังกฤษ
                //emp.NICKNAME_TH = txt_nick_th.Text; //ชื่อเล่น

                emp.POSITION_ID = Convert.ToInt16(cbo_possition.SelectedValue.ToString()); //ตำแหน่ง
                DateTime _dob = DateTime.MinValue;
                if (DateTime.TryParse(dob.Text, out _dob))
                {
                    emp.DATEOFBIRTH = Convert.ToDateTime(dob.Text);//ว ด ป เกิด
                }
                DateTime _dsw = DateTime.MinValue;
                if (DateTime.TryParse(date_start_work.Text, out _dsw))
                {
                    emp.DATESTARTWORK = Convert.ToDateTime(date_start_work.Text);//ว ด ป เริ่มงาน
                }


                emp.BIRTH_PLACE_PROVINCE = cbo_bp_prov.SelectedValue.ToString(); //จังหวัดที่เกิด
                emp.BIRTH_PLACE_CONTRY = cbo_bp_ctr.SelectedItem.ToString(); //ปรเเทศ เกิด 
                emp.GENDER_ID = Convert.ToInt32(cbo_sex.SelectedIndex + 1); //เพศ
                emp.HEIGHT = Convert.ToInt32(txt_height.Text); //สูง
                emp.WEIGHT = Convert.ToInt32(txt_weight.Text); //น้ำหนัก
                emp.RACE = cbo_race.SelectedItem.ToString(); //เชื้อชาติ
                emp.NATIONALITY = cbo_nationality.SelectedItem.ToString();//สัญชาติ
                emp.RELEGION = cbo_relegion.SelectedItem.ToString(); //ศาสนา
                emp.CREATED_DATE = DateTime.Now;
                emp.BLOODGROUP = txt_blood.Text;
                emp.APPEARANCE = txt_apperance.Text;
                emp.DEFECT = txt_defect.Text;
                emp.AREA = txt_area.Text;
                emp.MOBILE = txt_mobile.Text;
                emp.HOMEPHONE = txt_mobile.Text;
                emp.CREATED_DATE = DateTime.Now;
                emp.REGIS_NO = txt_regis_no.Text;
                if (cbo_site.SelectedItem != null)
                {
                    emp.SITE_LOCATION = cbo_site.SelectedItem.ToString();
                }
                if (cbo_status.SelectedItem != null)
                {
                    emp.STATUS = cbo_status.SelectedItem.ToString();
                }
                if (cbo_substatus.SelectedItem != null)
                {
                    emp.SUBSTATUS = cbo_substatus.SelectedItem.ToString();
                }
                if (txt_reason.Text != "")
                {
                    emp.STATUS_REASON = txt_reason.Text;
                }

                //emp.MARITAL_ID = 1; //สถานะสมรส 

                return emp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private FingerScan getFingerFromInput()
        {
            var ret = new FingerScan();
            ret.EMP_ID = txt_empid.Text;
            ret.LEFTFINGER1 = ConvertImageToByteArray(l_finger_1.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            ret.LEFTFINGER2 = ConvertImageToByteArray(l_finger_2.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            ret.LEFTFINGER3 = ConvertImageToByteArray(l_finger_3.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            ret.LEFTFINGER4 = ConvertImageToByteArray(l_finger_4.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            ret.LEFTFINGER5 = ConvertImageToByteArray(l_finger_5.Image, System.Drawing.Imaging.ImageFormat.Jpeg);

            ret.RIGHTFINGER1 = ConvertImageToByteArray(R_finger_1.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            ret.RIGHTFINGER2 = ConvertImageToByteArray(R_finger_2.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            ret.RIGHTFINGER3 = ConvertImageToByteArray(R_finger_3.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            ret.RIGHTFINGER4 = ConvertImageToByteArray(R_finger_4.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            ret.RIGHTFINGER5 = ConvertImageToByteArray(R_finger_5.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ret;
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

        public void initialEmpStatus()
        {
            cbo_status.Items.Clear();
            var list = MasterConfigServices.GetEmployeeStatus().OrderBy(x => x.ID).ToList();
            foreach (var item in list)
            {
                cbo_status.Items.Add(item.VALUE);
            }
            if (cbo_status.Items.Count > 0)
            {
                cbo_status.SelectedIndex = 0;
            }
        }

        public void initialSubEmpStatus()
        {
            cbo_substatus.Items.Clear();
            var list = MasterConfigServices.GetSubEmployeeStatus().OrderBy(x => x.ID).ToList();
            foreach (var item in list)
            {
                cbo_substatus.Items.Add(item.VALUE);
            }
            if (cbo_substatus.Items.Count > 0)
            {
                cbo_substatus.SelectedIndex = 0;
            }
        }

        private void ClearControl()
        {

        }

        private bool ValidateData()
        {
            if (txt_empid.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูล ==> รหัสพนักงาน <==");
                EmployeeTab.SelectedTab = General_Tab;
                txt_empid.Focus();
                return false;
            }
            if (txt_pid.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูล ==> หมายเลขบัตรประชาชน <== ");
                EmployeeTab.SelectedTab = General_Tab;
                txt_pid.Focus();
                return false;
            }
            if (txt_emp_fname_th.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูล ==> ชื่อ ภาษาไทย <== ");
                EmployeeTab.SelectedTab = General_Tab;
                txt_emp_fname_th.Focus();
                return false;
            }
            if (txt_emp_lname_th.Text == "")
            {
                MessageBox.Show("กรุณากรอกข้อมูล ==> นามสกุลภาษาไทย <== ");
                EmployeeTab.SelectedTab = General_Tab;
                txt_emp_lname_th.Focus();
                return false;
            }


            return true;
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
            catch (Exception ex) { throw ex; }
            return Ret;
        }

        private List<BIG.Model.Address> getAddressListfrominput()
        {

            var listAddress = new List<BIG.Model.Address>();
            try
            {
                if (c_txt_no.Text != "" && txt_empid.Text != "")
                {
                    //Current Address
                    var current_addr = new BIG.Model.Address();

                    current_addr.EMP_ID = txt_empid.Text;
                    current_addr.NAME = c_txt_no.Text + " " + c_txt_soi.Text + " " + c_txt_rd.Text;
                    current_addr.DISTRICT = c_txt_tumbol.Text;
                    current_addr.AMPHUR_ID = c_cbo_amp.SelectedValue.ToString();
                    current_addr.PROVINCE_ID = c_cbo_prov.SelectedValue.ToString();
                    current_addr.POSTCODE = c_txt_postcode.Text;
                    current_addr.ADDRESSTYPE_ID = Convert.ToInt16(c_add_type.SelectedValue.ToString());
                    current_addr.DESCRIPTION = "ที่อยู่ปัจจุบัน";
                    current_addr.ZIPCODE = c_txt_postcode.Text;
                    current_addr.CREATED_DATE = DateTime.Now;
                    listAddress.Add(current_addr);
                }


                if (p_txt_no.Text != "" && txt_empid.Text != "")
                {
                    //Permanent Address
                    var permanent_addr = new BIG.Model.Address();

                    permanent_addr.EMP_ID = txt_empid.Text;
                    permanent_addr.NAME = p_txt_no.Text + " " + p_txt_soi.Text + " " + p_txt_road.Text;
                    permanent_addr.DISTRICT = p_txt_tumbol.Text;
                    permanent_addr.AMPHUR_ID = p_cbo_amp.SelectedValue.ToString();
                    permanent_addr.PROVINCE_ID = p_cbo_prov.SelectedValue.ToString();
                    permanent_addr.POSTCODE = p_txt_postcode.Text;
                    permanent_addr.DESCRIPTION = "ที่อยู่ตามทะเบียนบ้าน";
                    permanent_addr.ZIPCODE = p_txt_postcode.Text;
                    permanent_addr.CREATED_DATE = DateTime.Now;
                    listAddress.Add(permanent_addr);

                }
                return listAddress;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<BIG.Model.Education> getEducationListfrominput()
        {
            var lstEdu = new List<BIG.Model.Education>();
            try
            {
                if (txt_edu_nm_1.Text != "" && txt_empid.Text != "")
                {
                    //University
                    var edu = new BIG.Model.Education();
                    edu.EDU_TYPE = "อุดมศึกษา/มหาวิทยาลัย";
                    edu.EMP_ID = txt_empid.Text;
                    edu.NAME = txt_edu_nm_1.Text;
                    edu.GRADUETED = txt_graduated_1.Text;
                    edu.YEAR = txt_edu_yr_1.Text;
                    edu.CREATED_DATE = DateTime.Now;
                    lstEdu.Add(edu);
                }
                if (txt_edu_nm_2.Text != "" && txt_empid.Text != "")
                {
                    var edu = new BIG.Model.Education();
                    edu.EDU_TYPE = "มัธยมศึกษา/ประกาศนียบัตรวิชาชีพ";
                    edu.EMP_ID = txt_empid.Text;
                    edu.NAME = txt_edu_nm_2.Text;
                    edu.GRADUETED = txt_graduated_2.Text;
                    edu.YEAR = txt_edu_yr_2.Text;
                    edu.CREATED_DATE = DateTime.Now;
                    lstEdu.Add(edu);
                }
                if (txt_edu_nm_3.Text != "" && txt_empid.Text != "")
                {
                    var edu = new BIG.Model.Education();
                    edu.EDU_TYPE = "ประถมศึกษา";
                    edu.EMP_ID = txt_empid.Text;
                    edu.NAME = txt_edu_nm_3.Text;
                    edu.GRADUETED = txt_graduated_3.Text;
                    edu.YEAR = txt_edu_yr_3.Text;
                    edu.CREATED_DATE = DateTime.Now;
                    lstEdu.Add(edu);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstEdu;
        }

        private List<BIG.Model.Training> getTrainingListfrominput()
        {
            var lstTrain = new List<BIG.Model.Training>();
            try
            {
                if (txt_tn_1.Text != "" && txt_empid.Text != "")
                {
                    var tn = new BIG.Model.Training();
                    tn.TYPE = "1";
                    tn.EMP_ID = txt_empid.Text;
                    tn.COURSE = txt_tn_1.Text;
                    tn.DETAILS = txt_tn_dt_1.Text;
                    tn.YEAR = txt_tn_yr_1.Text;
                    tn.CREATED_DATE = DateTime.Now;
                    lstTrain.Add(tn);
                }
                if (txt_tn_2.Text != "" && txt_empid.Text != "")
                {
                    var tn = new BIG.Model.Training();
                    tn.TYPE = "2";
                    tn.EMP_ID = txt_empid.Text;
                    tn.COURSE = txt_tn_2.Text;
                    tn.DETAILS = txt_tn_dt_2.Text;
                    tn.YEAR = txt_tn_yr_2.Text;
                    tn.CREATED_DATE = DateTime.Now;
                    lstTrain.Add(tn);
                }
                if (txt_tn_3.Text != "" && txt_empid.Text != "")
                {
                    var tn = new BIG.Model.Training();
                    tn.TYPE = "3";
                    tn.EMP_ID = txt_empid.Text;
                    tn.COURSE = txt_tn_3.Text;
                    tn.DETAILS = txt_tn_dt_3.Text;
                    tn.YEAR = txt_tn_yr_3.Text;
                    tn.CREATED_DATE = DateTime.Now;
                    lstTrain.Add(tn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstTrain;
        }

        private List<BIG.Model.WorkExperience> getExperienceListfrominput()
        {
            var explist = new List<BIG.Model.WorkExperience>();
            try
            {
                if (txt_exp_comname_1.Text != "" && txt_empid.Text != "")
                {
                    var exp = new BIG.Model.WorkExperience();
                    exp.TYPE = "1";
                    exp.EMP_ID = txt_empid.Text;
                    exp.NAME = txt_exp_comname_1.Text;
                    exp.POSITION = txt_exp_pos1.Text;
                    exp.SALARY = txt_exp_salary_1.Text;
                    exp.PERIOD = txt_exp_period_1.Text;
                    //exp.CREATED_DATE = DateTime.Now;
                    explist.Add(exp);
                }
                if (txt_exp_comname_1.Text != "" && txt_empid.Text != "")
                {
                    var exp = new BIG.Model.WorkExperience();
                    exp.TYPE = "2";
                    exp.EMP_ID = txt_empid.Text;
                    exp.NAME = txt_exp_comname_2.Text;
                    exp.POSITION = txt_we_pos2.Text;
                    exp.SALARY = txt_exp_salary_2.Text;
                    exp.PERIOD = txt_exp_period_2.Text;
                    //exp.CREATED_DATE = DateTime.Now;
                    explist.Add(exp);
                }
                if (txt_exp_comname_1.Text != "" && txt_empid.Text != "")
                {
                    var exp = new BIG.Model.WorkExperience();
                    exp.TYPE = "3";
                    exp.EMP_ID = txt_empid.Text;
                    exp.NAME = txt_exp_comname_3.Text;
                    exp.POSITION = txt_we_pos3.Text;
                    exp.SALARY = txt_exp_salary_3.Text;
                    exp.PERIOD = txt_exp_period_3.Text;
                    //exp.CREATED_DATE = DateTime.Now;
                    explist.Add(exp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return explist;
        }

        private List<BIG.Model.ReferencePerson> getRefPersonListfrominput()
        {
            var explist = new List<BIG.Model.ReferencePerson>();
            try
            {
                if (txt_ref_name_1.Text != "" && txt_empid.Text != "")
                {
                    var refp = new BIG.Model.ReferencePerson();
                    refp.TYPE = "1";
                    refp.EMP_ID = txt_empid.Text;
                    refp.NAME = txt_ref_name_1.Text;
                    refp.TELEPHONE = txt_ref_contact_1.Text;
                    refp.ADDRESS = txt_ref_add_1.Text;
                    refp.RELATIONSHIFT = txt_ref_relation_1.Text;
                    //refp.CREATED_DATE = DateTime.Now;
                    explist.Add(refp);
                }
                if (txt_ref_name_2.Text != "" && txt_empid.Text != "")
                {
                    var refp = new BIG.Model.ReferencePerson();
                    refp.TYPE = "2";
                    refp.EMP_ID = txt_empid.Text;
                    refp.NAME = txt_ref_name_2.Text;
                    refp.TELEPHONE = txt_ref_contact_2.Text;
                    refp.ADDRESS = txt_ref_add_2.Text;
                    refp.RELATIONSHIFT = txt_ref_relation_2.Text;
                    //refp.CREATED_DATE = DateTime.Now;
                    explist.Add(refp);
                }
                if (txt_ref_name_3.Text != "" && txt_empid.Text != "")
                {
                    var refp = new BIG.Model.ReferencePerson();
                    refp.TYPE = "3";
                    refp.EMP_ID = txt_empid.Text;
                    refp.NAME = txt_ref_name_3.Text;
                    refp.TELEPHONE = txt_ref_contact_3.Text;
                    refp.ADDRESS = txt_ref_add_3.Text;
                    refp.RELATIONSHIFT = txt_ref_relation_3.Text;
                    //refp.CREATED_DATE = DateTime.Now;
                    explist.Add(refp);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return explist;
        }

        private List<BIG.Model.SSO> getSSOListfrominput()
        {
            var ssoList = new List<BIG.Model.SSO>();
            try
            {
                if (txt_empid.Text != "" && (chk_have_sso.Checked == true || chk_nothave_sso.Checked == true))
                {
                    var sso = new SSO();
                    sso.EMP_ID = txt_empid.Text;
                    if (chk_manual_hospital.Checked)
                    {
                        sso.NOTINDATABASE = true;
                        sso.HOSPITAL_NAME = txt_sso_manual_hospital.Text;

                    }
                    else
                    {
                        if (cbo_sso_hospital.SelectedValue != null && cbo_sso_prov.SelectedValue != null)
                        {
                            sso.HOSPITAL_NAME = cbo_sso_hospital.SelectedValue.ToString();
                            sso.PROVINCE_NAME = cbo_sso_prov.SelectedValue.ToString();
                            sso.NOTINDATABASE = false;
                        }
                        else
                        {
                            sso.HOSPITAL_NAME = cbo_sso_hospital.SelectedText;
                            sso.NOTINDATABASE = false;
                        }
                    }
                    sso.CREATED_DATE = DateTime.Now;

                    ssoList.Add(sso);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ssoList;
        }

        private List<BIG.Model.Equiptment> getEquiptListfrominput()
        {
            var equipt = new List<BIG.Model.Equiptment>();
            try
            {
                var eq = new BIG.Model.Equiptment();
                if (txt_eq_1.Text != "")
                {
                    eq.EMP_ID = txt_empid.Text;
                    eq.EQUIP_NAME = "ประกัน";
                    eq.EQUIP_AMOUNT = txt_eq_1.Text;
                    eq.CREATED_DATE = DateTime.Now;
                    equipt.Add(eq);
                }

                if (txt_eq_2.Text != "")
                {
                    eq = new BIG.Model.Equiptment();
                    eq.EMP_ID = txt_empid.Text;
                    eq.EQUIP_NAME = "ค่าชุด";
                    eq.EQUIP_AMOUNT = txt_eq_2.Text;
                    eq.CREATED_DATE = DateTime.Now;
                    equipt.Add(eq);
                }
                if (txt_eq_3.Text != "")
                {
                    eq = new BIG.Model.Equiptment();
                    eq.EMP_ID = txt_empid.Text;
                    eq.EQUIP_NAME = "สายนกหวีด";
                    eq.EQUIP_AMOUNT = txt_eq_3.Text;
                    eq.CREATED_DATE = DateTime.Now;
                    equipt.Add(eq);
                }
                if (txt_eq_4.Text != "")
                {
                    eq = new BIG.Model.Equiptment();
                    eq.EMP_ID = txt_empid.Text;
                    eq.EQUIP_NAME = "เข็มขัด";
                    eq.EQUIP_AMOUNT = txt_eq_4.Text;
                    eq.CREATED_DATE = DateTime.Now;
                    equipt.Add(eq);
                }
                if (txt_eq_5.Text != "")
                {
                    eq = new BIG.Model.Equiptment();
                    eq.EMP_ID = txt_empid.Text;
                    eq.EQUIP_NAME = "ดิ้ว";
                    eq.EQUIP_AMOUNT = txt_eq_5.Text;
                    eq.CREATED_DATE = DateTime.Now;
                    equipt.Add(eq);
                }
                if (txt_eq_6.Text != "")
                {
                    eq = new BIG.Model.Equiptment();
                    eq.EMP_ID = txt_empid.Text;
                    eq.EQUIP_NAME = "หมวก";
                    eq.EQUIP_AMOUNT = txt_eq_6.Text;
                    eq.CREATED_DATE = DateTime.Now;
                    equipt.Add(eq);
                }
                if (txt_eq_7.Text != "")
                {
                    eq = new BIG.Model.Equiptment();
                    eq.EMP_ID = txt_empid.Text;
                    eq.EQUIP_NAME = "รองเท้า";
                    eq.EQUIP_AMOUNT = txt_eq_7.Text;
                    eq.CREATED_DATE = DateTime.Now;
                    equipt.Add(eq);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return equipt;
        }

        private List<BIG.Model.Deduction> getDeductionListfrominput()
        {
            var deducList = new List<BIG.Model.Deduction>();
            try
            {
                if (lbd1.Text.Contains("บาท"))
                {
                    var deduc = new BIG.Model.Deduction();
                    deduc.NO = 1;
                    deduc.EMP_ID = txt_empid.Text;
                    deduc.CREATED_DATE = DateTime.Now;
                    deduc.MODIFIED_DATE = DateTime.Now;
                    DateTime date = DateTime.MinValue;
                    if (DateTime.TryParse(dt_deduct1.Value.ToShortDateString(), out date))
                    {

                        deduc.DATE = date;
                        deducList.Add(deduc);
                    }
                }
                if (lbd2.Text.Contains("บาท"))
                {
                    var deduc = new BIG.Model.Deduction();
                    deduc.NO = 2;
                    deduc.EMP_ID = txt_empid.Text;
                    deduc.CREATED_DATE = DateTime.Now;
                    deduc.MODIFIED_DATE = DateTime.Now;
                    DateTime date = DateTime.MinValue;
                    if (DateTime.TryParse(dt_deduct2.Value.ToShortDateString(), out date))
                    {
                        deduc.DATE = date;
                        deducList.Add(deduc);
                    }
                }
                if (lbd3.Text.Contains("บาท"))
                {
                    var deduc = new BIG.Model.Deduction();
                    deduc.NO = 3;
                    deduc.EMP_ID = txt_empid.Text;
                    deduc.CREATED_DATE = DateTime.Now;
                    deduc.MODIFIED_DATE = DateTime.Now;
                    DateTime date = DateTime.MinValue;
                    if (DateTime.TryParse(dt_deduct3.Value.ToShortDateString(), out date))
                    {
                        deduc.DATE = date;
                        deducList.Add(deduc);
                    }
                }
                if (lbd4.Text.Contains("บาท"))
                {
                    var deduc = new BIG.Model.Deduction();
                    deduc.NO = 4;
                    deduc.EMP_ID = txt_empid.Text;
                    deduc.CREATED_DATE = DateTime.Now;
                    deduc.MODIFIED_DATE = DateTime.Now;
                    DateTime date = DateTime.MinValue;
                    if (DateTime.TryParse(dt_deduct4.Value.ToShortDateString(), out date))
                    {
                        deduc.DATE = date;
                        deducList.Add(deduc);
                    }
                }
                if (lbd5.Text.Contains("บาท"))
                {
                    var deduc = new BIG.Model.Deduction();
                    deduc.NO = 5;
                    deduc.EMP_ID = txt_empid.Text;
                    deduc.CREATED_DATE = DateTime.Now;
                    deduc.MODIFIED_DATE = DateTime.Now;
                    DateTime date = DateTime.MinValue;
                    if (DateTime.TryParse(dt_deduct5.Value.ToShortDateString(), out date))
                    {
                        deduc.DATE = date;
                        deducList.Add(deduc);
                    }
                }
                if (lbd6.Text.Contains("บาท"))
                {
                    var deduc = new BIG.Model.Deduction();
                    deduc.NO = 6;
                    deduc.EMP_ID = txt_empid.Text;
                    deduc.CREATED_DATE = DateTime.Now;
                    deduc.MODIFIED_DATE = DateTime.Now;
                    DateTime date = DateTime.MinValue;
                    if (DateTime.TryParse(dt_deduct6.Value.ToShortDateString(), out date))
                    {
                        deduc.DATE = date;
                        deducList.Add(deduc);
                    }
                }
                if (lbd7.Text.Contains("บาท"))
                {
                    var deduc = new BIG.Model.Deduction();
                    deduc.NO = 7;
                    deduc.EMP_ID = txt_empid.Text;
                    deduc.CREATED_DATE = DateTime.Now;
                    deduc.MODIFIED_DATE = DateTime.Now;
                    DateTime date = DateTime.MinValue;
                    if (DateTime.TryParse(dt_deduct7.Value.ToShortDateString(), out date))
                    {
                        deduc.DATE = date;
                        deducList.Add(deduc);
                    }
                }
                if (lbd8.Text.Contains("บาท"))
                {
                    var deduc = new BIG.Model.Deduction();
                    deduc.NO = 8;
                    deduc.EMP_ID = txt_empid.Text;
                    deduc.CREATED_DATE = DateTime.Now;
                    deduc.MODIFIED_DATE = DateTime.Now;
                    DateTime date = DateTime.MinValue;
                    if (DateTime.TryParse(dt_deduct8.Value.ToShortDateString(), out date))
                    {
                        deduc.DATE = date;
                        deducList.Add(deduc);
                    }
                }

                var tot = 0;
                if (int.TryParse(txt_total.Text, out tot))
                {
                    var listdeduc = tot / 500;
                    for (int i = 0; i < listdeduc; i++)
                    {
                        if (i == 0)
                        {
                            var obj = deducList.Where(o => o.NO == 1).FirstOrDefault();
                            obj.PRICE = 500;
                        }
                        if (i == 1)
                        {
                            var obj = deducList.Where(o => o.NO == 2).FirstOrDefault();
                            obj.PRICE = 500;
                        }
                        if (i == 2)
                        {
                            var obj = deducList.Where(o => o.NO == 3).FirstOrDefault();
                            obj.PRICE = 500;
                        }
                        if (i == 3)
                        {
                            var obj = deducList.Where(o => o.NO == 4).FirstOrDefault();
                            obj.PRICE = 500;
                        }
                        if (i == 4)
                        {
                            var obj = deducList.Where(o => o.NO == 5).FirstOrDefault();
                            obj.PRICE = 500;
                        }
                        if (i == 5)
                        {
                            var obj = deducList.Where(o => o.NO == 6).FirstOrDefault();
                            obj.PRICE = 500;
                        }
                        if (i == 6)
                        {
                            var obj = deducList.Where(o => o.NO == 7).FirstOrDefault();
                            obj.PRICE = 500;
                        }
                        if (i == 7)
                        {
                            var obj = deducList.Where(o => o.NO == 8).FirstOrDefault();
                            obj.PRICE = 500;
                        }
                    }
                    var x = tot % 500;
                    listdeduc = listdeduc + 1;

                    var lastDeduc = deducList.Where(o => o.NO == listdeduc).FirstOrDefault();
                    lastDeduc.PRICE = x;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deducList;
        }

        private EmployeeImage getPhotoEmployee()
        {
            var ret = new EmployeeImage();

            try
            {
                var myBitmap = pic_emp.Image;
                ret.EMP_ID = txt_empid.Text;
                ret.PHOTO = ConvertImageToByteArray(myBitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
                ret.TYPE = System.Drawing.Imaging.ImageFormat.Jpeg.ToString();
                ret.CREATE_DATE = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        private CurrentImage getCurrentPhotoEmployee()
        {
            var ret = new CurrentImage();
            try
            {
                if (currentImgName != "")
                {
                    var myBitmap = pic_current.Image;
                    ret.EMP_ID = txt_empid.Text;
                    ret.PHOTO = ConvertImageToByteArray(myBitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ret.TYPE = System.Drawing.Imaging.ImageFormat.Jpeg.ToString();
                    ret.CREATE_DATE = DateTime.Now;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ret;
        }

        private void getRefDocFormInput()
        {
            var obj = RefDoc.Where(x => x.TYPE == "สำเนาบัตรประชาชน").FirstOrDefault();
            if (obj == null)
            {
                var refdoc = new ReferenceDocument();
                refdoc.EMP_ID = txt_empid.Text;
                refdoc.PHOTO = ConvertImageToByteArray(pic_copy_idcard.Image, System.Drawing.Imaging.ImageFormat.Jpeg);
                refdoc.TYPE = "สำเนาบัตรประชาชน";
                refdoc.CREATE_DATE = DateTime.Now;
                RefDoc.Add(refdoc);
            }
        }

        private string GetPostCode(string province, string amphur, string tambol)
        {
            var result = "";
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        private bool CheckAlreadyEmployee(string idcard)
        {
            var result = false;
            try
            {
                var obj = EmployeeServices.GetEmployeeByIDCard(idcard);
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
            EmployeeServices.Add(emp);
        }

        private void UploadFingerScan(BIG.Model.FingerScan fin)
        {
            FingerScanServices.Add(fin);
        }

        private void UpdateEmployee(BIG.Model.Employee emp)
        {
            EmployeeServices.UpdateEmployee(emp);
        }

        private void CreateAddress(List<BIG.Model.Address> listAddress)
        {
            AddressServices.Add(listAddress);
        }

        private void CreateEducation(List<BIG.Model.Education> lstEdu)
        {
            EducationServices.Add(lstEdu);
        }

        private void CreateTraining(List<BIG.Model.Training> lstTrain)
        {
            TrainingServices.Add(lstTrain);
        }

        private void CreateWorkExp(List<BIG.Model.WorkExperience> lstExp)
        {
            WorkExperienceServices.Add(lstExp);
        }

        private void CreateRefPerson(List<BIG.Model.ReferencePerson> lstRef)
        {
            ReferencePersonServices.Add(lstRef);
        }

        private void CreateSSO(List<BIG.Model.SSO> lstSSO)
        {
            SSOServices.Add(lstSSO);
        }

        private void CreateReferenceDoc(List<BIG.Model.ReferenceDocument> list)
        {
            RefDocumentServices.Add(list);
        }

        private void CreateOtherDoc(List<BIG.Model.OtherDocument> list)
        {
            OtherDocumentServices.Add(list);
        }

        private void CreateEquipment(List<BIG.Model.Equiptment> lstEQ)
        {
            EquiptmentServices.Add(lstEQ);
        }

        private void CreateDeduction(List<BIG.Model.Deduction> lstDe)
        {
            DeductionService.Add(lstDe);
        }

        private string GenNewEmployeeID()
        {
            var ret = "";
            try
            {
                var lastemp_id = EmployeeServices.GetLastEmployeeID();
                if (lastemp_id == "")
                {
                    lastemp_id = "60A000";
                }
                var running = lastemp_id.Substring(lastemp_id.Length - 3, 3);
                var nextnumber = Convert.ToDecimal(running) + 1;
                lastemp_id = DateTime.Now.ToString("yyMMdd") + String.Format("{0:000}", nextnumber); ;
                ret = "BIGS" + lastemp_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }
        
        private void GenEmployeeID()
        {
            try
            {
                var nextemp_id = "";
                //var lastemp_id = EmployeeServices.GetLastEmployeeID(); 
                var lastemp_id = EmployeeServices.GetLastEmployeeID(); 
                 
                if (lastemp_id == "")
                {
                    lastemp_id = "BIGS590101000";
                }
                var running = lastemp_id.Substring(lastemp_id.Length - 3, 3);
                var lastnumber = Convert.ToDecimal(running);
                var nextnumber = Convert.ToDecimal(running) + 1;
                lastemp_id = DateTime.Now.ToString("yyMMdd") + String.Format("{0:000}", lastnumber);
                nextemp_id = DateTime.Now.ToString("yyMMdd") + String.Format("{0:000}", nextnumber);
                var lastemp = "BIGS" + lastemp_id;
                var nextemp = "BIGS" + nextemp_id;
                lb_isnewemp.Text = "*รหัสพนักงานล่าสุด (" + lastemp + ")";
                txt_empid.Text = nextemp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GenNewEmployeeIDSamutSakorn()
        {
            var ret = "";
            try
            {
                var lastemp_id = EmployeeServices.GetLastEmployeeIDSmutSakorn();
                if (lastemp_id == "")
                { 
                    lastemp_id = "60A000";
                }
                var running = lastemp_id.Substring(lastemp_id.Length - 3, 3);
                var nextnumber = Convert.ToDecimal(running) + 1;
                lastemp_id = DateTime.Now.ToString("yy") + EmployeeServices.getMonth() + String.Format("{0:000}", nextnumber); ;
                ret = lastemp_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        private void GenEmployeeIDSamutSakorn()
        {
            try
            {
                var nextemp_id = ""; 
                var lastemp_id = EmployeeServices.GetLastEmployeeIDSmutSakorn();

                if (lastemp_id == "")
                { 
                    lastemp_id = "60A000";
                }
                var running = lastemp_id.Substring(lastemp_id.Length - 3, 3);
                var lastnumber = Convert.ToDecimal(running);
                var nextnumber = Convert.ToDecimal(running) + 1;
                lastemp_id = DateTime.Now.ToString("yy") + EmployeeServices.getMonth() + String.Format("{0:000}", lastnumber);
                nextemp_id = DateTime.Now.ToString("yy") + EmployeeServices.getMonth() + String.Format("{0:000}", nextnumber);

                lb_isnewemp.Text = "*รหัสพนักงานล่าสุด (" + lastemp_id + ")";
                txt_empid.Text = nextemp_id;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int GetProvinceIDByName(string province_nm)
        {
            var ret = 0;
            try
            {
                province_nm = province_nm.Replace("จังหวัด", "");
                var obj = ListProvinces.Where(x => x.PROVINCE_NAME == province_nm).FirstOrDefault();
                if (obj != null)
                {
                    ret = obj.PROVINCE_ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        private string GetProvinceNameByID(int province_ID)
        {
            var ret = string.Empty;
            try
            {
                var obj = ListProvinces.Where(x => x.PROVINCE_ID == province_ID).FirstOrDefault();
                if (obj != null)
                {
                    ret = obj.PROVINCE_NAME;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        private int GetAmphureIDByName(string amp_nm)
        {
            var ret = 0;
            try
            {
                amp_nm = amp_nm.Replace("อำเภอ", "");
                var listamp = ProvinceServices.GetListAmphur(Convert.ToInt16(p_cbo_prov.SelectedValue.ToString()));
                var obj = listamp.Where(x => x.AMPHUR_NAME == amp_nm).FirstOrDefault();
                if (obj != null)
                {
                    ret = obj.AMPHUR_ID;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        private string GetPermanentAmphureNameByID(int amp_id)
        {
            var ret = string.Empty;
            try
            {
                var listamp = ProvinceServices.GetListAmphur(Convert.ToInt16(p_cbo_prov.SelectedValue.ToString()));
                var obj = listamp.Where(x => x.AMPHUR_ID == amp_id).FirstOrDefault();
                if (obj != null)
                {
                    ret = obj.AMPHUR_NAME;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        private string GetCurrentAmphureNameByID(int amp_id)
        {
            var ret = string.Empty;
            try
            {
                var listamp = ProvinceServices.GetListAmphur(Convert.ToInt16(c_cbo_prov.SelectedValue.ToString()));
                var obj = listamp.Where(x => x.AMPHUR_ID == amp_id).FirstOrDefault();
                if (obj != null)
                {
                    ret = obj.AMPHUR_NAME;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }

        public void SearchPID(string id_card)
        {
            this.UseWaitCursor = true;

            try
            {
                var empObj = EmployeeServices.GetEmployeeByIDCard(id_card);

                //มีข้อมูลพนักงานอยู่ในระบบ
                if (empObj != null)
                {
                    MessageBox.Show("      พบข้อมูลอยู่ในระบบ" + "\r\n\n" + "     รหัสบัตรประชาชน => " + empObj.ID_CARD + "\n\n" + "     ชื่อ-สกุล" + empObj.FIRSTNAME_TH + " " + empObj.LASTNAME_TH);

                    SetObjectToControl(empObj);
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

        public void SearchEmpID(string empid)
        {
            this.UseWaitCursor = true;

            try
            {
                var empObj = EmployeeServices.GetEmployeeByEmpID(empid);

                //มีข้อมูลพนักงานอยู่ในระบบ
                if (empObj != null)
                {
                    SetObjectToControl(empObj);
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

        public void LoadPID()
        {
            this.UseWaitCursor = true;

            try
            {
                //initialCombobox();
                var idcard = CardID.readAllPhoto(); //.readAll(true);
                if (idcard != null)
                {
                    var empObj = EmployeeServices.GetEmployeeByIDCard(idcard.Citizenid);

                    //มีข้อมูลพนักงานอยู่ในระบบ
                    if (empObj != null)
                    {
                        MessageBox.Show("      พบข้อมูลอยู่ในระบบ" + "\r\n\n" + "     รหัสบัตรประชาชน => " + idcard.Citizenid + "\n\n" + "     ชื่อ-สกุล" + empObj.FIRSTNAME_TH + " " + empObj.LASTNAME_TH);
                        
                        SetObjectToControl(empObj);
                        if (idcard.PhotoRaw != null)
                        {
                            //add to picture box 
                            pic_emp.Image = GetImage(idcard.PhotoRaw, 150, 187);
                        }
                        else
                        {
                            if (idcard.PhotoBitmap != null)
                            {
                                var myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                                var photo = idcard.PhotoBitmap.GetThumbnailImage(150, 187, myCallback, IntPtr.Zero);
                                pic_emp.Image = photo;
                            }
                        }
                        txt_pid.Text = idcard.Citizenid;
                        cbo_title_th.SelectedItem = idcard.Th_Prefix;
                        cbo_title_en.SelectedItem = idcard.En_Prefix;
                        txt_emp_fname_th.Text = idcard.Th_Firstname;
                        txt_emp_lname_th.Text = idcard.Th_Lastname;
                        txt_emp_fname_en.Text = idcard.En_Firstname;
                        txt_emp_lname_en.Text = idcard.En_Lastname;
                        dob.Value = idcard.Birthday;
                        int bp_prv_index = cbo_bp_prov.FindString(idcard.addrProvince.Replace("จังหวัด", ""));
                        cbo_bp_prov.SelectedIndex = bp_prv_index;
                        //permanent address
                        p_txt_no.Text = idcard.addrHouseNo + " " + idcard.addrVillageNo + " " + idcard.addrLane + " " + idcard.addrRoad;
                        p_txt_road.Text = idcard.addrRoad;
                        p_txt_soi.Text = "";
                        p_txt_tumbol.Text = idcard.addrTambol;

                        int p_prv_idx = p_cbo_prov.FindString(idcard.addrProvince.Replace("จังหวัด", ""));
                        p_cbo_prov.SelectedIndex = p_prv_idx; // GetProvinceIDByName(idcard.addrProvince);

                        int p_amp_idx = p_cbo_amp.FindString(idcard.addrAmphur.Replace("อำเภอ", ""));
                        p_cbo_amp.SelectedIndex = p_amp_idx;// GetAmphureIDByName(idcard.addrAmphur);
                    }
                    else
                    {
                        MessageBox.Show("     ไม่พบข้อมูลพนักงาน" + "\n\n" + "     รหัสบัตรประชาชน => " + idcard.Citizenid + "\n\n" + "     ชื่อ-สกุล =>" + idcard.Th_Firstname + " " + idcard.Th_Lastname);
                        //ไม่มีข้อมูลพนักงานอยู่ในระบบ
                        lb_isnewemp.Text = "*พนักงานใหม่";
                        txt_empid.Text = GenNewEmployeeID();
                        //txt_empid.Text = GenNewEmployeeIDSamutSakorn();
                        txt_pid.Text = idcard.Citizenid;
                        cbo_title_th.SelectedItem = idcard.Th_Prefix;
                        cbo_title_en.SelectedItem = idcard.En_Prefix;
                        txt_emp_fname_th.Text = idcard.Th_Firstname;
                        txt_emp_lname_th.Text = idcard.Th_Lastname;
                        txt_emp_fname_en.Text = idcard.En_Firstname;
                        txt_emp_lname_en.Text = idcard.En_Lastname;
                        dob.Value = idcard.Birthday;
                        int bp_prv_index = cbo_bp_prov.FindString(idcard.addrProvince.Replace("จังหวัด", ""));
                        cbo_bp_prov.SelectedIndex = bp_prv_index;


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

                        int c_prv_index = c_cbo_prov.FindString(idcard.addrProvince.Replace("จังหวัด", ""));
                        c_cbo_prov.SelectedIndex = c_prv_index;

                        int c_am_idx = c_cbo_amp.FindString(idcard.addrAmphur.Replace("อำเภอ", ""));
                        c_cbo_amp.SelectedIndex = c_am_idx; //GetAmphureIDByName(idcard.addrAmphur);


                        c_txt_postcode.Text = DistrictService.GetZipcodeByDistricName(idcard.addrTambol.Replace("ตำบล", ""));

                        //permanent address
                        p_txt_no.Text = idcard.addrHouseNo + " " + idcard.addrVillageNo + " " + idcard.addrLane + " " + idcard.addrRoad;
                        p_txt_road.Text = idcard.addrRoad;
                        p_txt_soi.Text = "";
                        p_txt_tumbol.Text = idcard.addrTambol;

                        int p_prv_idx = p_cbo_prov.FindString(idcard.addrProvince.Replace("จังหวัด", ""));
                        p_cbo_prov.SelectedIndex = p_prv_idx; // GetProvinceIDByName(idcard.addrProvince);

                        int p_amp_idx = p_cbo_amp.FindString(idcard.addrAmphur.Replace("อำเภอ", ""));
                        p_cbo_amp.SelectedIndex = p_amp_idx;// GetAmphureIDByName(idcard.addrAmphur);

                        //image
                        if (idcard.PhotoRaw != null)
                        {
                            this.EmployeePhoto = idcard.PhotoRaw;

                            //add to picture box 
                            pic_emp.Image = GetImage(idcard.PhotoRaw, 150, 187);
                        }
                        else
                        {
                            if (idcard.PhotoBitmap != null)
                            {
                                var myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                                var photo = idcard.PhotoBitmap.GetThumbnailImage(150, 187, myCallback, IntPtr.Zero);
                                pic_emp.Image = photo;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("โหลดข้อมูลไม่สำเร็จ กรุณาลองอีกครั้ง...");
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

        private void SetObjectToControl(Model.Employee empObj)
        {
            try
            {
                lb_isnewemp.Text = "*มีอยู่แล้วในระบบ";
                txt_empid.Text = empObj.EMP_ID;
                txt_pid.Text = empObj.ID_CARD;
                //cbo_title_th.SelectedItem = empObj.TITLE_ID;
                //cbo_title_en.SelectedItem = empObj.TITLE_ID;
                txt_emp_fname_th.Text = empObj.FIRSTNAME_TH;
                txt_emp_lname_th.Text = empObj.LASTNAME_TH;
                txt_emp_fname_en.Text = empObj.FIRSTNAME_EN;
                txt_emp_lname_en.Text = empObj.LASTNAME_EN;
                if (empObj.DATEOFBIRTH != null)
                {
                    dob.Value = empObj.DATEOFBIRTH.Value;
                }
                if (empObj.DATESTARTWORK != null)
                {
                    date_start_work.Value = empObj.DATESTARTWORK.Value;
                }

                txt_blood.Text = empObj.BLOODGROUP;
                txt_apperance.Text = empObj.APPEARANCE;
                txt_defect.Text = empObj.DEFECT;
                txt_area.Text = empObj.AREA;
                txt_mobile.Text = empObj.MOBILE;
                //txt_nick_th.Text = empObj.NICKNAME_TH;
                txt_height.Text = empObj.HEIGHT.ToString();
                txt_weight.Text = empObj.WEIGHT.ToString();

                int cb_th_idx = cbo_title_th.FindString(CommonServices.GetTitleNameByID(empObj.TITLE_ID));
                int cb_en_idx = cbo_title_en.FindString(CommonServices.GetTitleNameByID(empObj.TITLE_ID_EN));
                cbo_title_th.SelectedIndex = cb_th_idx;
                cbo_title_th.SelectedIndex = cb_en_idx;

                int bp_idx = cbo_bp_prov.FindString(GetProvinceNameByID(Convert.ToInt16(empObj.BIRTH_PLACE_PROVINCE)));
                cbo_bp_prov.SelectedIndex = bp_idx;

                txt_regis_no.Text = empObj.REGIS_NO;

                //Status
                int site_idx = cbo_site.FindString(empObj.SITE_LOCATION);
                cbo_site.SelectedIndex = site_idx;
                int status_idx = cbo_status.FindString(empObj.STATUS);
                cbo_status.SelectedIndex = status_idx;
                if (cbo_status.SelectedIndex == 1)
                {
                    int substatus = cbo_substatus.FindString(empObj.SUBSTATUS);
                    cbo_substatus.SelectedIndex = substatus;
                }
                if (cbo_substatus.SelectedIndex == 2)
                {
                    txt_reason.Enabled = true;
                    txt_reason.Text = empObj.STATUS_REASON;
                }

                if (empObj.STATUS == "" || empObj.STATUS == null)
                {
                    cbo_status.SelectedIndex = 0;
                }
                //Gender
                if (empObj.GENDER_ID == 1)
                {
                    cbo_sex.SelectedIndex = 0;
                }
                else
                { cbo_sex.SelectedIndex = 1; }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load Employee..." + ex.Message);
            }

            try
            {
                //Cureent Address
                var current = AddressServices.GetCurrentByEmployeeID(empObj.EMP_ID);
                if (current != null)
                {
                    c_txt_no.Text = current.NAME;
                    c_txt_soi.Text = "";
                    c_txt_tumbol.Text = current.DISTRICT;
                    c_txt_postcode.Text = current.ZIPCODE;
                    int c_prv_index = c_cbo_prov.FindString(GetProvinceNameByID(Convert.ToInt16(current.PROVINCE_ID)));
                    c_cbo_prov.SelectedIndex = c_prv_index;

                    int c_amp_index = c_cbo_amp.FindString(GetCurrentAmphureNameByID(Convert.ToInt16(current.AMPHUR_ID)));
                    c_cbo_amp.SelectedIndex = c_amp_index;

                }

                //permanent address
                var permanent = AddressServices.GetPermanentByEmployeeID(empObj.EMP_ID);
                if (permanent != null)
                {
                    p_txt_no.Text = permanent.NAME;
                    p_txt_soi.Text = "";
                    p_txt_tumbol.Text = permanent.DISTRICT;
                    p_txt_postcode.Text = permanent.ZIPCODE;
                    int p_prv_index = p_cbo_prov.FindString(GetProvinceNameByID(Convert.ToInt16(permanent.PROVINCE_ID)));
                    p_cbo_prov.SelectedIndex = p_prv_index;

                    int c_amp_index = p_cbo_amp.FindString(GetPermanentAmphureNameByID(Convert.ToInt16(permanent.AMPHUR_ID)));
                    p_cbo_amp.SelectedIndex = c_amp_index;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load address..." + ex.Message);
            }
            try
            {
                var profile = ProfileImageDataService.GetByEmployeeID(empObj.EMP_ID);
                if (profile != null)
                {
                    pic_emp.Image = GetImage(profile.PHOTO, 150, 187);
                }

                var cimg = CurrentImageService.GetByEmployeeID(empObj.EMP_ID);
                if (cimg != null)
                {
                    pic_current.Image = GetImage(cimg.PHOTO, 150, 187);
                }

                //Finger
                var finger = FingerScanServices.GetObjByEmployeeID(empObj.EMP_ID);
                if (finger != null)
                {
                    l_finger_1.Image = GetImage(finger.LEFTFINGER1, 150, 158);
                    l_finger_2.Image = GetImage(finger.LEFTFINGER2, 150, 158);
                    l_finger_3.Image = GetImage(finger.LEFTFINGER3, 150, 158);
                    l_finger_4.Image = GetImage(finger.LEFTFINGER4, 150, 158);
                    l_finger_5.Image = GetImage(finger.LEFTFINGER5, 150, 158);

                    R_finger_1.Image = GetImage(finger.RIGHTFINGER1, 150, 158);
                    R_finger_2.Image = GetImage(finger.RIGHTFINGER2, 150, 158);
                    R_finger_3.Image = GetImage(finger.RIGHTFINGER3, 150, 158);
                    R_finger_4.Image = GetImage(finger.RIGHTFINGER4, 150, 158);
                    R_finger_5.Image = GetImage(finger.RIGHTFINGER5, 150, 158);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load Finger..." + ex.Message);
            }

            try
            {
                //Education
                var edu = EducationServices.GetByEmployeeID(empObj.EMP_ID);
                if (edu != null)
                {
                    foreach (var item in edu)
                    {
                        if (item.EDU_TYPE == "อุดมศึกษา/มหาวิทยาลัย")
                        {
                            txt_edu_nm_1.Text = item.NAME;
                            txt_graduated_1.Text = item.GRADUETED;
                            txt_edu_yr_1.Text = item.YEAR;
                        }
                        if (item.EDU_TYPE == "มัธยมศึกษา/ประกาศนียบัตรวิชาชีพ")
                        {
                            txt_edu_nm_2.Text = item.NAME;
                            txt_graduated_2.Text = item.GRADUETED;
                            txt_edu_yr_2.Text = item.YEAR;
                        }
                        if (item.EDU_TYPE == "ประถมศึกษา")
                        {
                            txt_edu_nm_3.Text = item.NAME;
                            txt_graduated_3.Text = item.GRADUETED;
                            txt_edu_yr_3.Text = item.YEAR;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load Education..." + ex.Message);
            }


            try
            {
                //Train
                var tn = TrainingServices.GetByEmployeeID(empObj.EMP_ID);
                if (tn != null)
                {
                    foreach (var item in tn)
                    {
                        if (item.TYPE == "1")
                        {
                            txt_tn_1.Text = item.COURSE;
                            txt_tn_yr_1.Text = item.YEAR;
                            txt_tn_dt_1.Text = item.DETAILS;
                        }
                        if (item.TYPE == "2")
                        {
                            txt_tn_2.Text = item.COURSE;
                            txt_tn_yr_2.Text = item.YEAR;
                            txt_tn_dt_2.Text = item.DETAILS;
                        }
                        if (item.TYPE == "3")
                        {
                            txt_tn_3.Text = item.COURSE;
                            txt_tn_yr_3.Text = item.YEAR;
                            txt_tn_dt_3.Text = item.DETAILS;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load Training..." + ex.Message);
            }

            try
            {
                //Experience
                var exp = WorkExperienceServices.GetByEmployeeID(empObj.EMP_ID);
                if (exp != null)
                {
                    foreach (var item in exp)
                    {
                        if (item.TYPE == "1")
                        {
                            txt_exp_comname_1.Text = item.NAME;
                            txt_exp_period_1.Text = item.PERIOD;
                            txt_exp_pos1.Text = item.POSITION;
                            txt_exp_salary_1.Text = item.SALARY;

                        }
                        if (item.TYPE == "2")
                        {
                            txt_exp_comname_2.Text = item.NAME;
                            txt_exp_period_2.Text = item.PERIOD;
                            txt_we_pos2.Text = item.POSITION;
                            txt_exp_salary_2.Text = item.SALARY;

                        }
                        if (item.TYPE == "3")
                        {
                            txt_exp_comname_3.Text = item.NAME;
                            txt_exp_period_3.Text = item.PERIOD;
                            txt_we_pos3.Text = item.POSITION;
                            txt_exp_salary_3.Text = item.SALARY;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load Experience..." + ex.Message);
            }

            try
            {
                //Person
                var refppl = ReferencePersonServices.GetByEmployeeID(empObj.EMP_ID);
                if (refppl != null)
                {
                    foreach (var item in refppl)
                    {
                        if (item.TYPE == "1")
                        {
                            txt_ref_name_1.Text = item.NAME;
                            txt_ref_relation_1.Text = item.RELATIONSHIFT;
                            txt_ref_contact_1.Text = item.TELEPHONE;
                            txt_ref_add_1.Text = item.ADDRESS;
                        }
                        if (item.TYPE == "2")
                        {
                            txt_ref_name_2.Text = item.NAME;
                            txt_ref_relation_2.Text = item.RELATIONSHIFT;
                            txt_ref_contact_2.Text = item.TELEPHONE;
                            txt_ref_add_2.Text = item.ADDRESS;
                        }
                        if (item.TYPE == "3")
                        {
                            txt_ref_name_3.Text = item.NAME;
                            txt_ref_relation_3.Text = item.RELATIONSHIFT;
                            txt_ref_contact_3.Text = item.TELEPHONE;
                            txt_ref_add_3.Text = item.ADDRESS;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load Reference Person..." + ex.Message);
            }


            try
            {
                //SSO
                var sso = SSOServices.GetByEmployeeID(empObj.EMP_ID);
                if (sso != null)
                {
                    if (cbo_sso_prov.Items.Count == 0 || cbo_sso_prov.DataSource == null)
                    {
                        InitialSSOProvince();
                    }
                    foreach (var item in sso)
                    {
                        if (item.NOTINDATABASE == true)
                        {
                            chk_nothave_sso.Checked = true;
                        }
                        else
                        {
                            chk_nothave_sso.Checked = false;
                            chk_have_sso.Checked = true;
                            int idx1 = cbo_sso_prov.FindString(item.PROVINCE_NAME);
                            cbo_sso_prov.SelectedIndex = idx1;
                            int idx2 = cbo_sso_hospital.FindString(item.HOSPITAL_NAME);
                            cbo_sso_hospital.SelectedIndex = idx2;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load SSO..." + ex.Message);
            }

            try
            {
                //Reference Document
                var refdoc = RefDocumentServices.GetByEmployeeID(empObj.EMP_ID);
                if (refdoc != null)
                {
                    foreach (var item in refdoc)
                    {
                        if (item.TYPE == "สำเนาบัตรประชาชน")
                        {
                            pic_copy_idcard.Image = GetImage(item.PHOTO, 367, 452);
                        }
                        if (item.TYPE == "สำเนาทะเบียนบ้าน")
                        {
                            if (item.FILENAME != null)
                            {
                                listbox_refdoc_1.Items.Add(item.FILENAME);

                            }
                            else
                            {
                                listbox_refdoc_1.Items.Add(item.TYPE);

                            }
                            RefDoc.Add(item);
                            //pic_copy_home.Image = GetImage(item.PHOTO, 367, 452);
                        }
                        if (item.TYPE == "สำเนาใบผ่านทหาร")
                        {
                            if (item.FILENAME != null)
                            {
                                listbox_refdoc_1.Items.Add(item.FILENAME);

                            }
                            else
                            {
                                listbox_refdoc_1.Items.Add(item.TYPE);

                            }
                            RefDoc.Add(item);
                            //pic_copy_military.Image = GetImage(item.PHOTO, 367, 452);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load Reference Document..." + ex.Message);
            }

            try
            {
                //Other Document
                var otherdoc = OtherDocumentServices.GetByEmployeeID(empObj.EMP_ID);
                if (otherdoc != null)
                {
                    foreach (var item in otherdoc)
                    {
                        if (item.TYPE == "เอกสารแต่งตั้ง")
                        {
                            if (item.FILENAME != null)
                            {
                                listbox_other_doc1.Items.Add(item.FILENAME);
                            }
                            else
                            {
                                listbox_other_doc1.Items.Add(item.TYPE);
                            }
                            OtherDoc.Add(item);
                        }
                        if (item.TYPE == "เอกสารเพิ่มเงิน")
                        {
                            if (item.FILENAME != null)
                            {
                                listbox_other_doc1.Items.Add(item.FILENAME);
                            }
                            else
                            {
                                listbox_other_doc1.Items.Add(item.TYPE);
                            }
                            OtherDoc.Add(item);
                        }
                        if (item.TYPE == "ใบเตือน")
                        {
                            if (item.FILENAME != null)
                            {
                                listbox_other_doc1.Items.Add(item.FILENAME);
                            }
                            else
                            {
                                listbox_other_doc1.Items.Add(item.TYPE);
                            }
                            OtherDoc.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load Other Document..." + ex.Message);
            }

            try
            {
                //Equipment
                var equip = EquiptmentServices.GetByEmployeeID(empObj.EMP_ID);
                var deduc = DeductionService.GetByEmployeeID(empObj.EMP_ID);
                if (deduc != null)
                {
                    foreach (var item in deduc)
                    {
                        if (item.NO == 1)
                        {
                            if (item.DATE != null)
                            {
                                lbd1.Text = "หักครั้งที่ 1 : " + item.PRICE.ToString() + " บาท";
                                dt_deduct1.Value = item.DATE.Value;
                            }
                        }
                        if (item.NO == 2)
                        {
                            if (item.DATE != null)
                            {
                                lbd2.Text = "หักครั้งที่ 2 : " + item.PRICE.ToString() + " บาท";
                                dt_deduct2.Value = item.DATE.Value;
                            }
                        }
                        if (item.NO == 3)
                        {
                            if (item.DATE != null)
                            {
                                lbd3.Text = "หักครั้งที่ 3 : " + item.PRICE.ToString() + " บาท";
                                dt_deduct3.Value = item.DATE.Value;
                            }
                        }
                        if (item.NO == 4)
                        {
                            if (item.DATE != null)
                            {
                                lbd4.Text = "หักครั้งที่ 4 : " + item.PRICE.ToString() + " บาท";
                                dt_deduct4.Value = item.DATE.Value;
                            }
                        }
                        if (item.NO == 5)
                        {
                            if (item.DATE != null)
                            {
                                lbd5.Text = "หักครั้งที่ 5 : " + item.PRICE.ToString() + " บาท";
                                dt_deduct5.Value = item.DATE.Value;
                            }
                        }
                        if (item.NO == 6)
                        {
                            if (item.DATE != null)
                            {
                                lbd6.Text = "หักครั้งที่ 6 : " + item.PRICE.ToString() + " บาท";
                                dt_deduct6.Value = item.DATE.Value;
                            }
                        }
                        if (item.NO == 7)
                        {
                            if (item.DATE != null)
                            {
                                lbd7.Text = "หักครั้งที่ 7 : " + item.PRICE.ToString() + " บาท";
                                dt_deduct7.Value = item.DATE.Value;
                            }
                        }
                        if (item.NO == 8)
                        {
                            if (item.DATE != null)
                            {
                                lbd8.Text = "หักครั้งที่ 8 : " + item.PRICE.ToString() + " บาท";
                                dt_deduct8.Value = item.DATE.Value;
                            }
                        }
                    }
                }

                if (equip != null)
                {
                    foreach (var item in equip)
                    {
                        if (item.EQUIP_NAME == "ประกัน")
                        {
                            chk_1.Checked = true;
                            txt_eq_1.Text = item.EQUIP_AMOUNT;
                        }
                        if (item.EQUIP_NAME == "ค่าชุด")
                        {
                            chk_2.Checked = true;
                            txt_eq_2.Text = item.EQUIP_AMOUNT;
                        }
                        if (item.EQUIP_NAME == "สายนกหวีด")
                        {
                            chk_3.Checked = true;
                            txt_eq_3.Text = item.EQUIP_AMOUNT;
                        }
                        //if (item.EQUIP_NAME == "แถบสี")
                        //{
                        //    chk_4.Checked = true;
                        //    txt_eq_4.Text = item.EQUIP_AMOUNT;
                        //}
                        //if (item.EQUIP_NAME == "กนกคอ")
                        //{
                        //    chk_5.Checked = true;
                        //    txt_eq_5.Text = item.EQUIP_AMOUNT;
                        //}
                        //if (item.EQUIP_NAME == "เข็มบรรเทา")
                        //{
                        //    chk_6.Checked = true;
                        //    txt_eq_6.Text = item.EQUIP_AMOUNT;
                        //}
                        if (item.EQUIP_NAME == "เข็มขัด")
                        {
                            chk_4.Checked = true;
                            txt_eq_4.Text = item.EQUIP_AMOUNT;
                        }
                        if (item.EQUIP_NAME == "ดิ้ว")
                        {
                            chk_5.Checked = true;
                            txt_eq_5.Text = item.EQUIP_AMOUNT;
                        }
                        if (item.EQUIP_NAME == "หมวก")
                        {
                            chk_6.Checked = true;
                            txt_eq_6.Text = item.EQUIP_AMOUNT;
                        }
                        if (item.EQUIP_NAME == "รองเท้า")
                        {
                            chk_7.Checked = true;
                            txt_eq_7.Text = item.EQUIP_AMOUNT;
                        } 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Load Other Equipment..." + ex.Message);
            }
        }

        private Image GetImage(byte[] PHOTO, int width, int height)
        {
            var myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            var myBitmap = new Bitmap(byteArrayToImage(PHOTO));
            var myThumbnail = myBitmap.GetThumbnailImage(width, height, myCallback, IntPtr.Zero);
            return myThumbnail;
        }

        private bool Save()
        {
            var result = true;
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

                //Finger Scan
                var finger = getFingerFromInput();
                UploadFingerScan(finger);

                //Photo PID
                var photo = getPhotoEmployee();
                UploadPhoto(photo);

                //Current Photo
                var cphoto = getCurrentPhotoEmployee();
                UploadCurrentPhoto(cphoto);

                //Save Address
                var listAddress = getAddressListfrominput();
                CreateAddress(listAddress);

                //Save Education 
                var listEdu = getEducationListfrominput();
                CreateEducation(listEdu);

                //Training
                var listTrain = getTrainingListfrominput();
                CreateTraining(listTrain);

                //Work Exp
                var listExp = getExperienceListfrominput();
                CreateWorkExp(listExp);

                //Reference_person
                var listRefPerson = getRefPersonListfrominput();
                CreateRefPerson(listRefPerson);

                //SSO
                var listSSO = getSSOListfrominput();
                CreateSSO(listSSO);

                //Reference Documents
                getRefDocFormInput();
                CreateReferenceDoc(RefDoc);

                //Other Documents
                CreateOtherDoc(OtherDoc);

                //Equipments
                var listEquip = getEquiptListfrominput();
                CreateEquipment(listEquip);

                //deduc
                var listDeduc = getDeductionListfrominput();
                CreateDeduction(listDeduc);

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool UploadPhoto(EmployeeImage Img)
        {
            var result = false;
            try
            {
                ProfileImageDataService.UploadPhoto(Img);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        private bool UploadCurrentPhoto(CurrentImage Img)
        {
            var result = false;
            try
            {
                CurrentImageService.UploadPhoto(Img);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }

        private void DownloadRefPDF(ReferenceDocument doc)
        {
            FileStream FS = null;
            byte[] dbbyte;
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    dbbyte = (byte[])doc.FILEBINARY;
                    string filepath = fbd.SelectedPath + "\\" + doc.FILENAME;
                    FS = new FileStream(filepath, System.IO.FileMode.Create);
                    FS.Write(dbbyte, 0, dbbyte.Length);

                    MessageBox.Show("ดาวน์โหลดเอกสาร " + doc.FILENAME + " เรียบร้อย!!!");
                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
            finally
            {
                if (FS != null)
                {
                    FS.Close();
                }
            }
        }

        private void DownloadOtherPDF(OtherDocument doc)
        {
            FileStream FS = null;
            byte[] dbbyte;
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    dbbyte = (byte[])doc.FILEBINARY;
                    string filepath = fbd.SelectedPath + "\\" + doc.FILENAME;
                    FS = new FileStream(filepath, System.IO.FileMode.Create);
                    FS.Write(dbbyte, 0, dbbyte.Length);

                    MessageBox.Show("ดาวน์โหลดเอกสาร " + doc.FILENAME + " เรียบร้อย!!!");
                }
            }
            catch (Exception ex)
            {
                throw new System.ArgumentException(ex.Message);
            }
            finally
            {

                if (FS != null)
                {
                    FS.Close();
                }
            }
        }

        #endregion

        #region ===Events===
         
        public BIG.Model.Employee employee { get; set; }

        private void EmployeeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
            var from = new PersonalForm();
            from.Show(); 
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                DialogResult result = MessageBox.Show("คุณต้องการบันทึกข้อมูลพนักงาน?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (this.Save())
                    {
                        MessageBox.Show("บันทึกข้อมูลพนักงานเรียบร้อย!!!");
                    }
                }
                else if (result == DialogResult.No)
                {
                    //...
                }
            }
            else
            {
                // MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน ตามเครื่องหมาย *");
            }

        }
        private void rb_save_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                DialogResult result = MessageBox.Show("คุณต้องการบันทึกข้อมูลพนักงาน?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (this.Save())
                    {
                        MessageBox.Show("บันทึกข้อมูลพนักงานเรียบร้อย!!!");
                    }
                }
                else if (result == DialogResult.No)
                {
                }
            }
            else
            {
                //MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน ตามเครื่องหมาย *");
            }
        }

        private void rb_edit_Click(object sender, EventArgs e)
        {
            EmployeeMode(true);
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
            Neurotec.Biometrics.Nffv engine = null;
            try
            {
                engine = new Neurotec.Biometrics.Nffv("FingerprintDB.CSharpSample.dat", "", "UareU");
            }
            catch (Exception ex)
            {
                MessageBox.Show("เครื่องสแกนนิ้วยังไม่พร้อมใช้งาน กรณาลองอีกครั้ง");// MessageBoxButtons.OK, MessageBoxIcon.Error);
                var frm = new MainForm();
                frm.Show();
                Hide();
            }

            var emp = new EmployeeForm(engine);
            emp.Show();
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
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                //...
            }
        }

        private void c_cbo_prov_SelectedIndexChanged(object sender, EventArgs e)
        {
            var province_id = 0;
            if (c_cbo_prov.SelectedValue != null)
            {
                int.TryParse(c_cbo_prov.SelectedValue.ToString(), out province_id);

                if (province_id != 0)
                {
                    var listamp1 = ProvinceServices.GetListAmphur(province_id);
                    c_cbo_amp.DataSource = listamp1;
                    c_cbo_amp.DisplayMember = "AMPHUR_NAME";
                    c_cbo_amp.ValueMember = "AMPHUR_ID";
                }
            } 
        }

        private void p_cbo_prov_SelectedIndexChanged(object sender, EventArgs e)
        {
            var province_id = 0;
            if (p_cbo_prov.SelectedValue != null)
            {
                int.TryParse(p_cbo_prov.SelectedValue.ToString(), out province_id);

                if (province_id != 0)
                {
                    var listamp2 = ProvinceServices.GetListAmphur(province_id);

                    p_cbo_amp.DataSource = listamp2;
                    p_cbo_amp.DisplayMember = "AMPHUR_NAME";
                    p_cbo_amp.ValueMember = "AMPHUR_ID";
                }
            }
             
        }

        private void c_cbo_amp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_cbo_prov.SelectedValue != null && c_cbo_amp.SelectedValue != null)
            {
                int p_id = 0; int a_id = 0;
                int.TryParse(c_cbo_prov.SelectedValue.ToString(), out p_id);
                int.TryParse(c_cbo_amp.SelectedValue.ToString(), out a_id);

                var listDistrict = DistrictService.GetDistrictByAmphurID(p_id, a_id);
                var ds = listDistrict.Select(x => new { x.DISTRICT_ID, x.DISTRICT_NAME }).ToList();
                c_cbo_distict.DataSource = ds;
                c_cbo_distict.DisplayMember = "DISTRICT_NAME";
                c_cbo_distict.ValueMember = "DISTRICT_ID";
                if (ds.Count > 0)
                {
                    c_cbo_distict.SelectedIndex = 0;
                    if (c_cbo_distict.SelectedValue != null)
                    {
                        var dis = c_cbo_distict.SelectedValue.ToString();
                        c_txt_postcode.Text = DistrictService.GetZipcodeByDistricID(p_id.ToString(), a_id.ToString(), dis);
                    }
                }
            }
        }

        private void p_cbo_amp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (p_cbo_prov.SelectedValue != null && p_cbo_amp.SelectedValue != null)
            {
                int p_id = 0; int a_id = 0;
                int.TryParse(p_cbo_prov.SelectedValue.ToString(), out p_id);
                int.TryParse(p_cbo_amp.SelectedValue.ToString(), out a_id);

                var listDistrict = DistrictService.GetDistrictByAmphurID(p_id, a_id);
                var ds = listDistrict.Select(x => new { x.DISTRICT_ID, x.DISTRICT_NAME }).ToList();
                p_cbo_district.DataSource = ds;
                p_cbo_district.DisplayMember = "DISTRICT_NAME";
                p_cbo_district.ValueMember = "DISTRICT_ID";
                if (ds.Count > 0)
                {
                    p_cbo_district.SelectedIndex = 0;
                    if (p_cbo_district.SelectedValue != null)
                    {
                        var dis = p_cbo_district.SelectedValue.ToString();
                        p_txt_postcode.Text = DistrictService.GetZipcodeByDistricID(p_id.ToString(), a_id.ToString(), dis);
                    }
                }
            }
        }

        private void c_cbo_distict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (c_cbo_prov.SelectedValue != null && c_cbo_amp.SelectedValue != null)
            {
                if (c_cbo_distict.SelectedValue != null)
                {
                    var p_id = c_cbo_prov.SelectedValue.ToString();
                    var a_id = c_cbo_amp.SelectedValue.ToString();
                    var dis = c_cbo_distict.SelectedValue.ToString();
                    c_txt_postcode.Text = DistrictService.GetZipcodeByDistricID(p_id.ToString(), a_id.ToString(), dis);
                }
            }
        }

        private void p_cbo_district_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (p_cbo_prov.SelectedValue != null && p_cbo_amp.SelectedValue != null)
            {
                if (p_cbo_district.SelectedValue != null)
                {
                    var p_id = p_cbo_prov.SelectedValue.ToString();
                    var a_id = p_cbo_amp.SelectedValue.ToString();
                    var dis = p_cbo_district.SelectedValue.ToString();
                    p_txt_postcode.Text = DistrictService.GetZipcodeByDistricID(p_id.ToString(), a_id.ToString(), dis);
                }
            }
        }

        private void btn_new_img_Click(object sender, EventArgs e)
        {

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        currentImgName = file;
                        var myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                        var myBitmap = new Bitmap(file);
                        var myThumbnail = myBitmap.GetThumbnailImage(150, 149, myCallback, IntPtr.Zero);
                        pic_current.Image = myThumbnail;

                    }
                    catch (Exception ex)
                    {
                        currentImgName = "";
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btn_new_img_card_Click(object sender, EventArgs e)
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
                        pic_emp.Image = myThumbnail;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        #region ==== camera ====

        private void bntCaptureIDCard_Click(object sender, EventArgs e)
        {
            imgCaptureIDCard.Image = imgVideo.Image;
            pic_copy_idcard.Image = imgVideo.Image;
        }

        private void btn_ref_img_Click(object sender, EventArgs e)
        {
            EmployeeTab.SelectTab(tabCamera);
            webcam.Start();
        }
        private void bntCapture_Click(object sender, EventArgs e)
        {
            imgCurrentImage.Image = imgVideo.Image;
            pic_current.Image =  imgVideo.Image;
        }
        private void bntSave_Click(object sender, EventArgs e)
        {
            pic_current.Image = imgCaptureIDCard.Image;
        }

        private void bntVideoFormat_Click(object sender, EventArgs e)
        {
            webcam.ResolutionSetting();
        }
        private void bntVideoSource_Click(object sender, EventArgs e)
        {
            webcam.AdvanceSetting();
        }



        #endregion

        private void btn_new_img_del_Click(object sender, EventArgs e)
        {
            pic_emp.Image = BIG.Present.Properties.Resources.pid_icon1;
        }

        private void btn_new_img_refresh_Click(object sender, EventArgs e)
        {

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
            //var mainform = new MainForm();
            //mainform.Show();
            var main = new PersonalForm();
            main.Show();
            Hide();
        }

        private void rb_new_Click(object sender, EventArgs e)
        {
            Neurotec.Biometrics.Nffv engine = null;
            try
            {
                engine = new Neurotec.Biometrics.Nffv("FingerprintDB.CSharpSample.dat", "", "UareU");
            }
            catch (Exception ex)
            {
                MessageBox.Show("เครื่องสแกนนิ้วยังไม่พร้อมใช้งาน กรณาลองอีกครั้ง");// MessageBoxButtons.OK, MessageBoxIcon.Error);
                var frm = new MainForm();
                frm.Show();
                
            }
            Hide();
            var emp = new EmployeeForm(engine);
            emp.Show();

        }

        private void rb_setting_company_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var frm = new CompanyInfoForm();
            frm.Show();
            Hide();
        }

        private void rb_load_idcard_Click(object sender, EventArgs e)
        {
            LoadPID();
        }

        private void rb_personal_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var frm = new PersonalForm();
            frm.Show();
            Hide();
        }

        private void rb_load_pid_Click(object sender, EventArgs e)
        {

        }

        private void rb_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void rb_logout_Click(object sender, EventArgs e)
        {
            this.Hide();
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


        private void chk_have_sso_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_have_sso.Checked)
            {
                chk_nothave_sso.Checked = false;
            }
            if (cbo_sso_prov.Items.Count == 0)
            {
                InitialSSOProvince();
            }
        }

        private void chk_nothave_sso_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_nothave_sso.Checked)
            {
                chk_have_sso.Checked = false;
            }
            if (cbo_sso_prov.Items.Count == 0)
            {
                InitialSSOProvince();
            }
        }

        private void cbo_sso_prov_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_sso_prov.SelectedValue != null)
            {
                var list = CommonServices.GetHospitalByProvinceName(cbo_sso_prov.SelectedValue.ToString());
                if (list.Count > 0)
                {
                    cbo_sso_hospital.DataSource = list;
                    cbo_sso_hospital.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("ไม่สามารถโหลดข้อมูลประกันสังคมได้");
                }
            }
        }

        #endregion
        
        #region ===Upload doc idcard===

        private void btn_upload_copy_idcard_Click(object sender, EventArgs e)
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
                        var myThumbnail = myBitmap.GetThumbnailImage(360, 450, myCallback, IntPtr.Zero);
                        pic_copy_idcard.Image = myThumbnail;

                        if (txt_empid.Text != "")
                        {
                            var doc = RefDoc.Where(x => x.EMP_ID == txt_empid.Text && x.TYPE == "สำเนาบัตรประชาชน").ToList();
                            foreach (var item in doc)
                            {
                                RefDoc.Remove(item);
                            }
                            var obj = new ReferenceDocument();
                            obj.EMP_ID = txt_empid.Text;
                            obj.PHOTO = ConvertImageToByteArray(myThumbnail, System.Drawing.Imaging.ImageFormat.Jpeg);
                            obj.TYPE = "สำเนาบัตรประชาชน";
                            obj.CREATE_DATE = DateTime.Now;
                            RefDoc.Add(obj);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("btn_upload_copy_idcard_Click: " + ex.Message);
                    }
                }
            }
        }

        private void btn_refresh_copy_idcard_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_copy_idcard_Click(object sender, EventArgs e)
        {
            var refdoc = RefDoc.Where(x => x.TYPE == "สำเนาบัตรประชาชน").FirstOrDefault();
            if (txt_empid.Text != "" && refdoc != null)
            {
                refdoc.TYPE = "Delete";
            }
            pic_copy_idcard.Image = BIG.Present.Properties.Resources.idcard_template;
        }
        #endregion

        #region ===Upload ทะเบียนบ้าน===

        private void btn_upload_copy_home_Click(object sender, EventArgs e)
        {

            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select file for upload";
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        var arr = file.Split('\\');

                        string filename = arr.Last();
                        byte[] bytearr;
                        using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new BinaryReader(stream))
                            {
                                bytearr = reader.ReadBytes((int)stream.Length);
                            }
                        }
                        if (txt_empid.Text != "")
                        {
                            var doc = RefDoc.Where(x => x.EMP_ID == txt_empid.Text && x.TYPE == "สำเนาทะเบียนบ้าน" && x.FILENAME == filename).ToList();
                            foreach (var item in doc)
                            {
                                RefDoc.Remove(item);
                                listbox_refdoc_1.Items.Remove(item.FILENAME);
                            }
                            var obj = new ReferenceDocument();
                            obj.EMP_ID = txt_empid.Text;
                            obj.FILEBINARY = bytearr;
                            obj.FILENAME = filename;
                            obj.FULLPATH = file.ToString();
                            obj.TYPE = "สำเนาทะเบียนบ้าน";
                            obj.CREATE_DATE = DateTime.Now;
                            RefDoc.Add(obj);
                            listbox_refdoc_1.Items.Add(filename);
                        }
                        else
                        {
                            MessageBox.Show("กรุณากรอกข้อมูลรหัสพนักงาน");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("btn_upload_copy_home_Click: " + ex.Message);
                    }
                }
            }
        }

        private void btn_refresh_copy_home_Click(object sender, EventArgs e)
        {
            var filename = listbox_refdoc_1.SelectedItem.ToString();
            var doc = RefDoc.Where(x => x.EMP_ID == txt_empid.Text && x.TYPE == "สำเนาทะเบียนบ้าน" && x.FILENAME == filename).FirstOrDefault();
            if (doc != null)
            {
                DownloadRefPDF(doc);
            }
        }
        private void btn_delete_copy_home_Click(object sender, EventArgs e)
        {
            var refdoc = RefDoc.Where(x => x.TYPE == "สำเนาบัตรประชาชน").FirstOrDefault();
            if (txt_empid.Text != "" && refdoc != null)
            {
                refdoc.TYPE = "Delete";
                listbox_refdoc_1.Items.Clear();
            }
            listbox_refdoc_1.Items.Clear();
        }

        #endregion

        #region ===Upload ใบผ่านทหาร ===

        private void btn_upload_copy_military_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select file for upload";
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        var arr = file.Split('\\');
                        string filename = arr.Last();
                        byte[] bytearr;
                        using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new BinaryReader(stream))
                            {
                                bytearr = reader.ReadBytes((int)stream.Length);
                            }
                        }
                        if (txt_empid.Text != "")
                        {
                            var doc = RefDoc.Where(x => x.EMP_ID == txt_empid.Text && x.TYPE == "สำเนาใบผ่านทหาร" && x.FILENAME == filename).ToList();
                            foreach (var item in doc)
                            {
                                RefDoc.Remove(item);
                                listbox_refdoc_2.Items.Remove(item.FILENAME);
                            }
                            var obj = new ReferenceDocument();
                            obj.EMP_ID = txt_empid.Text;
                            obj.FILEBINARY = bytearr;
                            obj.FILENAME = filename;
                            obj.FULLPATH = file.ToString();
                            obj.TYPE = "สำเนาใบผ่านทหาร";
                            obj.CREATE_DATE = DateTime.Now;
                            RefDoc.Add(obj);
                            listbox_refdoc_2.Items.Add(filename);
                        }
                        else
                        {
                            MessageBox.Show("กรุณากรอกข้อมูลรหัสพนักงาน");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("btn_upload_copy_home_Click: " + ex.Message);
                    }
                }
            }
        }

        private void btn_upload_refresh_military_Click(object sender, EventArgs e)
        {
            var filename = listbox_refdoc_2.SelectedItem.ToString();
            var doc = RefDoc.Where(x => x.EMP_ID == txt_empid.Text && x.TYPE == "สำเนาใบผ่านทหาร" && x.FILENAME == filename).FirstOrDefault();
            if (doc != null)
            {
                DownloadRefPDF(doc);
            }
        }

        private void btn_delete_copy_military_Click(object sender, EventArgs e)
        {
            var refdoc = RefDoc.Where(x => x.TYPE == "สำเนาใบผ่านทหาร").FirstOrDefault();
            if (txt_empid.Text != "" && refdoc != null)
            {
                refdoc.TYPE = "Delete";

                //pic_copy_military.Image = null;
            }
            listbox_refdoc_2.Items.Clear();
        }

        #endregion

        #region ===Upload เอกสารแต่งตั้ง ===

        private void btn_upload_promote_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select file for upload";
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        var arr = file.Split('\\');
                        string filename = arr.Last();
                        byte[] bytearr;
                        using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new BinaryReader(stream))
                            {
                                bytearr = reader.ReadBytes((int)stream.Length);
                            }
                        }
                        if (txt_empid.Text != "")
                        {
                            var doc = OtherDoc.Where(x => x.EMP_ID == txt_empid.Text && x.TYPE == "เอกสารแต่งตั้ง" && x.FILENAME == filename).ToList();
                            foreach (var item in doc)
                            {
                                OtherDoc.Remove(item);
                                listbox_other_doc1.Items.Remove(item.FILENAME);

                            }
                            var obj = new OtherDocument();
                            obj.EMP_ID = txt_empid.Text;
                            obj.FILEBINARY = bytearr;
                            obj.FILENAME = filename;
                            obj.FULLPATH = file.ToString();
                            obj.TYPE = "เอกสารแต่งตั้ง";
                            obj.CREATE_DATE = DateTime.Now;
                            OtherDoc.Add(obj);
                            listbox_other_doc1.Items.Add(filename);
                        }
                        else
                        {
                            MessageBox.Show("กรุณากรอกข้อมูลรหัสพนักงาน");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("btn_upload_promote_Click: " + ex.Message);
                    }
                }
            }
        }

        private void btn_refresh_promote_Click(object sender, EventArgs e)
        {
            var filename = listbox_other_doc1.SelectedItem.ToString();
            var doc = OtherDoc.Where(x => x.EMP_ID == txt_empid.Text && x.TYPE == "เอกสารแต่งตั้ง" && x.FILENAME == filename).FirstOrDefault();
            if (doc != null)
            {
                DownloadOtherPDF(doc);
            }
        }

        private void btn_delete_promote_Click(object sender, EventArgs e)
        {
            var refdoc = RefDoc.Where(x => x.TYPE == "เอกสารแต่งตั้ง").FirstOrDefault();
            if (txt_empid.Text != "" && refdoc != null)
            {
                refdoc.TYPE = "Delete";
            }
            listbox_other_doc1.Items.Clear();
        }

        #endregion

        #region ===Upload เอกสารเพิ่มเงิน ===
        private void btn_upload_salary_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select file for upload";
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        var arr = file.Split('\\');
                        string filename = arr.Last();
                        byte[] bytearr;
                        using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new BinaryReader(stream))
                            {
                                bytearr = reader.ReadBytes((int)stream.Length);
                            }
                        }
                        if (txt_empid.Text != "")
                        {
                            var doc = OtherDoc.Where(x => x.EMP_ID == txt_empid.Text && x.TYPE == "เอกสารเพิ่มเงิน" && x.FILENAME == filename).ToList();
                            foreach (var item in doc)
                            {
                                OtherDoc.Remove(item);
                                listbox_other_doc2.Items.Remove(item.FILENAME);
                            }
                            var obj = new OtherDocument();
                            obj.EMP_ID = txt_empid.Text;
                            obj.FILEBINARY = bytearr;
                            obj.FILENAME = filename;
                            obj.FULLPATH = file.ToString();
                            obj.TYPE = "เอกสารเพิ่มเงิน";
                            obj.CREATE_DATE = DateTime.Now;
                            OtherDoc.Add(obj);
                            listbox_other_doc2.Items.Add(filename);
                        }
                        else
                        {
                            MessageBox.Show("กรุณากรอกข้อมูลรหัสพนักงาน");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("btn_upload_copy_home_Click: " + ex.Message);
                    }
                }
            }
        }

        private void btn_refresh_salary_Click(object sender, EventArgs e)
        {
            var filename = listbox_other_doc2.SelectedItem.ToString();
            var doc = OtherDoc.Where(x => x.EMP_ID == txt_empid.Text && x.TYPE == "เอกสารเพิ่มเงิน" && x.FILENAME == filename).FirstOrDefault();
            if (doc != null)
            {
                DownloadOtherPDF(doc);
            }
        }

        private void btn_delete_salary_Click(object sender, EventArgs e)
        {
            var refdoc = RefDoc.Where(x => x.TYPE == "เอกสารแต่งตั้ง").FirstOrDefault();
            if (txt_empid.Text != "" && refdoc != null)
            {
                refdoc.TYPE = "Delete";

            }
            listbox_other_doc2.Items.Clear();
        }
        #endregion

        #region ===Upload ใบเตือน ===
        private void btn_upload_warning_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select file for upload";
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        var arr = file.Split('\\');
                        string filename = arr.Last();
                        byte[] bytearr;
                        using (var stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = new BinaryReader(stream))
                            {
                                bytearr = reader.ReadBytes((int)stream.Length);
                            }
                        }
                        if (txt_empid.Text != "")
                        {
                            var doc = OtherDoc.Where(x => x.EMP_ID == txt_empid.Text && x.TYPE == "ใบเตือน" && x.FILENAME == filename).ToList();
                            foreach (var item in doc)
                            {
                                OtherDoc.Remove(item);
                                listbox_other_doc2.Items.Remove(item.FILENAME);
                            }
                            var obj = new OtherDocument();
                            obj.EMP_ID = txt_empid.Text;
                            obj.FILEBINARY = bytearr;
                            obj.FILENAME = filename;
                            obj.FULLPATH = file.ToString();
                            obj.TYPE = "ใบเตือน";
                            obj.CREATE_DATE = DateTime.Now;
                            OtherDoc.Add(obj);
                            listbox_other_doc3.Items.Add(filename);
                        }
                        else
                        {
                            MessageBox.Show("กรุณากรอกข้อมูลรหัสพนักงาน");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("btn_upload_copy_home_Click: " + ex.Message);
                    }
                }
            }
        }

        private void btn_refresh_warning_Click(object sender, EventArgs e)
        {
            var filename = listbox_other_doc3.SelectedItem.ToString();
            var doc = OtherDoc.Where(x => x.EMP_ID == txt_empid.Text && x.TYPE == "ใบเตือน" && x.FILENAME == filename).FirstOrDefault();
            if (doc != null)
            {
                DownloadOtherPDF(doc);
            }
        }

        private void btn_delete_warning_Click(object sender, EventArgs e)
        {
            var refdoc = RefDoc.Where(x => x.TYPE == "ใบเตือน").FirstOrDefault();
            if (txt_empid.Text != "" && refdoc != null)
            {
                refdoc.TYPE = "Delete";
            }
            listbox_other_doc3.Items.Clear();
        }
        #endregion

        #region ================= Ribbon ==============================================
        private void rb_print_Click(object sender, EventArgs e)
        {
            if (txt_empid.Text != "")
            {
                var form = new ReportEmployee(txt_empid.Text);
                Hide();
                form.Show();
            }
            else
            {
                var form = new ReportEmployee(txt_empid.Text);
                form.Show();
                Hide();
            }
        }

        private void ribbonButton21_CanvasChanged(object sender, EventArgs e)
        {
            Hide();
            var pform = new PersonalForm();
            pform.Show();
        }

        private void ribbonButton22_Click(object sender, EventArgs e)
        {
            Hide();
            var pform = new PersonalForm();
            pform.Show();
        }

        private void ribbonButton23_Click(object sender, EventArgs e)
        {
            Hide();
            var pform = new PersonalForm();
            pform.Show();
        }

        private void ribbonButton24_Click(object sender, EventArgs e)
        {
            Hide();
            var pform = new PersonalForm();
            pform.Show();
        }

        private void ribbonButton17_Click(object sender, EventArgs e)
        {
            Hide();
            var pform = new ReportAllEmployeeForm();
            pform.Show();
        }

        private void ribbonButton18_Click(object sender, EventArgs e)
        {
            Hide();
            var pform = new ReportEmployee();
            pform.Show();
        }

        private void ribbonButton19_Click(object sender, EventArgs e)
        {
            Hide();
            var pform = new ReportEmployee();
            pform.Show();
        }

        private void ribbonButton20_Click(object sender, EventArgs e)
        {
            Hide();
            var pform = new ReportEmployee();
            pform.Show();
        }

        private void linkLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel5_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {


        }

        #endregion

        #region =========================================================Finger Scan =================================================================

        private void StartScan(PictureBox pic)
        {
            _engine = new Neurotec.Biometrics.Nffv("FingerprintDB.CSharpSample.dat", "", "UareU");

            try
            {
                ClearFingerdatabase();
                RunWorkerCompletedEventArgs taskResult = BusyForm.RunLongTask("กรุณาสแกนลายนิ้วมือ....", new DoWorkEventHandler(doEnroll),
                    false, null, new EventHandler(CancelScanningHandler));
                EnrollmentResult enrollmentResult = (EnrollmentResult)taskResult.Result;
                if (enrollmentResult.engineStatus == NffvStatus.TemplateCreated)
                {
                    NffvUser engineUser = enrollmentResult.engineUser;

                    var bm = engineUser.GetBitmap();
                    pic.Image = bm;
                }
                else
                {
                    NffvStatus engineStatus = enrollmentResult.engineStatus;
                    MessageBox.Show(string.Format("Enrollment was not finished. Reason: {0}", engineStatus));
                }
            }
            catch (Exception ex)
            {
                if (_engine != null)
                {
                    _engine.Dispose();
                    _engine = null;
                }
                MessageBox.Show("เครื่องสแกนนิ้วยังไม่พร้อมใช้งาน กรณาลองอีกครั้ง \r\n\n " + ex.Message);// MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_engine != null)
                {
                    _engine.Dispose();
                    _engine = null;
                }
            }
        }
        private void ClearFingerdatabase()
        {
            if (_engine != null)
            {
                _engine.Users.Clear();

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

        private void btn_L_1_Click(object sender, EventArgs e)
        {
            StartScan(l_finger_1);
        }

        private void btn_L_2_Click(object sender, EventArgs e)
        {
            StartScan(l_finger_2);
        }

        private void btn_L_3_Click(object sender, EventArgs e)
        {
            StartScan(l_finger_3);
        }

        private void btn_L_4_Click(object sender, EventArgs e)
        {
            StartScan(l_finger_4);
        }

        private void btn_L_5_Click(object sender, EventArgs e)
        {
            StartScan(l_finger_5);
        }

        private void btn_R_1_Click(object sender, EventArgs e)
        {
            StartScan(R_finger_1);
        }

        private void btn_R_2_Click(object sender, EventArgs e)
        {
            StartScan(R_finger_2);
        }

        private void btn_R_3_Click(object sender, EventArgs e)
        {
            StartScan(R_finger_3);
        }

        private void btn_R_4_Click(object sender, EventArgs e)
        {
            StartScan(R_finger_4);
        }

        private void btn_R_5_Click(object sender, EventArgs e)
        {
            StartScan(R_finger_5);
        }

        #region picture click
        /// <summary>
        ///  Left Hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void l_finger_1_Click(object sender, EventArgs e)
        {
            StartScan(l_finger_1);
        }

        private void l_finger_2_Click(object sender, EventArgs e)
        {
            StartScan(l_finger_2);
        }

        private void l_finger_3_Click(object sender, EventArgs e)
        {
            StartScan(l_finger_3);
        }

        private void l_finger_4_Click(object sender, EventArgs e)
        {
            StartScan(l_finger_4);
        }

        private void l_finger_5_Click(object sender, EventArgs e)
        {
            StartScan(l_finger_5);
        }

        /// <summary>
        /// Right Hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void R_finger_1_Click(object sender, EventArgs e)
        {
            StartScan(R_finger_1);
        }

        private void R_finger_2_Click(object sender, EventArgs e)
        {
            StartScan(R_finger_2);
        }

        private void R_finger_3_Click(object sender, EventArgs e)
        {
            StartScan(R_finger_3);
        }

        private void R_finger_4_Click(object sender, EventArgs e)
        {
            StartScan(R_finger_4);
        }

        private void R_finger_5_Click(object sender, EventArgs e)
        {
            StartScan(R_finger_5);
        }
        #endregion

        private void chk_manual_hospital_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_manual_hospital.Checked)
            {
                chk_have_sso.Checked = false;
                chk_nothave_sso.Checked = false;
                txt_sso_manual_hospital.Enabled = true;
            }
            else
            { chk_have_sso.Checked = true; }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var from = new PersonalForm();

            from.Show();
            Hide();
        }
        #endregion

        private void ribbonButton21_Click(object sender, EventArgs e)
        {
            Hide();
            this.Cursor = Cursors.WaitCursor;
            var frm = new PersonalForm();
            frm.Show();
        }

        private void cbo_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_status.SelectedIndex == 1)
            {
                this.initialSubEmpStatus();
                cbo_substatus.Enabled = true;
                cbo_status.ForeColor = Color.Red;
                cbo_substatus.ForeColor = Color.Red;
            }
            else
            {
                cbo_status.ForeColor = Color.Black;
                cbo_substatus.Items.Clear();
                txt_reason.Text = "";
                txt_reason.Enabled = false;
                cbo_substatus.Enabled = false;
                cbo_substatus.ForeColor = Color.Black;
            }
        }

        private void cbo_substatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_substatus.SelectedIndex == 2)
            {
                txt_reason.Enabled = true;
                txt_reason.ForeColor = Color.Red;
            }
            else
            {
                txt_reason.Enabled = false;
                txt_reason.ForeColor = Color.Black;
            }
        }

        #region == checkbox รายการเบิก ===
        private void chk_1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_1.Checked)
            {
                txt_eq_1.Enabled = true;

            }
            else
            {
                txt_eq_1.Enabled = false;
                txt_eq_1.Text = "";
            }
        }

        private void chk_2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_2.Checked)
            {
                txt_eq_2.Enabled = true;
            }
            else
            {
                txt_eq_2.Enabled = false;
                txt_eq_2.Text = "";
            }
        }

        private void chk_3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_3.Checked)
            {
                txt_eq_3.Enabled = true;
            }
            else
            {
                txt_eq_3.Enabled = false;
                txt_eq_3.Text = "";
            }
        }

        private void chk_4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_4.Checked)
            {
                txt_eq_4.Enabled = true;
            }
            else
            {
                txt_eq_4.Enabled = false;
                txt_eq_5.Text = "";
            }
        }

        private void chk_5_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_5.Checked)
            {
                txt_eq_5.Enabled = true;
            }
            else
            {
                txt_eq_5.Enabled = false;
                txt_eq_6.Text = "";
            }
        }

        private void chk_6_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_6.Checked)
            {
                txt_eq_6.Enabled = true;
            }
            else
            {
                txt_eq_6.Enabled = false;
                txt_eq_6.Text = "";
            }
        }

        private void chk_7_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_7.Checked)
            {
                txt_eq_7.Enabled = true;
            }
            else
            {
                txt_eq_7.Enabled = false;
                txt_eq_7.Text = "";
            }
        }
        #endregion

        #region ===== รายการหัก ======

        private void CalTotal()
        {
            try
            {
                var result1 = 0; var result2 = 0; var result3 = 0; var result4 = 0; var result5 = 0; var result6 = 0; var result7 = 0;
                var no_1 = Int32.TryParse(txt_eq_1.Text, out result1);
                var no_2 = Int32.TryParse(txt_eq_2.Text, out result2);
                var no_3 = Int32.TryParse(txt_eq_3.Text, out result3);
                var no_4 = Int32.TryParse(txt_eq_4.Text, out result4);
                var no_5 = Int32.TryParse(txt_eq_5.Text, out result5);
                var no_6 = Int32.TryParse(txt_eq_6.Text, out result6);
                var no_7 = Int32.TryParse(txt_eq_7.Text, out result7);
                //var deduc = 0; var deductotal = 0;
                //if (int.TryParse(txt_deduc1.Text,out deduc))
                //{
                //    deductotal = deduc;
                //}
                //if (int.TryParse(txt_deduc2.Text, out deduc))
                //{
                //    deductotal = deductotal + deduc;
                //}
                //if (int.TryParse(txt_deduc3.Text, out deduc))
                //{
                //    deductotal = deductotal + deduc;
                //}
                //if (int.TryParse(txt_deduc4.Text, out deduc))
                //{
                //    deductotal = deductotal + deduc;
                //}
                //if (int.TryParse(txt_deduc5.Text, out deduc))
                //{
                //    deductotal = deductotal + deduc;
                //}
                //if (int.TryParse(txt_deduc6.Text, out deduc))
                //{
                //    deductotal = deductotal + deduc;
                //}
                var grandtotal = (result1 + result2 + result3 + result4 + result5 + result6 + result7);
                txt_total.Text = grandtotal.ToString();
            }
            catch (Exception ex)
            {

            }

        }
        private void txt_eq_1_TextChanged(object sender, EventArgs e)
        {
            CalTotal();
        }

        private void txt_eq_2_TextChanged(object sender, EventArgs e)
        {
            CalTotal();
        }

        private void txt_eq_3_TextChanged(object sender, EventArgs e)
        {
            CalTotal();
        }

        private void txt_eq_4_TextChanged(object sender, EventArgs e)
        {
            CalTotal();
        }

        private void txt_eq_5_TextChanged(object sender, EventArgs e)
        {
            CalTotal();
        }

        private void txt_eq_6_TextChanged(object sender, EventArgs e)
        {
            CalTotal();
        }

        private void txt_eq_7_TextChanged(object sender, EventArgs e)
        {
            CalTotal();
        }

        private void txt_deduc1_TextChanged(object sender, EventArgs e)
        {
            CalTotal();
        }

        private void txt_deduc2_TextChanged(object sender, EventArgs e)
        {
            CalTotal();
        }

        private void txt_deduc3_TextChanged(object sender, EventArgs e)
        {
            CalTotal();
        }

        private void txt_deduc4_TextChanged(object sender, EventArgs e)
        {
            CalTotal();
        }

        private void txt_deduc5_TextChanged(object sender, EventArgs e)
        {
            CalTotal();
        }

        private void txt_deduc6_TextChanged(object sender, EventArgs e)
        {
            CalTotal();
        }

        private void CalDeduction()
        {
            var tot = 0;
            if (int.TryParse(txt_total.Text, out tot))
            {
                var listdeduc = tot / 500;
                for (int i = 0; i < listdeduc; i++)
                {
                    if (i == 0)
                    {
                        lbd1.Text = "หักครั้งที่ 1 : 500 บาท";
                    }
                    if (i == 1)
                    {
                        lbd2.Text = "หักครั้งที่ 2 : 500 บาท";
                    }
                    if (i == 2)
                    {
                        lbd3.Text = "หักครั้งที่ 3 : 500 บาท";
                    }
                    if (i == 3)
                    {
                        lbd4.Text = "หักครั้งที่ 4 : 500 บาท";
                    }
                    if (i == 4)
                    {
                        lbd5.Text = "หักครั้งที่ 5 : 500 บาท";
                    }
                    if (i == 5)
                    {
                        lbd6.Text = "หักครั้งที่ 6 : 500 บาท";
                    }
                    if (i == 6)
                    {
                        lbd7.Text = "หักครั้งที่ 7 : 500 บาท";
                    }
                    if (i == 7)
                    {
                        lbd8.Text = "หักครั้งที่ 8 : 500 บาท";
                    }
                }
                var x = tot % 500;
                listdeduc = listdeduc + 1;
                if (listdeduc == 1)
                {
                    lbd1.Text = "หักครั้งที่ 1 : " + x.ToString() + " บาท";
                }
                if (listdeduc == 2)
                {
                    lbd2.Text = "หักครั้งที่ 2 : " + x.ToString() + " บาท";
                }
                if (listdeduc == 3)
                {
                    lbd3.Text = "หักครั้งที่ 3 : " + x.ToString() + " บาท";
                }
                if (listdeduc == 4)
                {
                    lbd4.Text = "หักครั้งที่ 4 : " + x.ToString() + " บาท";
                }
                if (listdeduc == 5)
                {
                    lbd5.Text = "หักครั้งที่ 5 : " + x.ToString() + " บาท";
                }
                if (listdeduc == 6)
                {
                    lbd6.Text = "หักครั้งที่ 6 : " + x.ToString() + " บาท";
                }
                if (listdeduc == 7)
                {
                    lbd7.Text = "หักครั้งที่ 7 : " + x.ToString() + " บาท";
                }
                if (listdeduc == 8)
                {
                    lbd8.Text = "หักครั้งที่ 8 : " + x.ToString() + " บาท";
                }
            }
        }

        private void cal_deduc_Click(object sender, EventArgs e)
        {
            var tot = 0;
            if (int.TryParse(txt_total.Text, out tot))
            {
                var listdeduc = tot / 500;
                for (int i = 0; i < listdeduc; i++)
                {
                    if (i == 0)
                    {
                        lbd1.Text = "หักครั้งที่ 1 : 500 บาท";
                    }
                    if (i == 1)
                    {
                        lbd2.Text = "หักครั้งที่ 2 : 500 บาท";
                    }
                    if (i == 2)
                    {
                        lbd3.Text = "หักครั้งที่ 3 : 500 บาท";
                    }
                    if (i == 3)
                    {
                        lbd4.Text = "หักครั้งที่ 4 : 500 บาท";
                    }
                    if (i == 4)
                    {
                        lbd5.Text = "หักครั้งที่ 5 : 500 บาท";
                    }
                    if (i == 5)
                    {
                        lbd6.Text = "หักครั้งที่ 6 : 500 บาท";
                    }
                    if (i == 6)
                    {
                        lbd7.Text = "หักครั้งที่ 7 : 500 บาท";
                    }
                    if (i == 7)
                    {
                        lbd8.Text = "หักครั้งที่ 8 : 500 บาท";
                    }
                }

                var x = tot % 500;
                listdeduc = listdeduc + 1;
                if (listdeduc == 1)
                {
                    lbd1.Text = "หักครั้งที่ 1 : " + x.ToString() + " บาท";
                }
                if (listdeduc == 2)
                {
                    lbd2.Text = "หักครั้งที่ 2 : " + x.ToString() + " บาท";
                }
                if (listdeduc == 3)
                {
                    lbd3.Text = "หักครั้งที่ 3 : " + x.ToString() + " บาท";
                }
                if (listdeduc == 4)
                {
                    lbd4.Text = "หักครั้งที่ 4 : " + x.ToString() + " บาท";
                }
                if (listdeduc == 5)
                {
                    lbd5.Text = "หักครั้งที่ 5 : " + x.ToString() + " บาท";
                }
                if (listdeduc == 6)
                {
                    lbd6.Text = "หักครั้งที่ 6 : " + x.ToString() + " บาท";
                }
                if (listdeduc == 7)
                {
                    lbd7.Text = "หักครั้งที่ 7 : " + x.ToString() + " บาท";
                }
                if (listdeduc == 8)
                {
                    lbd8.Text = "หักครั้งที่ 8 : " + x.ToString() + " บาท";
                }
            }
        }








        #endregion
         
    }
}
