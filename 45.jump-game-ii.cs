using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
/*
 * @lc app=leetcode id=45 lang=csharp
 *
 * [45] Jump Game II
 */

// @lc code=start
public class Solution 
{
    public int Jump(int[] nums) 
    {
        if (nums[0] == 0 || nums.Length == 1) return 0;
        int curIndex = 0; //record what's the current index of the nums array
        int jump = 0; //record how many jumps
        int nextIndex = 0; //record the next index the curIndex will jump to
        int maxIndex = 0; //indicate the max index it can jump from next index
        int length = nums.Length; //length of the array

        while (curIndex < length)
        {
            nextIndex = nums[curIndex] + curIndex;
            jump++; // assume jumpe already
            if (nextIndex >= length - 1) return jump;
            else //if not exceed the array length , check current plus next to get furthest jump
            {
                for (int i = nextIndex; i > curIndex; i--)
                {
                    if (nums[i] + i > maxIndex)
                    {
                        maxIndex = nums[i] + i;
                        nextIndex = i;
                    }
                }
                curIndex = nextIndex;
            }
        }
        return jump;
    }
}
// @lc code=end

