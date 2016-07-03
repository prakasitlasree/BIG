using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{
    public partial class TrainingServices
    {
        public static bool SaveTraining(List<Training> list)
        { 
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    foreach (var objAdd in list)
                    {
                        ctx.Trainings.Add(objAdd);
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

        public static List<Training> GetAll()
        {
            var result = new List<Training>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    result = ctx.Trainings.ToList();


                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Training> GetByEmployeeID(string emp)
        {
            var result = new List<Training>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Trainings.Where(x => x.EMP_ID == emp).ToList();

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
