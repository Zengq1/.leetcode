using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Transactions;
using System.ComponentModel;
using System.Globalization;
using System;
using System.Runtime.InteropServices;
using System.Xml.Xsl.Runtime;
/*
 * @lc app=leetcode id=116 lang=csharp
 *
 * [116] Populating Next Right Pointers in Each Node
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) 
    {
          if (root == null) return root; 
          root.next = null;
        Node cur = root;
        Node leftNode = cur;
        Node curRight = null;
        while (cur.left != null && cur.right != null)
        {
            if (cur.next == null)
            {
                if (curRight != null) curRight.next = cur.left;
                cur.left.next = cur.right;
                cur.right.next = null;
               
            }
            else if (cur == leftNode)
            {
                cur.left.next = cur.right;
                curRight = cur.right;
            }
            else
            {
                curRight.next = cur.left;
                cur.left.next = cur.right;
                curRight = cur.right;
            }
            cur = cur.next;
            if (cur == null)
            {
                leftNode = leftNode.left;
                cur = leftNode;
            }
        }

        return root;
    }
}
// @lc code=end

