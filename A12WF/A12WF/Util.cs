using System;
using System.Collections.Generic;

namespace A12WF
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
        public static Tuple<int, int> FindInnerPars(List<object> list, char par1, char par2)
        {
            int i1 = list.LastIndexOf(par1) == -1 ? int.MaxValue : list.LastIndexOf(par1);
            int i2 = list.IndexOf(par2, i1) == -1 ? int.MaxValue : list.IndexOf(par2, i1);
            var tuple = new Tuple<int, int>(i1, i2);
            return tuple;
        }
        public static Tuple<int, int> FindClosestPars(List<object> list, char par1, char par2, int i)
        {
            int i1 = list.IndexOf(par1, i) == -1 ? int.MaxValue : list.IndexOf(par1);
            int i2 = list.IndexOf(par2, i1) == -1 ? int.MaxValue : list.IndexOf(par2, i1);
            var tuple = new Tuple<int, int>(i1, i2);
            return tuple;
        }
        public static void PrintList(List<Tuple<double, double>> list)
        {
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
        }

    }
}
