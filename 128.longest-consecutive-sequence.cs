using System.ComponentModel.Design.Serialization;
using System.ComponentModel;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection.Metadata;
using System.Net.Mail;
using System.Security.Authentication.ExtendedProtection;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;
using System.Globalization;
/*
 * @lc app=leetcode id=128 lang=csharp
 *
 * [128] Longest Consecutive Sequence
 */

// @lc code=start
public class Solution 
{
    public int LongestConsecutive(int[] nums) 
    {
        int max = 0;
        Dictionary<int,int> lDic = new Dictionary<int,int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int curNum = nums[i];
            if (!lDic.ContainsKey(curNum))
            {
                if (!lDic.ContainsKey(curNum + 1) && !lDic.ContainsKey(curNum - 1))
                {
                    lDic[curNum] = 1;
                    max = max > lDic[curNum]? max: lDic[curNum];
                }
                else if (!lDic.ContainsKey(curNum + 1)) // at the end
                {
                    lDic[curNum] = lDic[curNum - 1] + 1;
                    lDic[curNum - lDic[curNum - 1]] = lDic[curNum];
                    max = max > lDic[curNum]? max: lDic[curNum];
                }
                else if (!lDic.ContainsKey(curNum - 1)) //at front 
                {
                    lDic[curNum] = lDic[curNum + 1] + 1;
                    lDic[curNum + lDic[curNum + 1]] = lDic[curNum];
                    max = max > lDic[curNum]? max: lDic[curNum];
                }
                else //in the middle
                {
                    int tL = lDic[curNum - 1] + lDic[curNum + 1] + 1;
                    lDic[curNum - lDic[curNum - 1]] = tL;
                    lDic[curNum + lDic[curNum + 1]] = tL;
                    lDic[curNum] = tL;
                    max = max > tL? max:tL;
                }
            }
        }

        return max;
    }
}
// @lc code=end

