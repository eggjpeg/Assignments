using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpEval e = new ExpEval();
            //double r = e.Evaluate("cos(4*5)*2+sin(37)-tan(44)");
            //double r = e.Evaluate("log(cos(tan(45*2)))");

            var plotSet = e.Evaluate("x^2+3*x", -10, 10, .5);
            Util.PrintList(plotSet);
            Console.ReadLine();
        }
    }
}
