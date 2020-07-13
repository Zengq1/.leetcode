using System.Linq;
using System.Net.Mime;
/*
 * @lc app=leetcode id=104 lang=csharp
 *
 * [104] Maximum Depth of Binary Tree
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution 
{
    public int MaxDepth(TreeNode root) 
    {
        /* BFS
        if (root == null) return 0;
        if (root.left ==null && root.right == null) return 1;
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        int rowNum = 1,depth = 0;

        while (q.Any())
        {
            root = q.Dequeue();
            rowNum--;

            if (root.left != null) q.Enqueue(root.left);
            if (root.right != null) q.Enqueue(root.right);

            if (rowNum == 0)
            {
                rowNum = q.Count;
                depth++;
            }
        }

        return depth;
        */

        //recursive
        if (root == null) return 0;
        if (root.left == null && root.right == null) return 1;

        int left = MaxDepth(root.left), right = MaxDepth(root.right);
        return left>right?left + 1:right + 1; //add one because it spiped the root level
    }
}
// @lc code=end

