using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class LevelOrder
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            if(root == null)
            {
                return new List<IList<int>>();
            }


            Queue<TreeNode> queue = new Queue<TreeNode>();
            var result =new List<IList<int>>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                var size = queue.Count;
                var list = new List<int>();
                for(int i = 0; i < size; i++)
                {

                    var curr = queue.Dequeue();
                    list.Add(curr.val);

                    if(curr.left != null)
                    {
                        queue.Enqueue(curr.left);
                    }

                    if (curr.right != null)
                    {
                        queue.Enqueue(curr.right);
                    }

                }

                result.Add(list);

            }

            return result;
        }

        public IList<double> LevelOrderAverage(TreeNode root)
        {
            if (root == null)
            {
                return new List<double>();
            }


            Queue<TreeNode> queue = new Queue<TreeNode>();
            var result = new List<double>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var size = queue.Count;
                var sum = 0.0;
                for (int i = 0; i < size; i++)
                {

                    var curr = queue.Dequeue();
                    sum = sum + curr.val;

                    if (curr.left != null)
                    {
                        queue.Enqueue(curr.left);
                    }

                    if (curr.right != null)
                    {
                        queue.Enqueue(curr.right);
                    }

                }
                double average = sum / size;
                result.Add(average);

            }
            return result;
        }
    }
