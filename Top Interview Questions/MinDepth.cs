using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class MinDepthClass
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public static int MinDepth(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }

            Queue<KeyValuePair<TreeNode,int>> queue = new Queue<KeyValuePair<TreeNode, int>>();

            queue.Enqueue(new KeyValuePair<TreeNode, int>(root,0));

            int level = 0;
            while(queue.Count > 0)
            {
               
                var current = queue.Dequeue();
                level = current.Value;
                if (current.Key.left != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(current.Key.left, level+ 1));
                }

                if (current.Key.right != null)
                {
                    queue.Enqueue(new KeyValuePair<TreeNode, int>(current.Key.right, level+1));
                }
                

            }

            return level;
        }
    }
}
