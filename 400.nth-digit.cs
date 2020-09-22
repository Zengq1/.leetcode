using System.Diagnostics;
/*
 * @lc app=leetcode id=400 lang=csharp
 *
 * [400] Nth Digit
 */

// @lc code=start
public class Solution 
{
    public int FindNthDigit(int n) 
    {
        //n under 10 has 9 number, under 100 and more than 9 has 90 number
        long l = 1, count = 9, start = 1;
        long nth = (long)n;
        while (nth > l * count)
        {
            nth -= l*count;
            l++;
            count *= 10;
            start *= 10;
        }
        start += (nth - 1)/l;
        string r = start.ToString();
        int res = (int)(nth - 1)%(int)l;

        return r[res] - '0';
    }
}
// @lc code=end

