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
    
    public partial class Amphur
    {
        public string ID { get; set; }
        public string NAME_EN { get; set; }
        public string NAME_TH { get; set; }
        public string PROVINCE_ID { get; set; }
    
        public virtual Province Province { get; set; }
    }
}
