using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTree
{
    class Node
    {
        public string value;
        public List<Node> Children;
        public void AddChild(Node n)
        {
            if (Children == null)
                Children = new List<Node>();
            Children.Add(n);
        }

        public void PrintPretty(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }

            Console.WriteLine(value);

            if (Children == null)
                return;

            for (int i = 0; i < Children.Count; i++)
                Children[i].PrintPretty(indent, i == Children.Count - 1);
        }
    }
}