using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class LRUCache
    {
        public class DoubleLinkedList
        {
            public int val { get; set; }
            public DoubleLinkedList next { get; set; }
            public DoubleLinkedList prev { get; set; }
            public int key { get; set; }

            public  DoubleLinkedList()
            {

            }
        }


        DoubleLinkedList head = new DoubleLinkedList();
        DoubleLinkedList tail = new DoubleLinkedList();
        int capacity;

        Dictionary<int, DoubleLinkedList> map;

        public LRUCache(int capacity)
        {
            head.next = tail;
            tail.prev = head;
            this.capacity = capacity;
            map = new Dictionary<int, DoubleLinkedList>(capacity);
        }


        public void add(DoubleLinkedList node)
        {
            var head_next = head.next;
            node.prev = head;
            node.next = head_next;
            head_next.prev = node;
            head.next = node;
        }

        public void remove(DoubleLinkedList node)
        {
            var node_previous = node.prev;
            var node_next = node.next;
            node_previous.next = node_next;
            node_next.prev = node_previous;
        }

        public int Get(int key)
        {
            if (!map.ContainsKey(key))
            {
                return -1;
            }

            var node = map[key];

            remove(node);
            add(node);

            return node.val;

        }

        public void Put(int key, int value)
        {
            if (map.ContainsKey(key))
            {
                var node = map[key];
                node.val = value;

                remove(node);
                add(node);
            }
            else
            {
                DoubleLinkedList node = new DoubleLinkedList();
                node.key = key;
                node.val = value;

                if(map.Count == capacity)
                {
                    map.Remove(tail.prev.key);
                    remove(tail.prev);
                }
                map.Add(key, node);

                add(node);

            }
        }
    }
}
