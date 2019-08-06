using System;
using System.Collections.Generic;

namespace BST
{
    class Program
    {
        static void Main(string[] args)
        {
            Node r = new Node(0);
            var list = GenerateRandomList(100);
            for (int i = 0; i < list.Count; i++)
                Insert(r, list[i]);
            r.PrintPretty(" ", true);
        }

        static List<int> GenerateRandomList(int n)
        {
            var list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                Random r = new Random();
                list.Add(r.Next(1, 10000));
            }
            return list;
        }
        static void Insert(Node curNode, int n)
        {
            bool IsR = false;
            if(n > curNode.value)
            {
                IsR = true;
                if (curNode.R == null)
                {
                    curNode.R = new Node(n);
                    return;
                }
            }
            else
            {
                if (curNode.L == null)
                {
                    curNode.L = new Node(n);
                    return;
                }
            }
            if (IsR == true)
                Insert(curNode.R, n);
            else
                Insert(curNode.L, n);

        }

    }
}
