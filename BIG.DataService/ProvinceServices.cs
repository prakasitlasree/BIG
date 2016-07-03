using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIG.Model;
using BIG.DataAccess;

namespace BIG.DataService
{
  public static  class ProvinceServices
    {
      public static List<Province> GetListProvince()
        {
            var result = new List<Province>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Provinces.ToList();
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
