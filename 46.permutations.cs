using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.ComponentModel.Design.Serialization;
using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System.Globalization;
/*
 * @lc app=leetcode id=46 lang=csharp
 *
 * [46] Permutations
 */

// @lc code=start
public class Solution 
{
    public IList<IList<int>> Permute(int[] nums) 
    {
        IList<IList<int>> res = new List<IList<int>>();
        int l = nums.Length;
        bool[] usedNum = new bool[l];
        int[] tempArray = new int[l];
        GetRes(usedNum,tempArray,0,nums,res,l);
        return res;
    }

    private void GetRes (bool[] usedNum, int[] curArray, int curIndex, int[] nums,IList<IList<int>> res, int targetLength)
    {
        if (curIndex == targetLength) res.Add(curArray.ToList());
        else
        {
            for (int i = 0; i < targetLength; i++)
            {
                if (usedNum[i] == false)
                {
                    curArray[curIndex] = nums[i];
                    usedNum[i] = true;
                    GetRes(usedNum,curArray,curIndex + 1, nums,res,targetLength);
                    usedNum[i] = false;
                }
            }
        }  
    }
}
// @lc code=end

