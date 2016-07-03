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
                    var lst = ctx.Provinces.ToList();
                    foreach (var item in lst)
                    {
                        item.PROVINCE_NAME.Replace("   ", "");
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

      public static int GetProvinceIDByName(string province_nm)
      {
          var result = 0;
          try
          {
              using (var ctx = new BIG_DBEntities())
              {
                  var obj = ctx.Provinces.Where(x => x.PROVINCE_NAME == province_nm).FirstOrDefault();
                  if (obj != null)
                  {
                      result = obj.PROVINCE_ID;
                  }
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
