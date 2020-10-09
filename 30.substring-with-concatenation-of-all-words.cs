using System.Reflection.Metadata;
using System.Net.NetworkInformation;
using System.Threading;
using System.Collections;
using System.Security.Authentication.ExtendedProtection;
using System.ComponentModel;
using System.Net.Sockets;
using System.Net;
using System.Collections.Generic;
using System.Security.Principal;
using System.IO;
/*
 * @lc app=leetcode id=30 lang=csharp
 *
 * [30] Substring with Concatenation of All Words
 */

// @lc code=start
public class Solution {
    public IList<int> FindSubstring(string s, string[] words) 
    {
        IList<int> res = new List<int>();
        Dictionary<string,int> numDic = new Dictionary<string,int>();
        int wordLength = words[0].Length;
        int targetLength = words.Length * wordLength;
        if (s.Length < 1 || words.Length < 1 || s.Length < targetLength) return res;

        foreach (string st in words) 
        {
            if (!numDic.ContainsKey(st)) numDic[st] = 0;
            numDic[st]++;
        }
        for (int i = 0; i <= s.Length - targetLength; i++)
        {
            Dictionary<string,int> avaliable = new Dictionary<string,int>(numDic);
            for (int j = i; j <= s.Length - wordLength; j++)
            {
                if (avaliable.ContainsKey(s.Substring(j,wordLength)))
                {
                    avaliable[s.Substring(j,wordLength)]--;
                   
                    if (avaliable[s.Substring(j,wordLength)] == 0) 
                    {
                        avaliable.Remove(s.Substring(j,wordLength));
                        if (!avaliable.Any())
                        {
                            res.Add(i);
                            break;
                        }
                    }
                    j += wordLength - 1;
                }
                else break;
            }
        }

        return res;
    }
}
// @lc code=end

