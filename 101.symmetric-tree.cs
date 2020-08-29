using System.Xml.Serialization;
using System.Net.Security;
using System.Threading;
using System.Security.AccessControl;
using System.Xml.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
using System.ComponentModel.Design.Serialization;
/*
 * @lc app=leetcode id=101 lang=csharp
 *
 * [101] Symmetric Tree
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
public class Solution {
    public bool IsSymmetric(TreeNode root) 
    {
        if (root == null || (root.left == null && root.right == null)) return true;
        return IsEqual(root.left,root.right);
    }

    private bool IsEqual(TreeNode left, TreeNode right)
    {
        if (left == null && right == null) return true;
        if (left == null || right == null) return false;
        if (left.val != right.val) return false;
        return IsEqual(left.left,right.right) && IsEqual(left.right,right.left);
    }
}
// @lc code=end

