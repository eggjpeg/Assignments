using System;
namespace RBT
{
    enum Colour
    {
        Red,
        Black
    }
    class Node
    {
        public int Value;
        public Node Left, Right;
        public Colour Colour;
        public Node parent;

        public Node(int value)
        {
            this.Value = value;
            this.Colour = Colour.Red;
        }

        public void PrintPretty(string indent, bool last, int i)
        {
            if (i == 0)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Clear();
            }

            i++;
            Console.Write(indent);
            if (last)
            {
                Console.Write(@"\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            if (Colour == Colour.Red)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Value);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(Value);
            }

            if (Left != null)
                Left.PrintPretty(indent, false, i);
            if (Right != null)
                Right.PrintPretty(indent, false, i);
            if (Left == null && Right == null)
                return;
        }
    }
}