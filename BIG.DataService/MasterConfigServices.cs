using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{
    public static   class MasterConfigServices
    {
        public static List<MasterConfig> GetEmployeeStatus()
        { 
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    var list = ctx.MasterConfigs.Where(x => x.NAME == "EMPLOYEE_STATUS").ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
