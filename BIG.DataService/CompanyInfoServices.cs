using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;

namespace BIG.DataService
{
    public partial class CompanyInfoServices
    {
        public static CompanyInfo Get()
        {
            var result = new CompanyInfo();
            try
            {

                using (var ctx = new BIG_DBEntities())
                {

                    var obj = ctx.CompanyInfoes.FirstOrDefault();
                    if (obj != null)
                    {
                        result = obj;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Add(CompanyInfo com)
        {
            var backup = new CompanyInfo();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    backup = ctx.CompanyInfoes.FirstOrDefault();
                }

                Delete();
                using (var ctx = new BIG_DBEntities())
                {
                    var obj = ctx.CompanyInfoes.Add(com);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                using (var ctx = new BIG_DBEntities())
                {
                    ctx.CompanyInfoes.Add(backup);
                    ctx.SaveChanges();
                }
                throw ex;
            }
        }
        public static void Delete()
        {
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    var del = ctx.CompanyInfoes.FirstOrDefault();
                    if (del != null)
                    {
                        ctx.CompanyInfoes.Remove(del);
                        ctx.SaveChanges();
                    } 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
