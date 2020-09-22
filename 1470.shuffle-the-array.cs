/*
 * @lc app=leetcode id=1470 lang=csharp
 *
 * [1470] Shuffle the Array
 */

// @lc code=start
public class Solution 
{
    public int[] Shuffle(int[] nums, int n) 
    {
        int[] res = new int[nums.Length];
        
        int i = 0; 
        int insertIndex = 0;
        while (n < nums.Length)
        {
            res[insertIndex] = nums[i];
            i++;
            insertIndex++;
            res[insertIndex] = nums[n];
            insertIndex++;
            n++;
        }

        return res;
    }
}
// @lc code=end

