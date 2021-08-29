using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class LinkedListGeneral
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null)
            {
                return true;
            }

            var slow = head;
            var fast = head.next;

            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                {
                    return false;
                }

                slow = slow.next;
                fast = fast.next.next;
            }

            return true;
        }

        public ListNode ReverseList(ListNode head)
        {
            var currentNode = head;
            ListNode prevNode = null;

            while (currentNode != null)
            {
                var tmp = currentNode.next;
                currentNode.next = prevNode;
                prevNode = currentNode;
                currentNode = tmp;
            }

            return prevNode;
        }
    }
}   

