using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIG.Model;
using BIG.DataAccess;

namespace BIG.DataService
{
   public static class LogOnServices
    {
       public static bool Login( string username,string password)
       {
           var result = false;
           try
           {
               using(var ctx = new BIG_DBEntities())
               {
                   var list = ctx.Logons.Where(x => x.USERNAME == username && x.PASSWORD == password).ToList();
                   if (list.Count() > 0)
                   {
                       result = true;
                   }
                   else
                   { result = false; }
               }
           }
           catch (Exception ex)
           {
               result = false;
                throw ex;
           }
            
           return result;
       }
    }
}
