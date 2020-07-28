using System;
/*
 * @lc app=leetcode id=621 lang=csharp
 *
 * [621] Task Scheduler
 */

// @lc code=start
public class Solution 
{
    public int LeastInterval(char[] tasks, int n) 
    {
        if (n < 1) return tasks.Length;
        int[] taskFre = new int[26];
        foreach (char c in tasks) taskFre[c - 'A'] ++;
        Array.Sort(taskFre);
        int maxFre = taskFre[25] - 1; //since the lastone doesn't need any more space after it
        int maxSpace = maxFre * n;
        for (int i = 24; i >= 0 && taskFre[i] > 0; i--)
        {
            maxSpace -= Math.Min(maxFre,taskFre[i]);
        }
        //maxspace will be negative when some tasks have only one frequence
        return maxSpace > 0? maxSpace + tasks.Length:tasks.Length;
    }
}
// @lc code=end

