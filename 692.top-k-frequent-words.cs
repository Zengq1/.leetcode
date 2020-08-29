using System;
/*
 * @lc app=leetcode id=692 lang=csharp
 *
 * [692] Top K Frequent Words
 */

// @lc code=start
public class Solution 
{
    public IList<string> TopKFrequent(string[] words, int k) 
    {
        IList<string> res = new List<string>();
        Array.Sort(words);
        int count = 1;
        string curString = words[0];
        int max = 0;
        Dictionary<int,List<string>> rec = new Dictionary<int, List<string>>();
        for (int i = 1; i < words.Length; i++)
        {
            if (words[i] != curString)
            {
                if (!rec.ContainsKey(count)) rec[count] = new List<string>();
                rec[count].Add(curString);
                max = count > max?count:max;
                curString = words[i];
                count = 1;
                if (i == words.Length - 1)
                {
                    if (!rec.ContainsKey(count)) rec[count] = new List<string>();
                    rec[count].Add(curString);
                    max = count > max?count:max;
                }
            }
            else if (i == words.Length - 1)
            {
                count++;
                if (!rec.ContainsKey(count)) rec[count] = new List<string>();
                rec[count].Add(curString);
                max = count > max?count:max;
            }
            
            else count++;
        }

        count = 0;

        while (count < k)
        {
            for (int i = 0; i < rec[max].Count; i++)
            {
                if (count == k) break;
                else 
                {
                    res.Add(rec[max][i]);
                    count++;
                }
            }
            if (count < k)
            {
                max--;
                while (!rec.ContainsKey(max)) max--;
            }
        }

        return res;
    }
}
// @lc code=end

