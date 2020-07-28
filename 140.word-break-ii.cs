using System.Runtime.InteropServices;
using System.Security;
using System.Runtime.Serialization;
using System.Collections.Concurrent;
using System.Reflection.Emit;
using System.Data;
using Internal;
using System.Net.Sockets;
using System.ComponentModel.Design.Serialization;
using System.Reflection.Metadata;
using System.Net;
using System.IO;
using System;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=140 lang=csharp
 *
 * [140] Word Break II
 */

// @lc code=start
public class Solution 
{
    HashSet<string> words;
    public IList<string> WordBreak(string s, IList<string> wordDict) 
    {
        words = new HashSet<string>();
        foreach (string st in wordDict)  words.Add(st);
        Dictionary<string,IList<string>> dic = new Dictionary<string,IList<string>>(); 
        IList<string> res = new List<String>();
        res = GetPossible(s,dic);
        return res;
    }

    private IList<string> GetPossible(string s, Dictionary<string,IList<string>> seen)
    {
        if (seen.ContainsKey(s))return seen[s];
        if (s.Length == 0)  return null;
        IList<string> res = new List<string>();
        //i is the length of the substring
        for (int i = 1; i <= s.Length ; i++)
        {
            string temp = s.Substring(0,i);

            IList<string> part = new List<string>();
            if (words.Contains(temp))
            {
                part = GetPossible(s.Substring(i),seen);
                if (part == null)
                {
                    Console.WriteLine(temp);
                    res.Add(temp);
                }
                else
                {
                    foreach (string st in part)
                    {
                        res.Add(temp + " " + st);                    
                    }
                }
            }
        }
        seen.Add(s,res);
        return res;
    }
}

/*
sustring by different length, and use recusion to keep calling the method to get the possible combination
    a a a b b b c c     
    a
    a a
    a a a
    a a a b
    a a a b b
    a a a b b b
    a a a b b b c
    a a a b b b c c
*/

// @lc code=end

