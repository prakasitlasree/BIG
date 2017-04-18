using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{
    public static class DistrictService
    {
        public static List<District> GetAll()
        {
            var result = new List<District>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    var lst = ctx.Districts.ToList();
                    foreach (var item in lst)
                    {
                        item.DISTRICT_NAME.Replace(" ", "").Replace("*", "");
                        result.Add(item);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public static string GetZipcodeByDistricName(string name)
        {
            var result = "";
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    var districObj = ctx.Districts.Where(x => x.DISTRICT_NAME.Contains(name)).FirstOrDefault();
                    if (districObj != null)
                    {
                        var prov = districObj.PROVINCE_ID.ToString();
                        var aump = districObj.AMPHUR_ID.ToString();
                        var dis = districObj.DISTRICT_ID.ToString();
                        var zipcodeObj = ctx.Zipcodes.Where(o => o.PROVINCE_ID == prov && o.AMPHUR_ID == aump && o.DISTRICT_ID == dis).FirstOrDefault();
                        if (zipcodeObj != null)
                        {
                            result = zipcodeObj.ZIPCODE1.ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static string GetZipcodeByDistricID(string _p_id, string _a_id, string _d_id)
        {
            var result = "";
            try
            {
                using (var ctx = new BIG_DBEntities())
                { 
                    var zipcodeObj = ctx.Zipcodes.Where(o => o.PROVINCE_ID == _p_id && o.AMPHUR_ID == _a_id && o.DISTRICT_ID == _d_id).FirstOrDefault();
                    if (zipcodeObj != null)
                    {
                        result = zipcodeObj.ZIPCODE1.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static List<District> GetDistrictByAmphurID(int province_id, int amphur_id)
        {
            var result = new List<District>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Districts.Where(x => x.PROVINCE_ID == province_id && x.AMPHUR_ID == amphur_id).ToList();

                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
    }
}
