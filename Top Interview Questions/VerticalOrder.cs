using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{
    class VerticalOrder
    {
        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            if(root == null)
            {
                return new List<IList<int>>();
            }

            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();

            Dictionary<int, List<int>> values = new Dictionary<int, List<int>>();

            var result = new List<IList<int>>();

            int minColumn = 0;
            int maxColumn = 0;
            
            queue.Enqueue(new KeyValuePair<TreeNode, int>(root,0));

            while(queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Key != null)
                {
                    if (!values.TryGetValue(current.Value, out var cList))
                    {
                        values.Add(current.Value, new List<int>());
                    }

                    cList.Add(current.Key.val);

                    values[current.Value] = cList;

                    if (current.Key.left != null)
                    {
                        queue.Enqueue(new KeyValuePair<TreeNode, int>(current.Key.left, current.Value - 1));
                    }
                    if (current.Key.right != null)
                    {
                        queue.Enqueue(new KeyValuePair<TreeNode, int>(current.Key.right, current.Value + 1));
                    }
                }

            }

        }
    }
}
