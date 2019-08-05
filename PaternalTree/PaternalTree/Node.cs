using System;
using System.Collections.Generic;

namespace PaternalTree
{
    public class Node
    {

        public Node parent;
        public List<Node> Children;
        public string value;
        public Node(string value)
        {
            this.value = value;
        }
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