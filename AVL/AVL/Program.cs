using System;
using System.Collections.Generic;
namespace AVL
{
    class Node
    {
        public int value, height;
        public Node left, right;

        public Node(int d)
        {
            value = d;
            height = 1;
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

            if (left != null)
            {
                Console.Write("L");
                left.PrintPretty(indent, false);
            }
            if (right != null)
            {
                Console.Write("R");
                right.PrintPretty(indent, false);
            }
            if (left == null && right == null)
                return;

        }
    }

    public class AVLTree
    {
        Node root;

        public static void Main(string[] args)
        {
            AVLTree tree = new AVLTree();
            var list = GenerateRandomList(100, 1000);
            for (int i = 1; i < list.Count; i++)
                tree.root = tree.Insert(tree.root, list[i]);

            tree.root.PrintPretty(" ", true);
        }
        int Height(Node N)
        {
            if (N == null)
                return 0;

            return N.height;
        }

        int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        Node RR(Node y)
        {
            Node x = y.left;
            Node T2 = x.right;

            x.right = y;
            y.left = T2;

            y.height = GetHeight(y);
            x.height = GetHeight(x);
            return x;
        }
        Node LR(Node x)
        {
            Node y = x.right;
            Node T2 = y.left;

            y.left = x;
            x.right = T2;

            x.height = GetHeight(x);
            y.height = GetHeight(y);
            return y;
        }
        int GetHeight(Node n)
        {
            return max(Height(n.left), Height(n.right)) + 1;
        }
        int GetBalance(Node n)
        {
            if (n == null)
                return 0;
            return Height(n.left) - Height(n.right);
        }

        Node Insert(Node curNode, int n)
        {
            if (curNode == null)
                return new Node(n);

            if (n < curNode.value)
                curNode.left = Insert(curNode.left, n);
            else if (n > curNode.value)
                curNode.right = Insert(curNode.right, n);
            else
                return curNode;

            curNode.height = GetHeight(curNode);

            return Balance(curNode, n);
        }

        private Node Balance(Node node, int key)
        {
            int balance = GetBalance(node);

            if (balance > 1 && key < node.left.value)
                return RR(node);

            if (balance < -1 && key > node.right.value)
                return LR(node);

            if (balance > 1 && key > node.left.value)
            {
                node.left = LR(node.left);
                return RR(node);
            }

            if (balance < -1 && key < node.right.value)
            {
                node.right = RR(node.right);
                return LR(node);
            }

            return node;
        }
        static List<int> GenerateRandomList(int n, int x)
        {
            var list = new List<int>();
            for (int i = 1; i < n; i++)
            {
                Random r = new Random();
                list.Add(r.Next(1, x));
            }
            return list;
        }
       
    }
}
