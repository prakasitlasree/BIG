using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{ 
    public partial class OtherDocumentServices
    {
        public static bool Add(List<OtherDocument> list)
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
                        ctx.OtherDocuments.Add(objAdd);
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

        public static List<OtherDocument> GetAll()
        {
            var result = new List<OtherDocument>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    result = ctx.OtherDocuments.ToList();


                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<OtherDocument> GetByEmployeeID(string emp)
        {
            var result = new List<OtherDocument>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.OtherDocuments.Where(x => x.EMP_ID == emp).ToList();

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

                    var list = ctx.OtherDocuments.Where(x => x.EMP_ID == emp_id).ToList();
                    foreach (var obj in list)
                    {
                        if (obj != null)
                        {
                            ctx.OtherDocuments.Remove(obj);
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
