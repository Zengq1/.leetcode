using System.Collections.ObjectModel;
using System.Resources;
using System.Xml.Linq;
using System.Buffers;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Runtime.Versioning;
using System.ComponentModel.Design;
using System.Data;
using System.Xml.Serialization;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Collections;
using System.ComponentModel.Design.Serialization;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Xml.Xsl.Runtime;
/*
 * @lc app=leetcode id=94 lang=csharp
 *
 * [94] Binary Tree Inorder Traversal
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
    public IList<int> InorderTraversal(TreeNode root) 
    {
        IList<int> res = new List<int>();
        //DFS(root, res);
        //Iterative

        Stack<TreeNode> sta = new Stack<TreeNode>(); 
        while (true)
        {          
            if (root != null)
            {
                sta.Push(root);
                root = root.left;
            }
            else
            {
                if (!sta.Any()) break;
                root = sta.Pop();
                res.Add(root.val);
                root = root.right;
            }
        }
        
        return res;
    }
    //DFS
    /*
    public void DFS (TreeNode node, IList<int> res)
    {
        if (node == null) return;

        DFS(node.left,res);
        res.Add(node.val);
        DFS(node.right,res);
    }
    */
}
// @lc code=end

