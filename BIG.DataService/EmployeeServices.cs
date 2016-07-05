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
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    var emp = ctx.Employees.Where(x => x.EMP_ID == employee.EMP_ID).FirstOrDefault();
                    if (emp != null)
                    {
                        emp.TITLE_ID =employee.TITLE_ID;
                        emp.FIRSTNAME_TH = employee.FIRSTNAME_TH;
                        emp.LASTNAME_TH =  employee.LASTNAME_TH;
                        emp.FIRSTNAME_EN = employee.FIRSTNAME_EN;
                        emp.LASTNAME_EN = employee.LASTNAME_EN;
                        emp.NICKNAME_TH = employee.LASTNAME_TH;
                        emp.NICKNAME_EN = employee.NICKNAME_EN;
                        emp.DATEOFBIRTH = employee.DATEOFBIRTH;
                        emp.BIRTH_PLACE_PROVINCE = employee.BIRTH_PLACE_PROVINCE;
                        emp.BIRTH_PLACE_CONTRY = employee.BIRTH_PLACE_CONTRY;
                        emp.DATESTARTWORK = employee.DATESTARTWORK;
                        emp.MOBILE = employee.MOBILE;
                        emp.HOMEPHONE = employee.HOMEPHONE;
                        emp.MODIFIED_DATE = DateTime.Now; 
                        emp.GENDER_ID = employee.GENDER_ID;
                        emp.HEIGHT = employee.HEIGHT;
                        emp.WEIGHT = employee.WEIGHT;
                        emp.RACE = employee.RACE;
                        emp.NATIONALITY = employee.NATIONALITY;
                        emp.RELEGION = employee.RELEGION;
                    }
                    ctx.SaveChanges();
                }
                return true;
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
