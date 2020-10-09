using System.Globalization;
/*
 * @lc app=leetcode id=462 lang=csharp
 *
 * [462] Minimum Moves to Equal Array Elements II
 */

// @lc code=start
public class Solution 
{
    public int MinMoves2(int[] nums) 
    {
        Array.Sort(nums);
        int targetI = nums.Length/2; 
        int count = 0;
    
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == nums[targetI]) continue;
            count += Math.Abs(nums[i] - nums[targetI]);
        }
        return count;
    }
}
// @lc code=end

