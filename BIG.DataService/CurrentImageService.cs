using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{ 
    public static class CurrentImageService
    {
        public static bool UploadPhoto(CurrentImage Photo)
        {
            var result = false;
            try
            {
                if (Photo != null)
                {
                    DeletePhoto(Photo.EMP_ID);
                }

                using (var ctx = new BIG_DBEntities())
                { 
                    ctx.CurrentImages.Add(Photo);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public static void DeletePhoto(string emp_id)
        { 
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    var pho = ctx.CurrentImages.Where(x => x.EMP_ID == emp_id).FirstOrDefault();
                    if (pho != null)
                    {
                        ctx.CurrentImages.Remove(pho);
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        public static CurrentImage GetByEmployeeID(string emp)
        {
            var result = new CurrentImage();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    result = ctx.CurrentImages.Where(x => x.EMP_ID == emp).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

    }
}
