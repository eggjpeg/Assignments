using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetTwins(15));
            Console.ReadLine();
        }
        static bool IsPrime(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        static List<int> GetPrimes(int n)
        {
            var list = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                if (IsPrime(i) == true)
                    list.Add(i);
            }
            return list;
        }
        static List<Tuple<int,int>> GetTwins(int n)
        {
            List<int> list = GetPrimes(n);
            var lst = new List<Tuple<int, int>>();
            for (int i = 0; i <= list.Count - 2; i++)
            {
                if (list[i+1] - list[i] == 2)
                    lst.Add(Tuple.Create(list[i], list[i + 1]));
            }
            return lst;
        }

    }
}
