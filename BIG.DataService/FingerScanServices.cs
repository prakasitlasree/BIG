using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;

namespace BIG.DataService
{
    
    public partial class FingerScanServices
    {
        public static bool Add(List<FingerScan> list)
        {
            try
            {
                var obj = list.FirstOrDefault();
                if (obj != null)
                {
                    DeleteByEmployeeID(obj.EMP_ID);
                }
                using (var ctx = new BIG_DBEntities())
                {
                    foreach (var objAdd in list)
                    {
                        ctx.FingerScans.Add(objAdd);
                    }
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public static List<FingerScan> GetAll()
        {
            var result = new List<FingerScan>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    result = ctx.FingerScans.ToList();
                     
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<FingerScan> GetByEmployeeID(string emp)
        {
            var result = new List<FingerScan>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.FingerScans.Where(x => x.EMP_ID == emp).ToList();

                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static FingerScan  GetObjByEmployeeID(string emp)
        {
            var result = new  FingerScan();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.FingerScans.Where(x => x.EMP_ID == emp).FirstOrDefault();

                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteByEmployeeID(string emp_id)
        {
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    var list = ctx.FingerScans.Where(x => x.EMP_ID == emp_id).ToList();
                    foreach (var obj in list)
                    {
                        if (obj != null)
                        {
                            ctx.FingerScans.Remove(obj);
                        }
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
