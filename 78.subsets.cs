using System.Reflection.Metadata;
using System.Linq;
/*
 * @lc app=leetcode id=78 lang=csharp
 *
 * [78] Subsets
 */

// @lc code=start
public class Solution {
    public IList<IList<int>> Subsets(int[] nums) 
    {
        IList<IList<int>> res = new List<IList<int>>();
        IList<int> currentList = new List<int>();
        GetSubset(nums, 0, currentList, res);

        return res;
    }

    private void GetSubset (int[] nums, int currentIndex, IList<int> currentList, IList<IList<int>> res)
    {
        if (currentIndex == nums.Length)
        {
            res.Add(currentList);
            
            return;
        }

        GetSubset(nums, currentIndex + 1, currentList, res);
        
        IList<int> tempList = new List<int>(currentList);
        currentList.Add(nums[currentIndex]);   
        GetSubset(nums, currentIndex + 1, tempList,res);
    }
}
// @lc code=end

