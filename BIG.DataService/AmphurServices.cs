using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{
    
    public static class AmphurServices
    {
        public static List<Amphur> GetListAmphur()
        { 
            var result = new List<Amphur>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    var lst = ctx.Amphurs.ToList();
                    foreach (var item in lst)
                    {
                        item.AMPHUR_NAME.Replace("   ", "");
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

        public static List<Amphur> GetListAmphur(int province_id)
        {
            var result = new List<Amphur>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Amphurs.Where(x => x.PROVINCE_ID == province_id).ToList();

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
