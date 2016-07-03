using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{
    public partial class EducationServices
    {
        public static bool SaveEducation(List<Education> listEdu)
        {
            try
            {
                using (var ctx = new BIG_DBEntities())
                { 
                    foreach (var objAdd in listEdu)
                    {
                        ctx.Educations.Add(objAdd);
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

        public static List<Education> GetAll()
        {
            var result = new List<Education>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    result = ctx.Educations.ToList();


                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Education> GetByEmployeeID(string emp)
        {
            var result = new List<Education>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                { 
                    result = ctx.Educations.Where(x=> x.EMP_ID == emp).ToList();
                     
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
