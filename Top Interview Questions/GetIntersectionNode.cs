using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class GetIntersectionNode
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var count1 = 0;
            var count2 = 0;

            var l1 = headA;
            while(l1 != null)
            {
                count1++;
                l1 = l1.next;
            }

            var l2 = headA;
            while (l2 != null)
            {
                count2++;
                l2 = l2.next;
            }
            Console.WriteLine($"{count1} {count2}");
            ListNode big = count1 > count2 ? headA : headB;
            ListNode othernode = count1 > count2 ? headB : headA;
            var diff = count2 - count1;
            while (diff > 0)
            {
                big = big.next;
                diff--;
            }

            
            while(big != null & othernode !=null)
            {
                if(big == othernode)
                {
                    return big;
                }
                else
                {
                    big = big.next;
                    othernode = othernode.next;
                }
            }


            return null;

        }
}
