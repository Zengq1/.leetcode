using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
/*
 * @lc app=leetcode id=111 lang=csharp
 *
 * [111] Minimum Depth of Binary Tree
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
    public int MinDepth(TreeNode root) 
    {
        if (root == null) return 0;

        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        int minDepth = 1;
        int rowNum = 1;
        while (q.Any())
        {
            TreeNode tempNode = q.Dequeue();
            rowNum--;
            if (tempNode.left == null && tempNode.right == null) break;
                
            if (tempNode.left != null)
            {
                q.Enqueue(tempNode.left);
            }
            if (tempNode.right != null)
            {
                q.Enqueue(tempNode.right);
            }
            if (rowNum == 0)
            {
                rowNum = q.Count;
                minDepth++;
            }
        } 

        return minDepth;  
    }
}
// @lc code=end

