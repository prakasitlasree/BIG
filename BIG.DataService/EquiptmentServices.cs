using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{ 
    public partial class EquiptmentServices
    {
        public static bool Add(List<Equiptment> listEdu)
        {
            try
            {
                var obj = listEdu.FirstOrDefault();
                if (obj != null)
                {
                    DeleteByEmployeeID(obj.EMP_ID);
                }
                using (var ctx = new BIG_DBEntities())
                {
                    foreach (var objAdd in listEdu)
                    {
                        ctx.Equiptments.Add(objAdd);
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

        public static List<Equiptment> GetAll()
        {
            var result = new List<Equiptment>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    result = ctx.Equiptments.ToList();


                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Equiptment> GetByEmployeeID(string emp)
        {
            var result = new List<Equiptment>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Equiptments.Where(x => x.EMP_ID == emp).ToList();

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
                    var list = ctx.Equiptments.Where(x => x.EMP_ID == emp_id).ToList();
                    foreach (var obj in list)
                    {
                        if (obj != null)
                        {
                            ctx.Equiptments.Remove(obj);
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
