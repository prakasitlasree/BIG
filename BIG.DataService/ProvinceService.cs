using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{
    public static class  ProvinceService
    {
        public static List<Province> GetAll()
        {
            var result = new List<Province>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    var lst = ctx.Provinces.ToList();
                    foreach (var item in lst)
                    {
                        //item..Replace("   ", "");
                        result.Add(item);
                    }
                }
                
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }

        public static int GetProvinceIDbyName(string name)
        {
            var result = 0;
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Provinces.Where(x => x.PROVINCE_NAME.Contains(name)).Select(r => r.PROVINCE_ID).FirstOrDefault();
                } 
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }
    }
}
