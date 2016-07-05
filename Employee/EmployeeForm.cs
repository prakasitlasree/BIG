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
            get { return _otherdoc; }
            set { _otherdoc = value; }
        }

        private List<ReferenceDocument> _refdoc;

        public List<ReferenceDocument> RefDoc 
        {
            get { return _refdoc; }
            set { _refdoc = value; }
        }

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
            var listprov = ProvinceServices.GetListProvince();

            ListProvinces = listprov;

            var prov1 = listprov.Select(x => new { x.PROVINCE_ID, x.PROVINCE_NAME }).ToList();

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
                emp = new BIG.Model.Employee();
                emp.EMP_ID = txt_empid.Text; //รหัสพนักงาน
                emp.ID_CARD = txt_pid.Text; // บัตรประชาชน
                emp.TITLE_ID = Convert.ToInt32(cbo_title_th.SelectedIndex + 1); //คำนำหน้า

                emp.FIRSTNAME_TH = txt_emp_fname_th.Text; //ชื่อไทย
                emp.LASTNAME_TH = txt_emp_lname_th.Text; //นามสกุลไทย
                emp.FIRSTNAME_EN = txt_emp_fname_en.Text; //ชื่ออังกฤษ
                emp.LASTNAME_EN = txt_emp_lname_en.Text; //นามสกุลอังกฤษ
                emp.NICKNAME_TH = txt_nick_th.Text; //ชื่อเล่น

                emp.POSITION_ID = Convert.ToInt16(cbo_possition.SelectedValue.ToString()); //ตำแหน่ง
                emp.DATEOFBIRTH = Convert.ToDateTime(dob.Text);//ว ด ป เกิด
                emp.DATESTARTWORK = Convert.ToDateTime(date_start_work.Text);//ว ด ป เริ่มงาน

                emp.BIRTH_PLACE_PROVINCE = cbo_bp_prov.SelectedValue.ToString(); //จังหวัดที่เกิด
                emp.BIRTH_PLACE_CONTRY = cbo_bp_ctr.SelectedItem.ToString(); //ปรเเทศ เกิด 
                emp.GENDER_ID = Convert.ToInt32(cbo_sex.SelectedIndex + 1); //เพศ
                emp.HEIGHT = Convert.ToInt32(txt_height.Text); //สูง
                emp.WEIGHT = Convert.ToInt32(txt_weight.Text); //น้ำหนัก
                emp.RACE = cbo_race.SelectedItem.ToString(); //เชื้อชาติ
                emp.NATIONALITY = cbo_nationality.SelectedItem.ToString();//สัญชาติ
                emp.RELEGION = cbo_relegion.SelectedItem.ToString(); //ศาสนา
                //emp.MARITAL_ID = 1; //สถานะสมรส 

                return emp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("getEmployeefrominput" + ex.Message);
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
                    current_addr.NAME = c_txt_no.Text + " " + c_txt_soi.Text + " " + c_txt_rd.Text + " " + c_txt_tumbol.Text + " ";
                    current_addr.AMPHUR_ID = c_cbo_amp.SelectedValue.ToString();
                    current_addr.PROVINCE_ID = c_cbo_prov.SelectedValue.ToString();
                    current_addr.POSTCODE = c_txt_postcode.Text;
                    current_addr.ADDRESSTYPE_ID = Convert.ToInt16(c_add_type.SelectedValue.ToString());

                    listAddress.Add(current_addr);
                }


                if (p_txt_no.Text != "" && txt_empid.Text != "")
                {
                    //Permanent Address
                    var permanent_addr = new BIG.Model.Address();

                    permanent_addr.EMP_ID = txt_empid.Text;
                    permanent_addr.NAME = p_txt_no.Text + " " + p_txt_soi.Text + " " + p_txt_road.Text + " " + p_txt_tumbol.Text + " ";
                    permanent_addr.AMPHUR_ID = p_cbo_amp.SelectedValue.ToString();
                    permanent_addr.PROVINCE_ID = p_cbo_prov.SelectedValue.ToString();
                    permanent_addr.POSTCODE = p_txt_postcode.Text;

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
                    tn.TYPE = "ครั้งที่1";
                    tn.EMP_ID = txt_empid.Text;
                    tn.COURSE = txt_tn_1.Text;
                    tn.DETAILS = txt_tn_dt_1.Text;
                    tn.YEAR = txt_tn_yr_1.Text;
                    lstTrain.Add(tn);
                }
                if (txt_tn_2.Text != "" && txt_empid.Text != "")
                {
                    var tn = new BIG.Model.Training();
                    tn.TYPE = "ครั้งที่2";
                    tn.EMP_ID = txt_empid.Text;
                    tn.COURSE = txt_tn_2.Text;
                    tn.DETAILS = txt_tn_dt_2.Text;
                    tn.YEAR = txt_tn_yr_2.Text;

                    lstTrain.Add(tn);
                }
                if (txt_tn_3.Text != "" && txt_empid.Text != "")
                {
                    var tn = new BIG.Model.Training();
                    tn.TYPE = "ครั้งที่3";
                    tn.EMP_ID = txt_empid.Text;
                    tn.COURSE = txt_tn_3.Text;
                    tn.DETAILS = txt_tn_dt_3.Text;
                    tn.YEAR = txt_tn_yr_3.Text;

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
                    exp.TYPE = "บริษัทล่าสุด";
                    exp.EMP_ID = txt_empid.Text;
                    exp.NAME = txt_exp_comname_1.Text;
                    exp.POSITION = txt_exp_pos1.Text;
                    exp.SALARY = txt_exp_salary_1.Text;
                    exp.PERIOD = txt_exp_period_1.Text;
                    explist.Add(exp);
                }
                if (txt_exp_comname_1.Text != "" && txt_empid.Text != "")
                {
                    var exp = new BIG.Model.WorkExperience();
                    exp.TYPE = "บริษัทที่ 2";
                    exp.EMP_ID = txt_empid.Text;
                    exp.NAME = txt_exp_comname_1.Text;
                    exp.POSITION = txt_exp_pos1.Text;
                    exp.SALARY = txt_exp_salary_1.Text;
                    exp.PERIOD = txt_exp_period_1.Text;

                    explist.Add(exp);
                }
                if (txt_exp_comname_1.Text != "" && txt_empid.Text != "")
                {
                    var exp = new BIG.Model.WorkExperience();
                    exp.TYPE = "บริษัทที่ 3";
                    exp.EMP_ID = txt_empid.Text;
                    exp.NAME = txt_exp_comname_1.Text;
                    exp.POSITION = txt_exp_pos1.Text;
                    exp.SALARY = txt_exp_salary_1.Text;
                    exp.PERIOD = txt_exp_period_1.Text;
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
                if (txt_sso_hospital.Text != "" && txt_empid.Text != "" && (chk_have_sso.Checked == true || chk_nothave_sso.Checked == true))
                {
                    var sso = new BIG.Model.SSO();

                    sso.EMP_ID = txt_empid.Text;
                    if (chk_have_sso.Checked == true)
                    {
                        sso.HOSPITAL_NAME = txt_sso_hospital.Text;
                    }
                    if (chk_nothave_sso.Checked == true)
                    {
                        sso.HOSPITAL_NAME = cbo_sso_hospital.SelectedText;
                    }

                    ssoList.Add(sso);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ssoList;
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
                throw ex;
            }
            return ret;
        }

        private CurrentImage getCurrentPhotoEmployee()
        {
            var ret = new CurrentImage();

            try
            {
                var myBitmap = pic_current.Image;
                ret.EMP_ID = txt_empid.Text;
                ret.PHOTO = ConvertImageToByteArray(myBitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
                ret.TYPE = System.Drawing.Imaging.ImageFormat.Jpeg.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ret;
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

        private Model.Employee GetEmployeeByIDCard(string idcard)
        {
            var ret = new Model.Employee();
            try
            {
                var obj = EmployeeServices.GetEmployeeByIDCard(idcard);
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
            EmployeeServices.Add(emp);
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

        private string GenNewEmployeeID()
        {
            var ret = "";
            try
            {
                var lastemp_id = EmployeeServices.GetLastEmployeeID();
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
                        txt_empid.Text = empObj.EMP_ID;
                        txt_pid.Text = empObj.ID_CARD;
                        cbo_title_th.SelectedItem = idcard.Th_Prefix;
                        cbo_title_en.SelectedItem = idcard.En_Prefix;
                        txt_emp_fname_th.Text = empObj.FIRSTNAME_TH;
                        txt_emp_lname_th.Text = empObj.LASTNAME_TH;
                        txt_emp_fname_en.Text = empObj.FIRSTNAME_EN;
                        txt_emp_lname_en.Text = empObj.LASTNAME_EN;
                        dob.Value = empObj.DATEOFBIRTH.Value;
                        date_start_work.Value = empObj.DATESTARTWORK.Value;
                        cbo_bp_prov.SelectedValue = GetProvinceIDByName(idcard.addrProvince);
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
                        cbo_bp_prov.SelectedValue = GetProvinceIDByName(idcard.addrProvince);


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
                        c_cbo_prov.SelectedValue = GetProvinceIDByName(idcard.addrProvince);
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
                CreateReferenceDoc(RefDoc);

                //Other Documents
                CreateOtherDoc(OtherDoc);

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
        private void rb_save_Click(object sender, EventArgs e)
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

            c_txt_postcode.Focus();
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


        private void chk_have_sso_CheckedChanged(object sender, EventArgs e)
        {
            txt_sso_hospital.Enabled = true;
        }

        private void chk_nothave_sso_CheckedChanged(object sender, EventArgs e)
        {
            cbo_sso_hospital.Enabled = true;
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
                            var obj = new ReferenceDocument();
                            obj.EMP_ID = txt_empid.Text;
                            obj.PHOTO = ConvertImageToByteArray(myThumbnail, System.Drawing.Imaging.ImageFormat.Jpeg);
                            obj.TYPE = "สำเนาบัตรประชาชน";
                            
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
                pic_copy_idcard.Image = null;
            }
        }
        #endregion
         
        #region ===Upload ทะเบียนบ้าน===

        private void btn_upload_copy_home_Click(object sender, EventArgs e)
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
                        pic_copy_home.Image = myThumbnail;
                        if (txt_empid.Text != "")
                        {
                            var obj = new ReferenceDocument();
                            obj.EMP_ID = txt_empid.Text;
                            obj.PHOTO = ConvertImageToByteArray(myThumbnail, System.Drawing.Imaging.ImageFormat.Jpeg);
                            obj.TYPE = "สำเนาทะเบียนบ้าน";

                            RefDoc.Add(obj);
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

        }
        private void btn_delete_copy_home_Click(object sender, EventArgs e)
        {
            var refdoc = RefDoc.Where(x => x.TYPE == "สำเนาบัตรประชาชน").FirstOrDefault();
            if (txt_empid.Text != "" && refdoc != null)
            {
                refdoc.TYPE = "Delete";
                pic_copy_home.Image = null;
            }
        }

        #endregion

        #region ===Upload ใบผ่านทหาร ===

        private void btn_upload_copy_military_Click(object sender, EventArgs e)
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
                        pic_copy_military.Image = myThumbnail; 
                        if (txt_empid.Text != "")
                        {
                            var obj = new ReferenceDocument();
                            obj.EMP_ID = txt_empid.Text;
                            obj.PHOTO = ConvertImageToByteArray(myThumbnail, System.Drawing.Imaging.ImageFormat.Jpeg);
                            obj.TYPE = "สำเนาใบผ่านทหาร";

                            RefDoc.Add(obj);
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

        }

        private void btn_delete_copy_military_Click(object sender, EventArgs e)
        {
            var refdoc = RefDoc.Where(x => x.TYPE == "สำเนาใบผ่านทหาร").FirstOrDefault();
            if (txt_empid.Text != "" && refdoc != null)
            {
                refdoc.TYPE = "Delete";
                pic_copy_military.Image = null;
            }
        }

        #endregion

        #region ===Upload เอกสารแต่งตั้ง ===

        private void btn_upload_promote_Click(object sender, EventArgs e)
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
                        pic_promote.Image = myThumbnail;

                        if (txt_empid.Text != "")
                        {
                            var obj = new OtherDocument();
                            obj.EMP_ID = txt_empid.Text;
                            obj.PHOTO = ConvertImageToByteArray(myThumbnail, System.Drawing.Imaging.ImageFormat.Jpeg);
                            obj.TYPE = "เอกสารแต่งตั้ง";

                            OtherDoc.Add(obj);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("btn_upload_copy_home_Click: " + ex.Message);
                    }
                }
            }
        }

        private void btn_refresh_promote_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_promote_Click(object sender, EventArgs e)
        {
            var refdoc = RefDoc.Where(x => x.TYPE == "เอกสารแต่งตั้ง").FirstOrDefault();
            if (txt_empid.Text != "" && refdoc != null)
            {
                refdoc.TYPE = "Delete";
                pic_promote.Image = null;
            }
        }

        #endregion
         
        #region ===Upload เอกสารเพิ่มเงิน ===
        private void btn_upload_salary_Click(object sender, EventArgs e)
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
                        pic_saraly.Image = myThumbnail;
                        if (txt_empid.Text != "")
                        {
                            var obj = new OtherDocument();
                            obj.EMP_ID = txt_empid.Text;
                            obj.PHOTO = ConvertImageToByteArray(myThumbnail, System.Drawing.Imaging.ImageFormat.Jpeg);
                            obj.TYPE = "เอกสารเพิ่มเงิน";

                            OtherDoc.Add(obj);
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

        }

        private void btn_delete_salary_Click(object sender, EventArgs e)
        {
            var refdoc = RefDoc.Where(x => x.TYPE == "เอกสารแต่งตั้ง").FirstOrDefault();
            if (txt_empid.Text != "" && refdoc != null)
            {
                refdoc.TYPE = "Delete";
                pic_saraly.Image = null;
            }
        }
        #endregion
         
        #region ===Upload ใบเตือน ===
        private void btn_upload_warning_Click(object sender, EventArgs e)
        {
            //pic_warning
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
                        pic_warning.Image = myThumbnail;

                        if (txt_empid.Text != "")
                        {
                            var obj = new OtherDocument();
                            obj.EMP_ID = txt_empid.Text;
                            obj.PHOTO = ConvertImageToByteArray(myThumbnail, System.Drawing.Imaging.ImageFormat.Jpeg);
                            obj.TYPE = "ใบเตือน";

                            OtherDoc.Add(obj);
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

        }

        private void btn_delete_warning_Click(object sender, EventArgs e)
        {
            var refdoc = RefDoc.Where(x => x.TYPE == "ใบเตือน").FirstOrDefault();
            if (txt_empid.Text != "" && refdoc != null)
            {
                refdoc.TYPE = "Delete";
                pic_warning.Image = null;
            }
        }
        #endregion
    }
}
