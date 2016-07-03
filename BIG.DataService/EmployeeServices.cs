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

        public static bool AddEmployee(Employee employee)
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

                    var empctx = ctx.Employees.Where(x => x.EMP_ID == employee.EMP_ID).FirstOrDefault();
                    if (empctx != null)
                    {
                        empctx.TITLE_ID =employee.TITLE_ID;
                        empctx.FIRSTNAME_TH = employee.FIRSTNAME_TH;
                        empctx.LASTNAME_TH =  employee.LASTNAME_TH;
                        empctx.FIRSTNAME_EN = employee.FIRSTNAME_EN;
                        empctx.LASTNAME_EN = employee.LASTNAME_EN;
                        empctx.NICKNAME_TH = employee.LASTNAME_TH;
                        empctx.NICKNAME_EN = employee.NICKNAME_EN;
                        empctx.DATEOFBIRTH = employee.DATEOFBIRTH;
                        empctx.BIRTH_PLACE_PROVINCE = employee.BIRTH_PLACE_PROVINCE;
                        empctx.BIRTH_PLACE_CONTRY = employee.BIRTH_PLACE_CONTRY;
                        empctx.GENDER_ID = employee.GENDER_ID;
                        empctx.HEIGHT = employee.HEIGHT;
                        empctx.WEIGHT = employee.WEIGHT;
                        empctx.RACE = employee.RACE;
                        empctx.NATIONALITY = employee.NATIONALITY;
                        empctx.RELEGION = employee.RELEGION;
                    }
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
                return emp_id;
            }
        }
    }
}
