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

    }
}
