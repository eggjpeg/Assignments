using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTree2
{
	class Node
	{
		public string value;
		public Node L;
		public Node R;
		public Node M;
		//public void AddChild(Node n)
		//{
		//	if (Children == null)
		//		Children = new List<Node>();
		//	Children.Add(n);
		//}

         
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
            if (M != null)
            {
                Console.Write("M");
                M.PrintPretty(indent, false);
            }
            if (R != null)
            {
               Console.Write("R");
                R.PrintPretty(indent, false);
            }
            if (L == null && R == null && M == null )
				return;

        }
	}
}