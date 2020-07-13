using System.Collections.Generic;
/*
 * @lc app=leetcode id=234 lang=csharp
 *
 * [234] Palindrome Linked List
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
    public bool IsPalindrome(ListNode head) 
    {
        if (head == null || head.next == null) return true;
        ListNode slowPtr = head;
        ListNode fastPtr = head;

        while (fastPtr != null)
        {
            slowPtr = slowPtr.next;
            fastPtr = fastPtr.next.next;
        }

        slowPtr = Rev(slowPtr);
        while (slowPtr != null)
        {
            if (slowPtr.val != head.val) return false;
            slowPtr = slowPtr.next;
            head = head.next;
        }
        return true;
    }

    private ListNode Rev(ListNode cur)
    {
        ListNode pre = null;
        while (cur != null)
        {
            ListNode next = cur.next;
            cur.next = pre;
            pre = cur;
            cur = next;   
        }
        return pre;
    }
}
// @lc code=end

