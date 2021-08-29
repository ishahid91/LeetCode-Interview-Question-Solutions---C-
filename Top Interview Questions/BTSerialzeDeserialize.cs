using System;
using System.Collections.Generic;
using System.Text;

namespace codetest
{

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class BTSerialzeDeserialize
    {
        public string serialize(TreeNode root)
        {
            return dfs(root, new StringBuilder());
        }

        string dfs(TreeNode root, StringBuilder result)
        {
            if (root == null)
                result.Append("null,");
            else
            {
                result.Append(root.val);
                result.Append(",");
                result.Append(dfs(root.left, result));
                result.Append(dfs(root.right, result));
            }

            return result.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            string[] arr = data.Split(",");
            List<string> data_list = new List<string>(arr);

            return des(data_list);
        }

        public TreeNode des(List<string> data)
        {
            Console.WriteLine(data.Count);
            if (data[0] == "null")
            {
                data.RemoveAt(0);
                return null;
            }


            TreeNode node = new TreeNode(Convert.ToInt16(data[0]));
            data.RemoveAt(0);
            node.left = des(data);
            node.right = des(data);

            return node;
        }
    }
}
