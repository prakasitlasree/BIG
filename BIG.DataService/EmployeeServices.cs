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

        public static Employee  GetEmployeeByIDCard(string idcard)
        {
            var result = new  Employee();
            try 
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Employees.Where(x => x.ID_CARD == idcard).FirstOrDefault(); 
                }
                return result; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Add(Employee employee)
        { 
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    ctx.Employees.Add(employee);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public static bool UpdateEmployee(Employee employee)
        {
            var old_emp = GetEmployeeByIDCard(employee.ID_CARD);
            
            try
            { 
                DeleteByEmployeeID(employee.EMP_ID);
                Add(employee);
                 
                return true;
            }
            catch (Exception ex)
            {
                Add(old_emp);
                throw ex;
            }
        }


        public static void DeleteByEmployeeID(string emp_id)
        {
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    var obj = ctx.Employees.Where(x => x.EMP_ID == emp_id).FirstOrDefault();
                    if (obj != null)
                    {
                        ctx.Employees.Remove(obj);
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetLastEmployeeID()
        {
            var emp_id = string.Empty;
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    var empctx = ctx.Employees.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();
                    if (empctx != null)
                    {
                        emp_id = empctx.EMP_ID;
                    } 
                }
                return emp_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
