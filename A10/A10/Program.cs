using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10
{
    enum Order
    {
        Power,
        MultDiv
    }
    enum TokenType
    {
        Num,
        Op
    }
    class Program
    {
        static void Main(string[] args)
        {
             double r = Evaluate("(2+1)*2");     
            Console.WriteLine(r);
            Console.ReadLine();
        }


        static List<object> Tokenize(string exp)
        {
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
            
            if (DetermineType(list[0]) == TokenType.Op && (char)list[0] == '-')
            {
                list.RemoveAt(0);
                list[0] = -(double)list[0];
            }


            return list;
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

        static List<object> Evaluate(List<object> list)
        {
            if (list.Count == 1)
                return list;  
            for (int i = 0; i < list.Count; i++)
            {
                    if (list.Contains('^'))
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (DetermineType(list[j]) == TokenType.Op && Convert.ToChar(list[j]) == '^')
                        {
                            double r = Math.Pow((double)list[j - 1], (double)list[j + 1]);
                            Process(list, j, r);
                        }
                    }
                }
                if (DetermineType(list[i]) == TokenType.Op && Convert.ToChar(list[i]) == '*')
                {
                    double r = (double)list[i - 1] * (double)list[i + 1];
                    Process(list, i, r);
                }

                if (DetermineType(list[i]) == TokenType.Op && Convert.ToChar(list[i]) == '/')
                {
                    double r = (double)list[i - 1] / (double)list[i + 1];
                    Process(list, i, r);
                }
            }
            var lstNew = new List<object>();
            double n1 = (double)list[0];
            char op = (char)list[1];
            double n2 = (double)list[2];
            if (op == '+')
                lstNew.Add(n1 + n2);
            else
                lstNew.Add(n1 - n2);
            List<object> lstRemainder = list.GetRange(3, list.Count - 3);
            lstNew.AddRange(lstRemainder);

            return Evaluate(lstNew);
        }

        private static void Process(List<object> list, int i, double r)
        {
            list.RemoveAt(i + 1);
            list.RemoveAt(i - 1);
            list.RemoveAt(i - 1);
            list.Insert(i - 1, r);
        }

        static double Evaluate(string exp)
        {
            List<object> list = Tokenize(exp);
            var rList = Evaluate(list);
            return (double)rList[0];
        }


        static List<object> EvaluateNR(List<object> list)
        {
            while (list.Count > 1)
            {
                var lstNew = new List<object>();
                double n1 = (double)list[0];
                char op = (char)list[1];
                double n2 = (double)list[2];
                if (op == '+')
                    lstNew.Add(n1 + n2);
                else
                    lstNew.Add(n1 - n2);
                List<object> lstRemainder = list.GetRange(3, list.Count - 3);
                lstNew.AddRange(lstRemainder);
                list = lstNew;
            }
            return list;
        }

        static TokenType DetermineType(object obj)
        {
            if (double.TryParse(obj.ToString(), out double spaz))
                return TokenType.Num;
            else
                return TokenType.Op;
        }
    
    }
}
