using System.Runtime.InteropServices;
using System.Data;
using System.Xml;
using Microsoft.Win32.SafeHandles;
using System.Threading;
using System.Collections;
using System.Net.Http;
using Microsoft.VisualBasic;
using System.Runtime.ExceptionServices;
using System.Runtime;
using System.Security.Cryptography;
using System.Globalization;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;
using System.Reflection.PortableExecutable;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Xsl.Runtime;
/*
 * @lc app=leetcode id=25 lang=csharp
 *
 * [25] Reverse Nodes in k-Group
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution 
{
    public ListNode ReverseKGroup(ListNode head, int k) 
    {
        if (head == null || head.next == null) return head;
        
        ListNode dummy = new ListNode();
        int length = 0;

        dummy.next = head;
        while (head != null)
        {
            head = head.next;
            length++;
        }

        ListNode cur = dummy;
        ListNode preStart = cur;

        for (int count = 0; count < length/k; count++)
        {
            int revCount = k - 1;
            while (revCount > 0)
            {
                for (int i = 0; i < revCount; i++)
                {
                    SwapPartial(cur);
                    if (i == 0) preStart = cur;
                    cur = cur.next;
                }
                revCount --;
                if (revCount != 0) cur = preStart;
                else 
                {
                    for (int j = 0; j < k - 1; j++)
                    {
                        cur = cur.next;
                    }
                }
            }    
        }

        return dummy.next;
    }
    private void SwapPartial(ListNode pre)
    { 
        ListNode temp = pre.next;
        pre.next = temp.next;
        temp.next = temp.next.next;
        pre.next.next = temp;
    }
}

// @lc code=end

