using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class AddTwoNumLL
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var dummyHead = new ListNode(0);
            var current = dummyHead;
            int carry = 0;
            while (l1 != null && l2 != null)
            {
                int x = l1 != null ? l1.val : 0;
                int y = l2 != null ? l2.val : 0;

                int sum = carry + x + y;

                carry = sum / 10;

                var currentNode = new ListNode(sum % 10);

                current.next = currentNode;

                if (l1 != null)
                {
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    l2 = l2.next;
                }
                current = current.next;
            }

            if (carry != 0)
            {
                var currentNode = new ListNode(carry);

                current.next = currentNode;
            }

            return dummyHead.next;
        }
    }
}
