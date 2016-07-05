using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{ 
    public partial class RefDocumentServices
    {
        public static bool Add(List<ReferenceDocument> list)
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
                        ctx.ReferenceDocuments.Add(objAdd);
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

        public static List<ReferenceDocument> GetAll()
        {
            var result = new List<ReferenceDocument>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    result = ctx.ReferenceDocuments.ToList();


                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ReferenceDocument> GetByEmployeeID(string emp)
        {
            var result = new List<ReferenceDocument>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.ReferenceDocuments.Where(x => x.EMP_ID == emp).ToList();

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

                    var list = ctx.ReferenceDocuments.Where(x => x.EMP_ID == emp_id).ToList();
                    foreach (var obj in list)
                    {
                        if (obj != null)
                        {
                            ctx.ReferenceDocuments.Remove(obj);
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
