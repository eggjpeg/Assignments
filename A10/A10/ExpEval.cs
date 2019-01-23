using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10
{
    class ExpEval
    {
         List<object> Tokenize(string exp)
        {
            if (exp[0] == '-')
                exp = '0' + exp;

            StringBuilder sb = new StringBuilder();
            var list = new List<object>();
            for (int i = 0; i < exp.Length; i++)
            {
                if (Util.IsDouble(exp[i]) || exp[i] == '.')
                    sb.Append(exp[i]);
                else
                {
                    AddSb(sb, list);
                    list.Add(exp[i]);
                    sb.Clear();
                }
            }
            AddSb(sb, list);
            return list;
        }

        void Print(List<object> lst)
        {
            foreach (object o in lst)
                Console.Write(o.ToString());
            Console.WriteLine();
        }

        private static void AddSb(StringBuilder sb, List<object> list)
        {
            if (sb.Length == 0)
                return;

            if (Util.IsDouble(sb.ToString()))
                list.Add(double.Parse(sb.ToString()));
            else
                throw new Exception("improper number format, spaz: " + sb.ToString());

        }

        double DoOp(char op, List<object> list, int index)
        {
            double o1 = (double)list[index - 1];
            double o2 = (double)list[index + 1];
            switch (op)
            {
                case '^': return Math.Pow(o1, o2);
                case '*': return o1 * o2;
                case '/': return o1 / o2;
                case '+': return o1 + o2;
                case '-': return o1 - o2;
                default: throw new Exception("Invalid op spaz :" + op);
            }
        }

        List<object> Evaluate(List<object> list)
        {
            if (list.Count == 1)
                return list;
            string[] orderList = {"^,^", "*,/", "+,-" };
            var lst = new List<object>();
            if (list.Contains('('))
            {
                var BiggestIndex = Util.FindInnerPars(list, '(', ')');
                if (BiggestIndex.Item1 > -1 && BiggestIndex.Item1 != int.MaxValue && BiggestIndex.Item2 > -1 && BiggestIndex.Item2 != int.MaxValue)
                {
                        for (int i = 0; i < list.Count; i++)
                        {
                        if (BiggestIndex.Item1 < i && BiggestIndex.Item2 > i)
                            lst.Add(list[i]);
                        }
                    list.RemoveRange(BiggestIndex.Item1, BiggestIndex.Item2 - BiggestIndex.Item1 + 1);
                    var ls = Evaluate(lst);
                    list.InsertRange(BiggestIndex.Item1, ls);
                    return Evaluate(list);
                }
            }
            foreach (string opSet in orderList)
            {
                string[] opAr = opSet.Split(',');
                int SmallestIndex = Util.FindSmallestIndexOf(list, Convert.ToChar(opAr[0]), Convert.ToChar(opAr[1]));  
                if (SmallestIndex > -1 && SmallestIndex != int.MaxValue)
                {
                    double r = DoOp((char)list[SmallestIndex], list, SmallestIndex);
                    Shrink(list, SmallestIndex, r);
                    return Evaluate(list);
                }
            }
            return list;
        }

        private void Shrink(List<object> list, int i, double r)
        {
            list.RemoveAt(i + 1);
            list.RemoveAt(i - 1);
            list.RemoveAt(i - 1);
            list.Insert(i - 1, r);
        }

        public double Evaluate(string exp)
        {
            List<object> list = Tokenize(exp);
            var rList = Evaluate(list);
            return (double)rList[0];
        }
    }
}
