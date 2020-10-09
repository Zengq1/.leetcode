using System.Collections;
using System.ComponentModel;
using System.Data;
using Internal;
using System.Net.Mail;
using System.Collections.Generic;
using System;
/*
 * @lc app=leetcode id=39 lang=csharp
 *
 * [39] Combination Sum
 */

// @lc code=start
public class Solution 
{
    IList<IList<int>> res;
    public IList<IList<int>> CombinationSum(int[] candidates, int target) 
    {
        res = new List<IList<int>>();
        Array.Sort(candidates);
        GetPos(new List<int>(), target,candidates,0);
        return res;
    }

    private void GetPos (List<int> curList, int remain, int[] candidates, int curIndex)
    {
        if (remain == 0) 
        {
            res.Add(curList);
            return;
        }
        if (curIndex == candidates.Length) return;
        if (candidates[curIndex] > remain)
        {
            return;
        }
        List<int> l = new List<int>(curList);
        int curNum = candidates[curIndex];
        curIndex++;
        
        //not using the cur num
        GetPos(l,remain,candidates,curIndex);

        while (remain > 0)
        {
            l.Add(curNum);
            remain -= curNum;   
            GetPos(l,remain,candidates,curIndex);   
        }
    }
}
// @lc code=end

