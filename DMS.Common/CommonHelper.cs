using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Common
{
    public class CommonHelper
    {
        //public static object Mapper(object Source)
        //{
        //    return Omu.ValueInjecter.Mapper.Map<object>(Source);
        //}

        public static decimal PaginationTotalPages(int TotalPages)
        {
            return Math.Ceiling(Convert.ToDecimal(TotalPages / 10.0));
        }
    }
}
