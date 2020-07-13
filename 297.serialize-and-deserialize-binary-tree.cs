using System.Reflection.Metadata.Ecma335;
using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=297 lang=csharp
 *
 * [297] Serialize and Deserialize Binary Tree
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) 
    {
        if (root == null) return "";

        StringBuilder sb = new StringBuilder();
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        sb.Append(root.val.ToString()+',');

        while (q.Any())
        {
            TreeNode tempNode = q.Dequeue();

            if (tempNode.left != null) 
            {
                q.Enqueue(tempNode.left);
                sb.Append(tempNode.left.val.ToString() + ',');
            }
            else sb.Append ("null,");
            if (tempNode.right != null) 
            {
                q.Enqueue(tempNode.right);
                sb.Append(tempNode.right.val.ToString() + ',');
            }
            else sb.Append("null,");
        }
        sb.Remove(sb.Length - 1, 1);
        Console.WriteLine(sb.ToString());
        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) 
    {
        if (data == "" ||data == null) return null;

        List<string> s = data.Split(',').ToList<string>();
        Console.WriteLine(s[0]);
        TreeNode root = new TreeNode(int.Parse(s[0]));
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);

        for (int i = 1; i < s.Count - 1; i += 2)
        {
            TreeNode tempNode = q.Dequeue();
            if (s[i] != "null")
            {
                tempNode.left = new TreeNode(int.Parse(s[i]));
                q.Enqueue(tempNode.left);
            }
            if (s[i+1] != "null")
            {
                tempNode.right = new TreeNode(int.Parse(s[i+1]));
                q.Enqueue(tempNode.right);
            }
        }

        return root;  
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));
// @lc code=end

