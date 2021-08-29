using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public static class MergeKLists
    {
        //public static ListNode MergeKList(ListNode[] lists)
        //{
        //    var total = lists.Length;
        //    var head = new ListNode(-1);

        //    var current = head;

        //    for(var  i = 0; i < total; i++)
        //    {
        //        if (lists[i] == null)
        //        {
        //            continue;
        //        }
        //        var list = MergeTwoLists(lists[i], current);
        //        current = list;
        //    }

        //    return head.next;
        //}

        public static ListNode MergeKList(ListNode[] lists)
        {
            List<ListNode> ln = new List<ListNode>();
            ln.Add(new ListNode(1));
            ln.Add(new ListNode(2));
            ln.Add(new ListNode(3));
            ln.Add(new ListNode(4));
            lists = ln.ToArray();
            if (lists.Length == 0)
            {
                return null;
            }
            int interval = 1;
            while (interval < lists.Length)
            {
                for (int i = 0; i + interval < lists.Length; i = i + interval * 2)
                {
                    lists[i] = MergeTwoLists(lists[i], lists[i + interval]);
                }
                interval *= 2;
            }









            var inter = 1;

            for(int i = 0; i + inter < lists.Length; i = i + inter * 2)
            {

            }

            inter *= 2;




            return lists[0];
        }


        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var node = new ListNode(-1);
            var head = node;

            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    head.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    head.next = l2;
                    l2 = l2.next;
                }

                head = head.next;
            }

            head.next = l1 == null ? l2 : l1;

            return node.next;

        }
    }

   
}