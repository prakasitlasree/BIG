//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIG.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int ID { get; set; }
        public string EMP_ID { get; set; }
        public string ID_CARD { get; set; }
        public Nullable<int> TITLE_ID { get; set; }
        public string FIRSTNAME_EN { get; set; }
        public string MIDNAME_EN { get; set; }
        public string LASTNAME_EN { get; set; }
        public string FIRSTNAME_TH { get; set; }
        public string MIDNAME_TH { get; set; }
        public string LASTNAME_TH { get; set; }
        public string NICKNAME_EN { get; set; }
        public string NICKNAME_TH { get; set; }
        public Nullable<int> GENDER_ID { get; set; }
        public Nullable<System.DateTime> DATEOFBIRTH { get; set; }
        public string BIRTH_PLACE_CONTRY { get; set; }
        public string BIRTH_PLACE_PROVINCE_ID { get; set; }
        public Nullable<int> HEIGHT { get; set; }
        public Nullable<int> WEIGHT { get; set; }
        public string RACE { get; set; }
        public string NATIONALITY { get; set; }
        public Nullable<int> POSITION_ID { get; set; }
        public Nullable<int> MARITAL_ID { get; set; }
        public string MOBILE { get; set; }
        public string HOMEPHONE { get; set; }
        public string BLOODGROUP { get; set; }
        public string EMAIL { get; set; }
        public Nullable<bool> STATUS { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }
        public string CREATEBY { get; set; }
        public string MODIFIEDBY { get; set; }
    
        public virtual Gender Gender { get; set; }
        public virtual Marital Marital { get; set; }
        public virtual Position Position { get; set; }
        public virtual Province Province { get; set; }
        public virtual Title Title { get; set; }
    }
}
