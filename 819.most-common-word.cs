using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
/*
 * @lc app=leetcode id=819 lang=csharp
 *
 * [819] Most Common Word
 */

// @lc code=start
public class Solution 
{
    public string MostCommonWord(string paragraph, string[] banned) 
    {
        Dictionary<string,int> dic = new Dictionary<string,int>();
        HashSet<string> ban = new HashSet<string>();
        HashSet<char> breakChar = new HashSet<char>{' ','!','?',',',';','.','\''};
        int l = paragraph.Length;
        int max = 0;
        string res = "";

        foreach (string s in banned)
        {
            ban.Add(s);
        }
        
        int fp = 0, sp = 0;
        while (sp < l)
        {
            if (breakChar.Contains(paragraph[sp]))
            {
                sp++;
                fp = sp;
            }
            while (fp <= l)
            {
                if (fp < l && !breakChar.Contains(paragraph[fp])) fp++;
                else 
                {
                    string cur = paragraph.Substring(sp,fp - sp).ToLower();
                    if (!ban.Contains(cur))
                    {
                        if (dic.ContainsKey(cur)) dic[cur]++;
                        else dic[cur] = 1;
                        if (dic[cur] > max) 
                        {
                            max = dic[cur];
                            res = cur;
                        }
                    }
                    sp = fp + 1;
                    break;  
                }
            }
            fp = sp;
        }

        return res;
    }
}
// @lc code=end

