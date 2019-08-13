using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace RBT
{
    class Program
    {
        static void Main(string[] args)
        {
            RBT tree = new RBT();
            Node r = new Node(0);
            r.Colour = Colour.Black;
            var list = GenerateRandomList();
            for (int i = 1; i < list.Count; i++)
            {
                tree.Insert(r, list[i]);
            }
            r.PrintPretty(" ", true, 0);
            Console.ReadLine();
        }

        static List<int> GenerateRandomList()
        {
            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100); //since the random int generated depends on the time, slowing it down will make sure they are all different nums
                Random r = new Random();
                list.Add(r.Next(1, 1000));
            }
            return list;
        }
    }
}