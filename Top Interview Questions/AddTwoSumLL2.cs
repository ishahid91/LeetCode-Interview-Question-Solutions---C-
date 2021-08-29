using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class AddTwoSumLL2
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // calculate count l1
            var list1 = l1;
            int n1 = 0;
            while (list1 != null)
            {
                n1 += 1;
                list1 = list1.next;
            }


            // calculate count l2
            var list2 = l2;
            int n2 = 0;
            while (list2 != null)
            {
                n2 += 1;
                list2 = list2.next;
            }

            Console.WriteLine($"n1: {n1} n2: {n2}");
            
            // sum l1 & l2
            list1 = l1;
            list2 = l2;
            ListNode head =null;
            while (n1 > 0 && n2 > 0)
            {
                int val = 0;
                if (n1 >= n2)
                {
                    val += list1.val;
                    list1 = list1.next;
                    --n1;
                }

                if (n1 < n2)
                {
                    val += list2.val;
                    list2 = list2.next;
                    --n2;
                }

                // add to front
                var node = new ListNode(val);
                node.next = head;
                head = node;

                printNodes(head);

            }


            Console.WriteLine("sum noded end-------");
            // iterate and take care of carry

            var currNode = head;
            head = null;
            int carry = 0;
            while (currNode != null)
            {
                var val = (carry + currNode.val) % 10;
                carry = (currNode.val + carry) / 10;


                var node = new ListNode(val);
                node.next = head;
                head = node;
                printNodes(head);
                currNode = currNode.next;
            }

            if (carry != 0)
            {
                var node = new ListNode(carry);
                node.next = head;
                head = node;
            }

            return head;

        }


        private void printNodes (ListNode Print)
        {
            var node = Print;
            while(node != null)
            {
                Console.Write(node.val + " -> ");
                node = node.next;
            }
            Console.WriteLine();
        }
    }
}
