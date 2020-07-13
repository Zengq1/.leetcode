using System.Runtime.Serialization;
using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Net.Mail;
using System.Security.Authentication.ExtendedProtection;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using System.Collections.Concurrent;
using System.Data;
using System.Xml.Serialization;
using System.Net.Sockets;
using System.Xml;
using System.IO;
using System.Collections;
using System.Linq;
using System.Numerics;
using System.Collections.Specialized;
using System.Security.AccessControl;
using System.Reflection.Metadata.Ecma335;
using System.Net.NetworkInformation;
using System.Xml.Xsl.Runtime;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=133 lang=csharp
 *
 * [133] Clone Graph
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;
    
    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }
    
    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution 
{
    private Dictionary<Node, Node> seen = new Dictionary<Node,Node>();

    public Node CloneGraph(Node node) 
    {
        //edge case
        if (node == null) return node;

        /* 
        //DFS
        if (seen.ContainsKey(node)) return seen[node];
        
        Node newNode = new Node(node.val, new List<Node>());
        seen.Add(node, newNode);

        foreach (Node neighbor in node.neighbors)
        {
            newNode.neighbors.Add(CloneGraph(neighbor));
        }

        return newNode;
        */

        //BFS
         Queue<Node> q = new Queue<Node>();
        q.Enqueue(node);
        seen.Add(node, new Node(node.val,new List<Node>()));
        
        while (q.Any())
        {
            Node cur = q.Dequeue();
            foreach (Node neighbor in cur.neighbors)
            {
                if (!seen.ContainsKey(neighbor))
                {
                    seen.Add(neighbor,new Node(neighbor.val,new List<Node>()));
                    q.Enqueue(neighbor);
                }
                seen[cur].neighbors.Add(seen[neighbor]);
            }
        }
        return seen[node];
    }
}

// @lc code=end

