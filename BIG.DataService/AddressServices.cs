﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{
    public partial class AddressServices
    {
        public static bool Add(List<Address> list)
        {
            try
            {
                var obj = list.FirstOrDefault();
                if (obj != null)
                {
                    DeleteByEmployeeID(obj.EMP_ID);
                }

                using (var ctx = new BIG_DBEntities())
                {
                    foreach (var objAdd in list)
                    {
                        ctx.Addresses.Add(objAdd);

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
         
        public static void DeleteByEmployeeID(string emp_id)
        {
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    var obj = ctx.Addresses.Where(x => x.EMP_ID == emp_id).FirstOrDefault();
                    if (obj != null)
                    {
                        ctx.Addresses.Remove(obj);
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateAddress(List<Address> list)
        {
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    foreach (var objAdd in list)
                    {
                        ctx.Addresses.Add(objAdd);

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

        public static List<AddressType> GetAddressTypeList()
        {
            var result = new List<AddressType>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    result = ctx.AddressTypes.ToList();


                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public static List<Address> GetAll()
        {
            var result = new List<Address>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    result = ctx.Addresses.ToList();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Address> GetByEmployeeID(string emp)
        {
            var result = new List<Address>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {

                    result = ctx.Addresses.Where(x => x.EMP_ID == emp).ToList();
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
