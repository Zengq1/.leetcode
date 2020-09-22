using System.Globalization;
using System;
using System.Runtime.InteropServices;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
/*
 * @lc app=leetcode id=199 lang=csharp
 *
 * [199] Binary Tree Right Side View
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
    public IList<int> RightSideView(TreeNode root) 
    {
        IList<int> res = new List<int>();
        if (root == null) return res;
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        int curNum = 1;
        while (q.Any())
        {
            curNum--;
            TreeNode cur = q.Dequeue();
            if (cur.left != null) q.Enqueue(cur.left);
            if (cur.right != null) q.Enqueue(cur.right);

            if (curNum == 0)
            {
                res.Add(cur.val);
                curNum = q.Count();
            }
        }
        return res;
    }
}
// @lc code=end

