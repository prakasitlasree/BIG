using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{
    public partial class WorkExperienceServices
    {
        public static bool Add(List<WorkExperience> list)
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
                        ctx.WorkExperiences.Add(objAdd);
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

        public static List<WorkExperience> GetAll()
        {
            var result = new List<WorkExperience>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    result = ctx.WorkExperiences.ToList();


                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<WorkExperience> GetByEmployeeID(string emp)
        {
            var result = new List<WorkExperience>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.WorkExperiences.Where(x => x.EMP_ID == emp).ToList();

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

                    var obj = ctx.WorkExperiences.Where(x => x.EMP_ID == emp_id).FirstOrDefault();
                    if (obj != null)
                    {
                        ctx.WorkExperiences.Remove(obj);
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
