using System;
/*
 * @lc app=leetcode id=171 lang=csharp
 *
 * [171] Excel Sheet Column Number
 */

// @lc code=start
public class Solution 
{
    public int TitleToNumber(string s) 
    {
        int curP = 0;
        int res = 0;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            res += (s[i] - 'A' + 1) * (int)Math.Pow(26,curP);
            curP++;
        }
        return res;
    }
}
// @lc code=end

