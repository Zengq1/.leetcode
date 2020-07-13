using System.Data.Common;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel;
using System;
using System.Security.Principal;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.Design.Serialization;
/*
 * @lc app=leetcode id=124 lang=csharp
 *
 * [124] Binary Tree Maximum Path Sum
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
    private int maxRes;
    public int MaxPathSum(TreeNode root) 
    {
        maxRes = int.MinValue;
        DFS(root);
        return maxRes;
    }

    public int DFS (TreeNode root)
    {
        if (root == null) return 0;
        int leftMax = Math.Max(0,DFS(root.left)), rightMax = Math.Max(0,DFS(root.right));
        maxRes = Math.Max((leftMax + rightMax + root.val),maxRes);
        return Math.Max(leftMax,rightMax) + root.val;
    }
}
// @lc code=end

