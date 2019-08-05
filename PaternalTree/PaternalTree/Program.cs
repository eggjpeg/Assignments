using System;
using System.Collections.Generic;
using System.IO;
namespace PaternalTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node r = new Node("god");
            FileInsert("/Users/n/Projects/PaternalTree/PaternalTree/farm.txt", r);
            PrintPretty(r, " ", true);
           // r.PrintPretty(" ", true);
            Console.ReadLine();
        }

        static public void FileInsert(string file, Node r)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Insert(r, line);
                }
            }
        }

        static public void Insert(Node root, string line)
        {
            string[] lineAr = line.Split(' ');
            if (lineAr[1] == "brother")
            {
                var bro = FindNode(root, lineAr[3]);
                bro.parent.AddChild(new Node(lineAr[0]));
                bro.parent.Children[bro.parent.Children.Count - 1].parent = bro.parent;
            }
            else
            {
                var tup = AdjustRelationship(lineAr);
                var parentNode = FindNode(root, tup.Item1);
                if (parentNode == null)
                {
                    parentNode = new Node(tup.Item1);
                    root.AddChild(parentNode);
                    parentNode.parent = root;
                }

                var childNode = FindNode(root, tup.Item2);
                if (childNode == null)
                {
                    childNode = new Node(tup.Item2);
                    parentNode.AddChild(childNode); 
                    childNode.parent = parentNode;
                }
                else if (childNode.parent == root)
                {
                    childNode.parent = parentNode;
                    parentNode.AddChild(childNode);
                    root.Children.Remove(childNode);
                }
                else
                    throw new Exception("Child already has a father! spaz!");
            }
            
        }

        public static Tuple<string, string> AdjustRelationship(string[] lineAr)
        {
            if (lineAr[1] == "father")
                return new Tuple<string, string>(lineAr[0],lineAr[3]);
            return new Tuple<string, string>(lineAr[3], lineAr[0]);
        }

        public static Node FindNode(Node n, string name)
        {
            if (n != null && n.Children != null )
            {
                foreach (var item in n.Children)
                {
                    if (item.value == name)
                        return item;
                    if (item.Children != null)
                        return FindNode(item, name);
                }
            }
            return null;
        }
        public static void PrintPretty(Node n, string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write(@"-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            Console.WriteLine(n.value);

            if (n.Children == null)
                return;

            for (int i = 0; i < n.Children.Count; i++)
                PrintPretty(n.Children[i], indent, i == n.Children.Count - 1);
        }
    }
}
