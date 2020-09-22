using System.Text.RegularExpressions;
using System;
/*
 * @lc app=leetcode id=110 lang=csharp
 *
 * [110] Balanced Binary Tree
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
    publaic bool IsBalanced(TreeNode root)
    {
        return PostOrder(root) != -1;
    }

    private int PostOrder(TreeNode t)
    {
        if (t == null) return 0;

        int left = PostOrder(t.left);
        if (left == -1) return -1;

        int right = PostOrder(t.right);
        if (right == -1) return -1;

        if (Math.Abs(left - right) > 1) return -1;

        return Math.Max(left,right) + 1;
    }
}
// @lc code=end

