using System;
/*
 * @lc app=leetcode id=41 lang=csharp
 *
 * [41] First Missing Positive
 */

// @lc code=start
public class Solution 
{
    public int FirstMissingPositive(int[] nums) 
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= 0) nums[i] = int.MaxValue;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            int index = Math.Abs(nums[i]) - 1;
            if (index < nums.Length) nums[index] = (-1) * Math.Abs(nums[index]);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0) return i + 1;
        }
        return nums.Length + 1;
    }
}
// @lc code=end

