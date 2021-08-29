using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
        class CopyRandomList
        {
            public Node copyRandomList(Node head)
            {

                if (head == null)
                {
                    return null;
                }

                var ptr = head;

                while (ptr != null)
                {
                    var newNode = new Node(ptr.val);

                    newNode.next = ptr.next;
                    ptr.next = newNode;

                    ptr = newNode.next;
                }

                ptr = head;

                // random

                while(ptr != null)
                {
                    ptr.next.random = ptr.random != null ? ptr.random.next : null;
                    ptr = ptr.next.next;
                }

                var ptr_old = head;
                var ptr_new = head.next;
                var head_new = head.next;
                while(ptr_old != null)
                {
                    ptr.next = ptr.next.next;
                    ptr_new.next = ptr_new.next.next;
                    ptr_old = ptr.next;
                    ptr_new = ptr_new.next;
                }

                return head_new;

            }
        }
    }
