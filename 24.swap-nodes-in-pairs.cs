/*
 * @lc app=leetcode id=24 lang=csharp
 *
 * [24] Swap Nodes in Pairs
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
    public ListNode SwapPairs(ListNode head) 
    {
        if (head == null || head.next == null) return head;
        ListNode dummy = new ListNode(-1);
        dummy.next = head;
        ListNode current = dummy;
        while (current.next != null && current.next.next != null)
        {
            ListNode temp = current.next;
            current.next = temp.next;
            temp.next = temp.next.next;
            current.next.next = temp;
            current = current.next.next;
        }
        return dummy.next;
    }
}
// @lc code=end

