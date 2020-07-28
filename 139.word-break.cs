using System.Reflection.Metadata;
using System.Security;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=139 lang=csharp
 *
 * [139] Word Break
 */

// @lc code=start
public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) 
    {
        //edge case
        if (s.Length == 0) return true;
        if (wordDict.Count == 0) return false;

        bool[] res = new bool[s.Length + 1];

        HashSet<string> dic = new HashSet<string>();
        foreach (string st in wordDict) dic.Add(st);

        res[0] = true;
        //i represent current index 
        for (int i = 0; i < s.Length; i++)
        {
            //j represent the front substring length ....[*....i].... from * to i is j length
            for (int j = 0; j <= i; j++)
            {
                //if dictionary has the current substring then we check if the previous substring is valid
                if (dic.Contains(s.Substring(i - j, j + 1)))
                {
                    //previous substring is also valid, the current i is true;
                    //since the res array has one more element at the beginning which represents empty string
                    //so the previous substring need not to - 1 and current i index needs to add 1
                    if (res[i - j] == true)
                    {
                        res[i + 1] = true;
                    }
                }
            }
        }

        return res[res.Length - 1];
    }
}
// @lc code=end

