using System;
using System.IO;

namespace WordTree2
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadTree("/Users/n/Projects/WordTree2/WordTree2/test.txt");
            Console.ReadLine();
        }

        public static void Insert(Node currentNode, string word, int n)
        {
            Node childNode = new Node();
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            if (n == word.Length)
            {
                currentNode.value += word;
                return;
            }
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (word[n] == alphabet[i])
                    {
                        if (i < 9)
                        {
                        if (currentNode.L == null)
                            currentNode.L = childNode;
                        else
                            childNode = currentNode.L;
                        }
                    else if (i > 8 && i < 18)
                        {
                        if (currentNode.M == null)
                            currentNode.M = childNode;
                        else
                            childNode = currentNode.M;
                        }
                        else
                        {
                        if (currentNode.R == null)
                            currentNode.R = childNode;
                        else
                            childNode = currentNode.R;
                        }

                    }
                }
            Insert(childNode, word, n + 1);
        }

        static public Node LoadTree(string file)
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

                return r;
            }
        }
    }
}