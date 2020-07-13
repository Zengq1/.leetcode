using System.Linq;
using System.Security.AccessControl;
/*
 * @lc app=leetcode id=232 lang=csharp
 *
 * [232] Implement Queue using Stacks
 */

// @lc code=start
public class MyQueue {

    Stack<int> sta;
    Stack<int> revSta;

    /** Initialize your data structure here. */
    public MyQueue() {
        sta = new Stack<int>();
        revSta = new Stack<int>();
    }
    
    /** Push element x to the back of queue. */
    public void Push(int x) {
        revSta.Push(x);
    }
    
    /** Removes the element from in front of queue and returns that element. */
    public int Pop() {
        while (revSta.Any())
        {
            int temp = revSta.Pop();
            sta.Push(temp);
        }
        int popNum = sta.Pop();
        while (sta.Any())
        {
            int temp = sta.Pop();
            revSta.Push(temp);
        }

        return popNum;
    }
    
    /** Get the front element. */
    public int Peek() {
         while (revSta.Any())
        {
            int temp = revSta.Pop();
            sta.Push(temp);
        }
        int peekNum = sta.Peek();
        while (sta.Any())
        {
            int temp = sta.Pop();
            revSta.Push(temp);
        }
        return peekNum;
    }
    
    /** Returns whether the queue is empty. */
    public bool Empty() {
        return !revSta.Any();
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
// @lc code=end

