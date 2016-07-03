using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;

namespace BIG.DataService
{
    public static class SitesDataService
    {
        public static List<Site> GetListSiteLocation()
        {
            var result = new List<Site>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Sites.ToList();

                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public static bool SaveSites(Site obj)
        {
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    if (obj != null)
                    {
                        ctx.Sites.Add(obj); 
                        ctx.SaveChanges();
                    }

                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
