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
            double r = e.Evaluate("-4*2^2*2*3/3");     
            Console.WriteLine(r);
            Console.ReadLine();
        }

       
    }
}
