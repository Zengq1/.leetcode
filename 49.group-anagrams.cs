using System.ComponentModel;
using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=49 lang=csharp
 *
 * [49] Group Anagrams
 */

// @lc code=start
public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) 
    {
        IList<IList<string>> res = new List<IList<string>>();
        Dictionary<string,int> dic = new Dictionary<string,int>();
        int curIndex = 0;

        foreach (string s in strs)
        {
            string temp = OrderString(s);
            if (!dic.ContainsKey(temp))
            {
                dic[temp] = curIndex;
                res.Add(new List<string>());
                res[curIndex].Add(s);
                curIndex++;
            }
            else
            {
                res[dic[temp]].Add(s);
            }
        }

        return res;
    }

    private string OrderString(string s)
    {
        char[] chars = s.ToArray();
        Array.Sort(chars);
        return new string(chars);
    }
}
// @lc code=end

