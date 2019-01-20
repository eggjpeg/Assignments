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


        public static int FindSmallestIndexOf(List<object> list, char op1, char op2)
        {
            int i1 = list.IndexOf(op1) == -1 ? int.MaxValue : list.IndexOf(op1);
            int i2 = list.IndexOf(op2) == -1 ? int.MaxValue : list.IndexOf(op2);

            if (i1 < i2)
                return i1;
            else
                return i2;
        }

    }
}
