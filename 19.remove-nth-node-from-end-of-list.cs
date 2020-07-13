using System.Linq;
/*
 * @lc app=leetcode id=19 lang=csharp
 *
 * [19] Remove Nth Node From End of List
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
    public ListNode RemoveNthFromEnd(ListNode head, int n) 
    {
        ListNode dummy = new ListNode();
        dummy.next = head;
        Stack<ListNode> sta = new Stack<ListNode>(); 

        while(head != null)
        {
            sta.Push(head);
            head = head.next;
        }

        if (n - 1 > sta.Count) return dummy.next;

        while (n > 0)
        {
            ListNode temp = sta.pop();
            n--;

            if(n == 0)
            {
                ListNode preNode = sta.pop();
                preNode.next = temp.next;
            }
        }

        return dummy.next;
    }
}
// @lc code=end

