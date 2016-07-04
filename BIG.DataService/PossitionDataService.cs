using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIG.Model;
using BIG.DataAccess;

namespace BIG.DataService
{
  public static  class PossitionDataService
    {

        public static List<Position> GetAll()
        {
            var result = new List<Position>();
            try
            {
                using (var ctx = new BIG_DBEntities())
                {
                    result = ctx.Positions.ToList();

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
