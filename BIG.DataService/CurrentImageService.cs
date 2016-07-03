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

        public static bool DeletePhoto(CurrentImage Img)
        {
            var result = false;
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    var pho = ctx.CurrentImages.Where(x => x.EMP_ID == Img.EMP_ID).FirstOrDefault();
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

            return result;
        }

    }
}
