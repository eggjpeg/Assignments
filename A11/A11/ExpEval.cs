using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11
{
    class ExpEval
    {
        //List of functions
        List<string> funcList = new List<string>(new string[] { "sin", "cos", "log", "tan" });


        List<object> Tokenize(string exp)
        {
            if (exp[0] == '-')
                exp = '0' + exp;
            StringBuilder sb = new StringBuilder();
            var list = new List<object>();
            for (int i = 0; i < exp.Length; i++)
            {
                if (AppendFunctions(exp, sb, i))
                {
                    i += 2;
                    continue;
                }
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

        private bool AppendFunctions(string exp, StringBuilder sb, int i)
        {
            foreach (string f in funcList)
            {
                bool isAppend = AppendFunction(f, i, exp, sb);
                if (isAppend)
                    return true;
              }
            return false;
        }

        bool AppendFunction(string name, int i, string exp, StringBuilder sb)
        {
            var lsb = new StringBuilder();
            for (int j = 0; j < name.Length; j++)
                if (i+j < exp.Length)
                lsb.Append(exp[i + j]);
            if (lsb.ToString() == name)
            {
                sb.Append(lsb.ToString());
                return true;
            }
            return false;
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
                list.Add(sb.ToString());
               // throw new Exception("improper number format, spaz: " + sb.ToString());

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

            //Parens
            if (list.Contains('('))
            {
                var lst = new List<object>();
                var biggestIndex = Util.FindInnerPars(list, '(', ')');
                if (biggestIndex.Item1 > -1 && biggestIndex.Item1 != int.MaxValue && biggestIndex.Item2 > -1 && biggestIndex.Item2 != int.MaxValue)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (biggestIndex.Item1 < i && biggestIndex.Item2 > i)
                            lst.Add(list[i]);
                       
                    }
                    list.RemoveRange(biggestIndex.Item1, biggestIndex.Item2 - biggestIndex.Item1 + 1);
                    var ls = Evaluate(lst);
                    list.InsertRange(biggestIndex.Item1, ls);
                    return Evaluate(list);
                }
            }

            
            //Functions
            for (int i = 0; i < list.Count; i++)
            {
                if (funcList.Contains(Convert.ToString(list[i])))
                {
                    EvalFunc(list, i);
                    return Evaluate(list);
                }
            }

            //Regular ops
            string[] orderList = { "^,^", "*,/", "+,-" };
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

        private void EvalFunc(List<object> list, int index)
        {
            string func = Convert.ToString(list[index]);
            double val = Convert.ToDouble(list[index + 1]);
            double angle = Math.PI * val / 180.0;
            double r = 0;

            switch (func)
            {
                case "cos": r = Math.Cos(val); break;
                case "sin": r = Math.Sin(val); break;
                case "tan": r = Math.Tan(val); break;
                case "log": r = Math.Log(val); break;
                default: throw new Exception("Invalid func spaz :" + func);
            }

            list.RemoveRange(index, 2);
            list.Insert(index, r);
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
