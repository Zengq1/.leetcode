using Internal;
using System;
using System.Reflection.Metadata;
/*
 * @lc app=leetcode id=42 lang=csharp
 *
 * [42] Trapping Rain Water
 */

// @lc code=start
public class Solution 
{
    public int Trap(int[] height) 
    {
        //brute force
        int res = 0;
        int l = 0; 
        int r = 1;
        while (r < height.Length)
        {
            if (height[r] < height[l])
            {
                if (r == height.Length- 1 && l != r - 1)
                {
                    r = l + 1;
                    int curMax = height[r];
                    int maxIndex = -1;
                    while (r < height.Length)
                    {
                        r++;
                        if (height[r] >= curMax) 
                        {
                            curMax = height[r];
                            maxIndex = r;
                        }
                    }

                    if (maxIndex == - 1)
                    {
                        l++;
                        r = l;
                    }
                    else
                    {
                        for (int j = l + 1; j <= maxIndex - 1; j++) res+= curMax - height[j]; 
                        l = maxIndex;
                        r = l;
                    }
                }
                r++;
            }
            else
            {
                if (r != l + 1)
                {
                    for (int j = l + 1; j <= r - 1; j++)
                    {
                        int minSide = Math.Min(height[l],height[r]);
                        res+= minSide - height[j]; 
                    }
                }
                l = r;
                r = l + 1;
            }
        }

        return res;
    }
}
// @lc code=end

