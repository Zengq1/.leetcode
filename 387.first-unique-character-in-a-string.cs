using System.Collections.Generic;
using System.Linq;
/*
 * @lc app=leetcode id=387 lang=csharp
 *
 * [387] First Unique Character in a String
 */

// @lc code=start
public class Solution 
{
    public int FirstUniqChar(string s) 
    { 
         if (s.Length == 0 || s == null) return -1;
        if (s.Length == 1) return 0;
        
        Dictionary<char, List<int>> seen = new Dictionary<char,List<int>>();
        for(int i = 0; i < s.Length; i ++)
        {
            if (!seen.ContainsKey(s[i]))
            {
                seen.Add(s[i],new List<int>{i,1});
            }
            else
            {
                seen[s[i]][1]++;
            }
        } 
        for (int i = 0; i < seen.Count; i ++)
        {
            if (seen.ElementAt(i).Value[1] == 1) return seen.ElementAt(i).Value[0] ;
        }

        return -1;
    }
}
// @lc code=end

