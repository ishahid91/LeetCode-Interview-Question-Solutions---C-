using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class InsertNodesCLL
    {
        public class Node
        {
            public int val;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
                next = null;
            }

            public Node(int _val, Node _next)
            {
                val = _val;
                next = _next;
            }
        }
        public Node Insert(Node head, int insertVal)
        {
            if(head == null)
            {
                var node = new Node(insertVal);
                node.next = node;
                return node;
                
            }

            var currentNode = head;
            var NextNode = head.next;
            while(NextNode != head)
            {
                Console.WriteLine($"current: {currentNode.val} next {NextNode.val}");
                if(currentNode.val <= insertVal && insertVal <= NextNode.val)
                {
                    Console.WriteLine($"case 1: current: {currentNode.val} next {NextNode.val}");
                    AddBetween(currentNode, NextNode, insertVal);
                    break;
                }
                else if(currentNode.val > NextNode.val)
                {
                    if (insertVal >= currentNode.val || insertVal <= NextNode.val)
                    {
                        Console.WriteLine($"case 2: current: {currentNode.val} next {NextNode.val}");
                        AddBetween(currentNode, NextNode, insertVal);
                        break;
                    }
                }
                currentNode = currentNode.next;
                NextNode = NextNode.next;
            }
            Console.WriteLine($"case 3: current: {currentNode.val} next {NextNode.val}");
            AddBetween(currentNode, NextNode, insertVal);

            return head;
        }

        void AddBetween(Node a, Node b, int insertVal)
        {
            a.next = new Node(insertVal, b);
        }
    }
}
