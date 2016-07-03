using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;
namespace BIG.DataService
{
  public partial  class AddressServices
    {
      public static bool  SaveAddress(List<Address> listAddress)
      {
          try
          {
              using (var ctx = new BIG_DBEntities())
              {
                  foreach (var objAdd in listAddress)
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

                result =  ctx.AddressTypes.ToList();

                   
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

                  result = ctx.Addresses.Where(x=> x.EMP_ID == emp).ToList();
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
