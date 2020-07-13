using System.Reflection.PortableExecutable;
using System.Net.Http.Headers;
using System.Data.Common;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Collections.Concurrent;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Runtime;
using Internal;
using System.Diagnostics.Contracts;
using System.Runtime.ConstrainedExecution;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Xsl.Runtime;
using System.Threading;
using System.Security.Cryptography;
using System.Transactions;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design.Serialization;
using System.Threading.Tasks.Dataflow;
using System;
using System.Diagnostics;
/*
 * @lc app=leetcode id=99 lang=csharp
 *
 * [99] Recover Binary Search Tree
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
    public void RecoverTree(TreeNode root) 
    {
        TreeNode bad1 = null;
        TreeNode bad2 = null;
        TreeNode preTreeNode = null;
        TreeNode cur = root;
        TreeNode pre = null;
        //since the question reque O(1) space, so I use Morris traversal to do inorder DFS
        while (cur != null)
        {
            if (cur.left == null)
            {
                if (preTreeNode == null) preTreeNode = cur;
                else 
                {
                    if (preTreeNode.val > cur.val)
                    {
                        if (bad1 == null)
                        {
                            bad1 = preTreeNode;
                            bad2 = cur;
                        }
                        else bad2 = cur;
                    }
                }
                preTreeNode = cur;
                cur = cur.right;
            }
            else
            {
                pre = cur.left;
                
                //loop to the end of the right node
                while (pre.right != null && pre.right != cur)
                {
                    pre = pre.right;
                } 

                //means left node alread loop through
                if (pre.right == cur)
                {
                    if (preTreeNode.val > cur.val)
                    {
                        if (bad1 == null)
                        {
                            bad1 = preTreeNode;
                            bad2 = cur;
                        }
                        else bad2 = cur;
                    }
                    preTreeNode = cur;

                    pre.right = null;
                    cur = cur.right;
                }
                else
                {
                    pre.right = cur;
                    cur = cur.left;
                }
            }
        }
        int temp = bad1.val;
        bad1.val = bad2.val;
        bad2.val = temp;
    }
}
// @lc code=end

