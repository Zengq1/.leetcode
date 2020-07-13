/*
 * @lc app=leetcode id=138 lang=csharp
 *
 * [138] Copy List with Random Pointer
 */

// @lc code=start
/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution 
{
    public Node CopyRandomList(Node head) 
    {
        if (head == null) return null;
        Node dummy = new Node(-1);
        dummy.next = head;
        Node res = new Node(-1);
        Node cur = res; 
        Dictionary<Node,Node> dic = new Dictionary<Node, Node>();

        while (dummy.next != null)
        {
            if (!dic.ContainsKey(dummy.next))
            {
                dic.Add(dummy.next,new Node(dummy.next.val));
            }
            cur.next = dic[dummy.next];
            
            if (dummy.next.random != null)
            {
                if (!dic.ContainsKey(dummy.next.random))
                {
                    dic.Add(dummy.next.random,new Node(dummy.next.random.val));
                }
                cur.next.random = dic[dummy.next.random];
            }
            
            dummy = dummy.next;
            cur = cur.next;
        }

        return res.next;
    }
}
// @lc code=end

