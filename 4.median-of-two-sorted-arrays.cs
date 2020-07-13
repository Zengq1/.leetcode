using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=4 lang=csharp
 *
 * [4] Median of Two Sorted Arrays
 */

// @lc code=start
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
    {
        //keep nums1 as the smaller one
        if (nums1.Length > nums2.Length) return FindMedianSortedArrays(nums2,nums1);
        bool isEven = (nums1.Length + nums2.Length)%2==0;
        int k = (nums1.Length + nums2.Length)/2;
        if (nums1.Length == 0) return isEven? (nums2[k] + nums2[k - 1])/2d:nums2[k];
        int startCut = 0, endCut = nums1.Length;
        int l1 = 0, l2 = 0, r1 = 0, r2 = 0;

        while (startCut <= endCut)
        {
            int cut1 = (startCut + endCut) / 2;
            int cut2 = k - cut1;
            l1 = cut1 <= 0? int.MinValue:nums1[cut1 - 1];
            l2 = cut2 <= 0? int.MinValue:nums2[cut2 - 1];
            r1 = cut1 >= nums1.Length? int.MaxValue:nums1[cut1];
            r2 = cut2 >= nums2.Length? int.MaxValue:nums2[cut2];
            if (Math.Max(l1,l2) <= Math.Min(r1,r2)) return isEven? (Math.Max(l1,l2) + Math.Min(r1,r2))/2d : Math.Min(r1,r2);

            if (l1 < r2) startCut = cut1 + 1;
            else if (l1 > r2) endCut = cut1 - 1; 
        }

        return -1;

    }
    //[1] [3,4|5|6,7,8]
    //
    //[1,3,5]  [2,4]
}
// @lc code=end

