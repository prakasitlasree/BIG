using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{
    public static class DeductionService
    {
        public static bool Add(List<Deduction> listDeduc)
        {
            try
            { 
                foreach (var objDel in listDeduc)
                {
                    DeleteByEmployeeID(objDel.EMP_ID, objDel.PRICE);
                }
                using (var ctx = new BIG_DBEntities())
                {
                    foreach (var objAdd in listDeduc)
                    { 
                        ctx.Deductions.Add(objAdd);
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

        public static List<Deduction> GetAll()
        {
            var result = new List<Deduction>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Deductions.ToList();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Deduction> GetByEmployeeID(string emp)
        {
            var result = new List<Deduction>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Deductions.Where(x => x.EMP_ID == emp).ToList(); 

                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteByEmployeeID(string emp_id,int? PRICE)
        {
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    var list = ctx.Deductions.Where(x => x.EMP_ID == emp_id && x.PRICE != PRICE).ToList();
                    foreach (var obj in list) 
                    {
                        if (obj != null)
                        {
                            ctx.Deductions.Remove(obj);
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
