using System.Xml;
using System.Security.AccessControl;
using System.Data.Common;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
/*
 * @lc app=leetcode id=312 lang=csharp
 *
 * [312] Burst Balloons
 */

// @lc code=start
public class Solution 
{
    int[,] dp;
    public int MaxCoins(int[] nums) 
    {
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 0) return 0;
        dp = new int[nums.Length,nums.Length];

        for (int subLength = 1; subLength <= nums.Length; subLength++)
        {
            FillDP(subLength, nums);
        }
        
        return dp[0,dp.GetLength(1) - 1];
    }

    private void FillDP(int length,int[] nums)
    {
        int sS = 0;
        int sE = length - 1;
        while (sE < dp.GetLength(0))
        {
            int max = 0;
            for (int i = sS; i <= sE; i++)
            {
                int lMax = 0;
                int rMax = 0;

                if (length != 1)
                {
                    if (i != 0)lMax = dp[sS,i - 1];
                    if (i != dp.GetLength(0) - 1) rMax = dp[i + 1, sE];
                }

                int l = sS - 1 < 0? 1: nums[sS - 1];
                int r = sE + 1 >= dp.GetLength(0)? 1: nums[sE + 1];
                
                int num = lMax + rMax + (l * nums[i] * r);            
                if (num > max) max = num;
            }
            dp[sS,sE] = max;  
            sS++;
            sE++;
        }
    }
}
// @lc code=end

