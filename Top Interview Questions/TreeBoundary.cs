using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    
    class TreeBoundary
    {
        public bool IsLeaf(TreeNode node)
        {
            return node.left == null && node.right == null;
        }
        public void AddLeafs(TreeNode node, List<int> result)
        {
            if(node == null)
            {
                return;
            }
            if(!IsLeaf(node))
            {
                result.Add(node.val);
            }

            AddLeafs(node.left, result);
            AddLeafs(node.right, result);
        }
        public IList<int> BoundaryOfBinaryTree(TreeNode root)
        {
            var result = new List<int>(); 

            // left

            if(!IsLeaf(root))
            {
                result.Add(root.val);
            }

            var t = root.left;

            while(t != null)
            {
                if (!IsLeaf(t))
                {
                    result.Add(t.val);
                }
                if (t.left != null)
                {
                    t = t.left;
                    
                } else if(t.right != null)
                {
                    t = t.right;
                }
            }

            // leaves

            AddLeafs(root, result);


            //right
            Stack<int> stack = new Stack<int>();
            t = root.right;
            while(root != null)
            {
                if (!IsLeaf(t))
                {
                    stack.Push(t.val);
                }
                if (root.right != null)
                {
                    root = root.right;
                }
                else if(root.left != null)
                {
                    root = root.left;
                }
            }

            while(stack.Count > 0)
            {
                result.Add(stack.Pop());
            }


            return result;
        }








        /////////////////
        ///







        List<int> nodes = new List<int>();
        public List<int> boundaryOfBinaryTree(TreeNode root)
        {

            if (root == null) return nodes;

            nodes.Add(root.val);
            leftBoundary(root.left);
            leaves(root.left);
            leaves(root.right);
            rightBoundary(root.right);

            return nodes;
        }
        void leftBoundary(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null)) return;
            nodes.Add(root.val);
            if (root.left == null) leftBoundary(root.right);
            else leftBoundary(root.left);
        }
        public void rightBoundary(TreeNode root)
        {
            if (root == null || (root.right == null && root.left == null)) return;
            if (root.right == null) rightBoundary(root.left);
            else rightBoundary(root.right);
            nodes.Add(root.val); 
        }
        public void leaves(TreeNode root)
        {
            if (root == null) return;
            if (root.left == null && root.right == null)
            {
                nodes.Add(root.val);
                return;
            }
            leaves(root.left);
            leaves(root.right);
        }
    }
}
