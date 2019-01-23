using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpEval e = new ExpEval();
            double r = e.Evaluate("((2+6)-5)    *(2^3)");     
            Console.WriteLine(r);
            Console.ReadLine();
        }

       
    }
}
