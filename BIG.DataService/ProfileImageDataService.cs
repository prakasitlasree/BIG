﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{
    public static class ProfileImageDataService
    {
        public static bool UploadPhoto(EmployeeImage Photo)
        {
            var result = false;
            try
            { 
                using (var ctx = new BIG_DBEntities())
                {

                    ctx.EmployeeImages.Add(Photo); 
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public static bool DeletePhoto(EmployeeImage Img)
        {
            var result = false; 
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    var pho = ctx.EmployeeImages.Where(x => x.EMP_ID == Img.EMP_ID).FirstOrDefault();
                    if (pho != null)
                    {
                        ctx.EmployeeImages.Remove(pho);
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
