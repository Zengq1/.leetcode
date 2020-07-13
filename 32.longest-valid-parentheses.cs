using System;
using System.Linq;
/*
 * @lc app=leetcode id=32 lang=csharp
 *
 * [32] Longest Valid Parentheses
 */

// @lc code=start
public class Solution 
{
    public int LongestValidParentheses(string s) 
    {
        Stack<int> sta = new Stack<int>();
        int mostleft = -1;
        int max = 0;
        
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(') sta.Push(i);
            else if (s[i] == ')') 
            {
                if (!sta.Any()) mostleft = i;
                else 
                {
                    sta.Pop();
                    if (sta.Any()) max = Math.Max(max,i - sta.Peek());
                    else max = Math.Max(max, i - mostleft);     
                }
            }
        }
        return max;
    }
}
// @lc code=end

