using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
/*
 * @lc app=leetcode id=239 lang=csharp
 *
 * [239] Sliding Window Maximum
 */

// @lc code=start
public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) 
    {
        List<int> res = new List<int>();
        LinkedList<int> indexList = new LinkedList<int>();

        for (int i =  0; i < nums.Length; i++)
        {
            if (indexList.Any() && indexList.First.Value <= i - k) 
            {
                indexList.RemoveFirst();
            }

            while (indexList.Any() && nums[i] >= nums[indexList.Last.Value])
            {
                indexList.RemoveLast();
            }

            indexList.AddLast(i);

            if (i >= k - 1) 
            {
                res.Add(nums[indexList.First.Value]);
            }
        }
        return res.ToArray();
    }
}
// @lc code=end

