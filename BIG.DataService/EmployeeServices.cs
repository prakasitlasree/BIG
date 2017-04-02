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
                    result = ctx.Employees.Take(200).OrderByDescending(o => o.EMP_ID).ToList();

                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Employee> GetBySite(string site)
        {
            var result = new List<Employee>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Employees.Where(x=> x.SITE_LOCATION.Contains(site)).Take(50).ToList();

                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Employee> GetByArea(string area)
        {
            var result = new List<Employee>();
            try 
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Employees.Where(x => x.AREA.Contains(area)).Take(50).ToList(); 
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Employee> GetByStartDate(DateTime date)
        {
            var result = new List<Employee>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    var dt = new DateTime(date.Year, date.Month, date.Day);
                    result = ctx.Employees.Where(x => x.DATESTARTWORK == dt).Take(50).ToList();
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

        public static Employee GetEmployeeByEmpID(string empid)
        {
            var result = new Employee();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Employees.Where(x => x.EMP_ID == empid).FirstOrDefault();
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
                    employee.MODIFIED_DATE = DateTime.Now;
                    ctx.Employees.Add(employee);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                //return false;
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
                    var tempemp = "BIGS" + DateTime.Now.ToString("yyMMdd");
                    var empctx = ctx.Employees.Where(x => x.EMP_ID.Contains(tempemp)).ToList();
                    if (empctx != null)
                    {
                        var obj = empctx.OrderBy(x => x.EMP_ID).LastOrDefault();
                        if (obj != null)
                        {
                            emp_id = obj.EMP_ID; 
                        }
                       // emp_id = empctx.EMP_ID; 
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
