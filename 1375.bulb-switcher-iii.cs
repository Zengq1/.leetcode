using System;
/*
 * @lc app=leetcode id=1375 lang=csharp
 *
 * [1375] Bulb Switcher III
 */

// @lc code=start
public class Solution 
{
    public int NumTimesAllBlue(int[] light) 
    {
        int res = 0;
        int mostRight = 0;
        int curLightNum = 0;
        
        foreach (int n in light)
        {
            mostRight = Math.Max(n,mostRight);
            curLightNum += 1;
            if (curLightNum == mostRight) res++;
        }

        return res;
    }
}
// @lc code=end

