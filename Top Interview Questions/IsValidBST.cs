using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class IsValidBST
    {
        public bool isValidBST(TreeNode root)
        {
            return checkIsValid(root, null, null);
        }

        private bool checkIsValid(TreeNode root, int? min, int? max)
        {
            if (root == null)
            {
                return true;
            }

            if ((min != null && root.val <= min) || (max != null && root.val >= max))
            {
                return false;
            }

            return checkIsValid(root.left, min, root.val) && checkIsValid(root.right, root.val, max);
        }


        public bool isValidBSTInOrder(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode prev = null;
            while(root != null || stack.Count > 0)
            {
                while(root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                var current = stack.Pop();

                if(prev != null && current.val < prev.val)
                {
                    return false;
                }

                prev = current;

                root = current.right;

            }

            return true;
        }
    }
