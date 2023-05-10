using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Common
{
    public class ConversionHelper
    {
        public static int SafeConvertfromStringtoInt(string value)
        {
            int output;
            int.TryParse(value, out output);
            return output;
        }
        
        public static bool SafeConvertfromStringtoBool(string value)
        {
            bool output;
            bool.TryParse(value, out output);
            return output;
        }
        public static DateTime SafeConvertfromStringtoDatetime(string value)
        {
            DateTime output;
            DateTime.TryParse(value, out output);
            return output;
        }
    }
}
