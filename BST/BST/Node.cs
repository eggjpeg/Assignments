using System;
using System.Collections.Generic;

namespace BST
{
    class Node
    {
        public int value;
        public Node L;
        public Node R;
        public Node(int value)
        {
            this.value = value;
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

            if (L != null)
            {
                Console.Write("L");
                L.PrintPretty(indent, false);
            }
            if (R != null)
            {
                Console.Write("R");
                R.PrintPretty(indent, false);
            }
            if (L == null && R == null)
                return;

        }

        public bool IsLeaf()
        {
            return L == null && R == null;
        }

    }
}
