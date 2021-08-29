using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class ConnectRightPointers
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }

        public Node Connect(Node root)
        {
            if (root == null)
            {
                return null;
            }


            Queue<KeyValuePair<Node, int>> queue = new Queue<KeyValuePair<Node, int>>();

            queue.Enqueue(new KeyValuePair<Node, int>(root, 1));

            int level = 0;
            while (queue.Count > 0)
            {

                var current = queue.Dequeue();
                level = current.Value;

                if (queue.Count == 1)
                {
                    current.Key.next = null;
                }
                else
                {
                    var next = queue.Peek();
                    if (next.Value == level)
                    {
                        current.Key.next = next.Key;
                    }
                    else
                    {
                        current.Key.next = null;
                    }
                }

                if (current.Key.left != null)
                {
                    queue.Enqueue(new KeyValuePair<Node, int>(current.Key.left, level + 1));
                }

                if (current.Key.right != null)
                {
                    queue.Enqueue(new KeyValuePair<Node, int>(current.Key.right, level + 1));
                }

                var list = new List<int>();
            }

            return root;
        }
    }
}
