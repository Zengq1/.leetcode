using System.Runtime.Serialization.Formatters;
using System;
using System.Xml;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;
using System.Reflection.PortableExecutable;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices.ComTypes;
/*
 * @lc app=leetcode id=148 lang=csharp
 *
 * [148] Sort List
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
    ListNode frontNode = new ListNode(0);
    ListNode lastNode = new ListNode(0);

    public ListNode SortList(ListNode head) 
    {
        if (head == null && head.next == null) return head;

        ListNode dummy = new ListNode(0);
        ListNode slow = head;
        ListNode fast = head.next;
        ListNode newHead = head; 
        
        //get length of the list node
        dummy.next = head;
        int length = 0;
        while (head != null)
        {
            head = head.next;
            length++;
        }

        head = dummy.next;
        int count = 0;
        for (int i = 1; i < length; i << = 1)
        {
            //TODO: set new head
            count = i;
            for (int j = 0; j + i <= length; j += i)
            {
                slow = newHead;
                fast = nextHead;
                while (count > 0 && fast.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                    count--;
                }   
                j++;
                newHead = fast.next;
                count = i;
            }
        }
    }

    //l1 is head of first node , and l2 is head of the compare node, length is the length of the compare listnode
    public void sort(ListNode l1, ListNode l2,int length)
    {
        while (l1 != null)
        {
            
        }
    }
}
// @lc code=end

