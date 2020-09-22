using System;
using System.Security.AccessControl;
/*
 * @lc app=leetcode id=516 lang=csharp
 *
 * [516] Longest Palindromic Subsequence
 */

// @lc code=start
public class Solution 
{
    int[,] dp;
    int length;
    string s;

    public int LongestPalindromeSubseq(string s) 
    {
        dp = new int[s.Length,s.Length];
        length = s.Length;
        this.s = s;

        //pre process length 1 palindrome must be 1
        for (int i = 0; i < s.Length; i++) dp[i,i] = 1;
        
        for (int l = 2; l <= s.Length; l++)
        {
            GetPali(l);
        }

        return dp[0,length - 1];
    }

    public void GetPali(int l)
    {
        int f = 0;
        int b = l - 1;
        while (b < length)
        {
            if (s[f] == s[b])
            {
                if (l == 2) dp[f,b] = 2;
                else 
                {
                    dp[f,b] = 2 + dp[f + 1, b - 1];
                }
            }
            else
            {
                dp[f,b] = Math.Max(dp[f,b - 1], dp[f + 1,b]);
            }
            f++;
            b++;
        }
    }
}
// @lc code=end

