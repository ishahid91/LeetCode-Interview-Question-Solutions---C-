using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class LCA
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        TreeNode ans = null;
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return root;
            }
            Explore(root, p, q);

            return ans;
        }

        bool Explore(TreeNode root, TreeNode p, TreeNode q)
        {
            if(root == null)
            {
                return false;
            }


            var left = Explore(root.left, p, q) ? 1 : 0;
            var right = Explore(root.right, p, q) ? 1 : 0;

            var mid = 0;
           if(root == p || root ==q)
            {
                mid = 1;
            }

           if(left + right + mid >= 2)
            {
                ans = root;
            }

            return (mid + left + right > 0);
        }


    }
}
