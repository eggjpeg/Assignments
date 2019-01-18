using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10
{
    class Util
    {
        public static bool IsDouble(char str)
        {
            return IsDouble(str.ToString());
        }

        public static bool IsDouble(string str)
        {
            return double.TryParse(str.ToString(), out double spaz);
        }
    }
}
