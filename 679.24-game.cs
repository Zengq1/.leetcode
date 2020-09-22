using System;
using System.Dynamic;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
/*
 * @lc app=leetcode id=679 lang=csharp
 *
 * [679] 24 Game
 */

// @lc code=start
public class Solution 
{
    HashSet<double> set = new HashSet<double>();

    public bool JudgePoint24(int[] nums) 
    {
        List<double> l = new List<double>();
        for (int i = 0; i < 4; i++) l.Add((double)nums[i]);
        BFS(l);
        foreach (double n in set)
        {
            if (Math.Abs(n - 24) < 0.0001) return true; 
        }
        return false;
    }

    private void BFS(List<double> nums)
    {
        if (nums.Count == 1 && !set.Contains(nums[0])) set.Add(nums[0]);

        for (int i = 0; i < nums.Count; i++)
        {
            for(int j = 0; j < nums.Count; j++)
            {
               if (i == j) continue;
                List<double> newList = new List<double>(nums);
                double fn = newList[i], sn = newList[j];
                newList.Remove(fn);
                newList.Remove(sn);

                newList.Add(fn + sn);
                BFS(newList);
                newList.RemoveAt(newList.Count - 1);
                newList.Add(fn - sn);
                BFS(newList);
                newList.RemoveAt(newList.Count - 1);
                newList.Add(fn * sn);
                BFS(newList);
                newList.RemoveAt(newList.Count - 1);
                if(sn != 0) 
                {
                    newList.Add(fn/sn);
                    BFS(newList);
                }
            }
        }
    }
}
// @lc code=end

