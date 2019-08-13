using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBT
{
    class RBT
    {
        public void Insert(Node curNode, int n)
        {
            bool IsR = false;
            if (n > curNode.Value)
            {
                IsR = true;
                if (curNode.Right == null)
                {
                    curNode.Right = new Node(n);
                    curNode.Right.parent = curNode;
                    if (curNode != null && curNode.Colour == Colour.Red)
                        Restructure(curNode.Right);
                    return;
                }
            }
            else
            {
                if (curNode.Left == null)
                {
                    curNode.Left = new Node(n);
                    curNode.Left.parent = curNode;
                    if (curNode != null && curNode.Colour == Colour.Red)
                        Restructure(curNode.Left);
                    return;
                }
            }
                if (IsR == true)
                Insert(curNode.Right, n);
            else
                Insert(curNode.Left, n);
        }
        void Restructure(Node curNode)
        {
            Node uncle = GetUncle(curNode);
            if (uncle == null)
                curNode.Colour = Colour.Black;
            else
                if (uncle.Colour == Colour.Red)
                ReColour(curNode);
            else
                Rotate(curNode);
        }
        void ReColour(Node curNode)
        {
            Node grandparent = curNode.parent.parent;
            Node uncle = GetUncle(curNode);

            //grandparent is black or ur at root
            if (curNode.parent.Colour == Colour.Black && grandparent == null || grandparent != null && grandparent.parent != null && grandparent.parent.Colour == Colour.Black)
                return;

            curNode.parent.Colour = Colour.Black;
            uncle.Colour = Colour.Black;
            grandparent.Colour = Colour.Red;
            ReColour(grandparent);
        }
        Node GetUncle(Node curNode)
        {
            if (curNode.parent.parent.Left != null && curNode.parent.parent.Left != null)
            {
                if (curNode.parent == curNode.parent.parent.Left)
                    return curNode.parent.parent.Right;
                else if (curNode.parent == curNode.parent.parent.Right)
                    return curNode.parent.parent.Left;
            }
                return null;
        }
        void Rotate(Node curNode)
        {
            Node grandparent = curNode.parent.parent;
            if (grandparent.Left == curNode.parent && curNode.parent.Left == curNode)
                RR(curNode);
            else if (grandparent.Right == curNode.parent && curNode.parent.Right == curNode)
                LR(curNode);
            else if (grandparent.Left == curNode.parent && curNode.parent.Right == curNode)
            {
                curNode.Left = LR(curNode.Left);
                LR(curNode);
            }
            else if (grandparent.Right == curNode.parent && curNode.parent.Left == curNode)
            {
                curNode.Right = RR(curNode.Right);
                LR(curNode);
            }
            else
                return;
        }

        Node RR(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;
            x.Right = y;
            y.Left = T2;
            return x;
        }
        Node LR(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;
            y.Left = x;
            x.Right = T2;
            return y;
        }
    }
}