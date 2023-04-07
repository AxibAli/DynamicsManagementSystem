using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Common.Helper
{
    public class ConversionHelper
    {
        public static int ConvertStringtoInt(string str)
        {
            int value;
            Int32.TryParse(str, out value);
            return value;
        }
    }
}
