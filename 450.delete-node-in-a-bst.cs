/*
 * @lc app=leetcode id=450 lang=csharp
 *
 * [450] Delete Node in a BST
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
    public TreeNode DeleteNode(TreeNode root, int key) 
    {   
        if (root == null) return root;
        if (root.val > key) root.left = DeleteNode(root.left,key);
        else if (root.val < key) root.right = DeleteNode(root.right,key);
        else // root value = key
        {
            //4 situations
            //key left null; key right null; key left right null, key left right not null
            if (root.left == null && root.right == null) return null;
            if (root.left == null) return root.right;
            if (root.right == null) return root.left;
            //both left and right are not null 
            TreeNode pre = root.right;
            if (pre.left == null)
            {
                pre.left = root.left;
                return pre;
            }
            while (pre.left.left != null) pre = pre.left;
            root.val = pre.left.val;
            root.right = DeleteNode(root.right,root.val);
        }
        return root;
    }
}
// @lc code=end

