/*
 * @lc app=leetcode id=206 lang=csharp
 *
 * [206] Reverse Linked List
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
    public ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null) return head;

        ListNode pre = null;
        while (head.next != null)
        {
            ListNode nextNode = head.next;
            head.next = pre;
            pre = head;
            head = nextNode;
            if (head.next == null)
            {
                head.next = pre;
                break;
            }
        }
        return head;
    }
}
// @lc code=end

