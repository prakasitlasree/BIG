using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{
    public static class ProfileImageDataService
    {
        public static bool UploadPhoto(Emp_Images Photo)
        {
            var result = false;
            try
            { 
                using (var ctx = new BIG_DBEntities())
                {

                    ctx.Emp_Images.Add(Photo);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public static bool DeletePhoto(Emp_Images Photo)
        {
            var result = false;
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    var pho = ctx.Emp_Images.Where(x => x.EMP_ID == Photo.EMP_ID).FirstOrDefault();
                    if (pho != null)
                    {
                        ctx.Emp_Images.Remove(pho);
                    }
                    ctx.SaveChanges();
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
