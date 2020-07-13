using System;
/*
 * @lc app=leetcode id=53 lang=csharp
 *
 * [53] Maximum Subarray
 */

// @lc code=start
public class Solution {
    public int MaxSubArray(int[] nums) 
    {
        //edge case
        if (nums == null || nums.Length ==0) return 0;

        //crete 2d array to hold dp
        int nLength = nums.Length;
        int[,]dp = new int[nLength,nLength];

        int max = nums[0];

        for (int j = 0; j < nLength; j++)
        {
            for (int i = j; i >= 0; i--)
            {
                if (i == j)
                {
                    dp[i,j] = nums[i];
                    max = Math.Max(max, nums[i]);
                }
                else
                {
                    dp[i,j] = dp[i,i] + dp[i+1,j];
                }
                max = Math.Max(max, dp[i,j]);
            }
        }

        return max;
    }
}
// @lc code=end

