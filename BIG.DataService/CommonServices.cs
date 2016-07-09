using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{ 
    public partial class CommonServices
    { 
        public static string GetTitleNameByID(int? title_id)
        {
            var result = "";
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    var obj = ctx.Titles.Where(x => x.ID == title_id).FirstOrDefault();
                    if (obj != null)
                    {
                       result = obj.NAME;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Title> GetTitleList(string en_or_th) 
        {
            var result = new List<Title>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    result = ctx.Titles.Where(x => x.DESCRIPTION == en_or_th).ToList();
                     
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> GetProvinceHospitalList()
        {
            var result = new List<string>();
            try  
            {
                using (var ctx = new BIG_DBEntities())
                {

                    var list = ctx.Hospitals.ToList();

                    var provincelist = list.GroupBy(x => x.PROVINCE)
                    .Select(grp => grp.First())
                    .ToList();

                    foreach (var item in provincelist)
                    {
                        result.Add(item.PROVINCE);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> GetHospitalByProvinceName(string prov)
        {
            var result = new List<string>();
            try
            { 
                using (var ctx = new BIG_DBEntities())
                {

                    var list = ctx.Hospitals.Where(x=> x.PROVINCE == prov).ToList();
                     
                    foreach (var item in list)
                    {
                        result.Add("โรงพยาบาล" + item.NAME);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
