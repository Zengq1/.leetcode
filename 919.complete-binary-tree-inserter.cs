using System.Runtime.InteropServices;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Concurrent;
using System.Collections;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Runtime.CompilerServices;
/*
 * @lc app=leetcode id=919 lang=csharp
 *
 * [919] Complete Binary Tree Inserter
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
public class CBTInserter 
{
    Queue<TreeNode> q;
    TreeNode r; 

    public CBTInserter(TreeNode root) 
    {
        q = new Queue<TreeNode>();
        r = root;
        q.Enqueue(root);
        while (q.Any())
        {
            TreeNode cur = q.Peek();
            if (cur.left != null)
            {
                q.Enqueue(cur.left);
            }
            else break;

            if (cur.right != null)
            {
                q.Enqueue(cur.right);
                q.Dequeue(); //remove the first node since both left and right node were filled
            }
            else break;
        }
    }
    
    public int Insert(int v) 
    {
        TreeNode cur =  q.Peek();

        if (cur.left == null) 
        {
            cur.left = new TreeNode(v);
            q.Enqueue(cur.left);
        }
        else
        {
            cur.right = new TreeNode(v);
            q.Dequeue();
            q.Enqueue(cur.right);
        }

        return cur.val;
    }
    
    public TreeNode Get_root() 
    {
        return r;
    }
}

/**
 * Your CBTInserter object will be instantiated and called as such:
 * CBTInserter obj = new CBTInserter(root);
 * int param_1 = obj.Insert(v);
 * TreeNode param_2 = obj.Get_root();
 */
// @lc code=end

