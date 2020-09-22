/*
 * @lc app=leetcode id=88 lang=csharp
 *
 * [88] Merge Sorted Array
 */

// @lc code=start
public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) 
    {
        int i1 = m - 1, i2 = n - 1;
        for (int i = nums1.Length - 1; i >= 0; i--)
        {
            if (i1 >= 0 && i2 >= 0)
            {
                if (nums1[i1] > nums2[i2]) 
                {
                    nums1[i] = nums1[i1];
                    i1 --;
                }
                else 
                {
                    nums1[i] = nums2[i2];
                    i2 --;
                }
            }
            else if (i1 < 0)
            {
                nums1[i] = nums2[i2];
                i2 --;
            }
        }
    }
}
// @lc code=end

