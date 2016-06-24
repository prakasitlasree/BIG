using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;

namespace BIG.DataService
{
    public static class EmployeeServices
    {

        public static List<Employee> GetAll()
        {
            var result = new List<Employee>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Employees.ToList();

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
