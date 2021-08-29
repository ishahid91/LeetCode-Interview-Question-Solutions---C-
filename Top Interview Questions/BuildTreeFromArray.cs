using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class BuildTreeFromArray
    {
        int preIndex = 0;

        Dictionary<int, int> lookUp = new Dictionary<int, int>();
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {

            for(int i = 0; i < inorder.Length; i++)
            {
                lookUp.Add(inorder[i], i);
            }


           return  Helper(preorder, 0, inorder.Length - 1);
        }


        TreeNode Helper(int[] preorder, int left, int right)
        {
            if(left <right)
            {
                return null;
            }


            TreeNode root = new TreeNode(preorder[preIndex++]);

            root.left = Helper(preorder, left, lookUp[root.val] - 1);
            root.right = Helper(preorder, lookUp[root.val] + 1, right);

            return root;

        }

        public TreeNode BuildTreePost(int[] inorder, int[] postorder)
        {

            for (int i = 0; i < inorder.Length; i++)
            {
                lookUp.Add(inorder[i], i);
            }
            preIndex = postorder.Length - 1;

            return HelperPost(postorder, 0, inorder.Length - 1);
        }


        TreeNode HelperPost(int[] postorder, int left, int right)
        {
            if (left > right)
            {
                return null;
            }


            TreeNode root = new TreeNode(postorder[preIndex--]);

            root.right = Helper(postorder, lookUp[root.val] + 1, right);
            root.left = Helper(postorder, left, lookUp[root.val] - 1);

            return root;

        }


        private int[,] memo;
        public string text1;
        public string text2;

        public int LongestCommonSubsequence(String text1, String text2)
        {
            // Make the memo big enough to hold the cases where the pointers
            // go over the edges of the strings.
            this.memo = new int[text1.Length + 1, text2.Length + 1];
            // We need to initialise the memo array to -1's so that we know
            // whether or not a value has been filled in. Keep the base cases
            // as 0's to simplify the later code a bit.
            for (int i = 0; i < text1.Length; i++)
            {
                for (int j = 0; j < text2.Length; j++)
                {
                    this.memo[i, j] = -1;
                }
            }
            this.text1 = text1;
            this.text2 = text2;
            return memoSolve(0, 0);
        }

        private int memoSolve(int p1, int p2)
        {
            // Check whether or not we've already solved this subproblem.
            // This also covers the base cases where p1 == text1.length
            // or p2 == text2.length.
            if (memo[p1, p2] != -1)
            {
                return memo[p1, p2];
            }

            // Recursive cases.
            int answer = 0;
            if (text1[p1] == text2[p2])
            {
                answer = 1 + memoSolve(p1 + 1, p2 + 1);
            }
            else
            {
                answer = Math.Max(memoSolve(p1, p2 + 1), memoSolve(p1 + 1, p2));
            }

            // Add the best answer to the memo before returning it.
            memo[p1, p2] = answer;
            return memo[p1, p2];
        }

    }
}
