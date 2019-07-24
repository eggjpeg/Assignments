using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node r = new Node();
            r.value = "_";
            InsertToFile("text.txt");
            Console.ReadLine();
        } 

        static public void InsertToFile(string file)
        {
            Node r = new Node();
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Insert(r, line.ToLower(), 0);
                }
                r.PrintPretty(" ", true);
            }
        }

        static public void Insert(Node currentNode, string word, int i)
        {
            bool valueExists = false;
            Node childNode = new Node();

            if (i == word.Length || i == 4)
            {
                currentNode.value = word;
                return;
            }
            if (currentNode.Children != null)
            {
                foreach (var item in currentNode.Children)
                {
                    if (item.value == word[i].ToString())
                    {
                        valueExists = true;
                        childNode = item;
                        break;
                    }
                }
            }
            if (valueExists == false)
            {
                childNode.value = word[i].ToString();
                currentNode.AddChild(childNode);
            }
            Insert(childNode, word, i + 1);
        }

    }
}
