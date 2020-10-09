using System.Diagnostics;
using Internal;
using System.Reflection.Metadata;
using System.Security.Authentication.ExtendedProtection;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
using System;
using System.Linq;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=47 lang=csharp
 *
 * [47] Permutations II
 */

// @lc code=start
public class Solution 
{
    public IList<IList<int>> PermuteUnique(int[] nums) 
    {
        IList<IList<int>> res = new List<IList<int>>();
        Array.Sort(nums);
        bool[] used = new bool[nums.Length];
        BackTracking(new LinkedList<int>(), used, nums,res);
        return res;
    }

    private void BackTracking (LinkedList<int> curList, bool[] used, int[] nums, IList<IList<int>> res)
    {
        if (curList.Count == nums.Length)
        {
            res.Add(curList.ToList());
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i]) continue;
            if (i > 0 && nums[i] == nums[i - 1] && used[i - 1]) continue;
            curList.AddLast(nums[i]);
            used[i] = true;
            BackTracking(curList, used, nums, res);
            curList.RemoveLast();
            used[i] = false;
        }
    }
}
// @lc code=end

