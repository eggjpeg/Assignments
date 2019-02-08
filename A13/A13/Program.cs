using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace A13
{
    class Program
    {
        static void Main(string[] args)
        {
           // bool b = IsPalindrome("spaz");
           // var list = new List<int> { 1, 7, 3, 9, 12 };
            var res = ThrowDice(100000);
            Console.ReadLine();
        }
        static void PrintList(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);
        }
       static bool IsPalindrome(string s)
        {
            return s.SequenceEqual(s.Reverse());
        }
        static List<int> RetardedSort(List<int> n)
        {
            int l = n.Count;
            var r = new List<int>();
            for (int i = 0; i < l; i++)
            {
                int smallest = FindSmallest(n);
                r.Add(n[smallest]);
                n.Remove(n[smallest]);
            }
            return r;
        }
        static int FindSmallest(List<int> n)
        {
            int smallest = n.Min();
           return n.IndexOf(smallest);
        }
        static Dictionary<int, int> ThrowDice(int n)
        {
            var d = new Dictionary<int,int> ();
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                int dice1 = r.Next(1, 7);
                int dice2 = r.Next(1, 7);
                int sum = dice1 + dice2;
                if (d.ContainsKey(sum))
                    d[sum]++;
                else
                    d.Add(sum, 1);
            }
            PrintFreq(d);
            return d;
        }
       static void PrintFreq(Dictionary<int, int> d)
        {
            int total = 0;
            foreach (KeyValuePair<int, int> entry in d)
                total += entry.Value;
            foreach (KeyValuePair<int, int> entry in d)
                Console.WriteLine(entry.Key + ", " + entry.Value * 100 / total + "% This means that the sum "  + entry.Key + " came up " + entry.Value * 100 / total + " % of the time"); 

        }
    }
}
