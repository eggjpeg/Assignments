using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;
namespace WordTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var subList = LoadList("subText.txt");
            // var list = LoadList("text.txt");
            Node r = LoadTree("text.txt");
            // ContainsList(subList, list);
             TimedContains(subList, r);
            Console.ReadLine();
        }

        static public Node LoadTree(string file)
        {
            Node r = new Node();
            r.value = "_";
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Insert(r, line.ToLower(), 0);
                }
                return r;
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

        static public bool ContainsTree(Node currentNode, string word, int i)
        {
                foreach (var child in currentNode.Children)
                {
                    if (child.value == word)
                        return true;
                 
                    if (child.value == word[i].ToString())
                        return ContainsTree(child, word, i + 1);
                }
            return false;
        }

        static public void TimedContains(List<string> subList, Node r)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var word in subList)
            {
                if(ContainsTree(r, word, 0))  
                     Console.WriteLine(word);
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
        static public List<string> LoadList(string file)
        {
            var list = new List<string>();
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    list.Add(line);
                }
                return list;               
            }
        }

        static public void ContainsList(List<string> subList, List<string> list)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var word in subList)
                list.Contains(word);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);           
        }

       

    }
}
