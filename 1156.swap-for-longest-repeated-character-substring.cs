using System.Text;
/*
 * @lc app=leetcode id=1156 lang=csharp
 *
 * [1156] Swap For Longest Repeated Character Substring
 */

// @lc code=start
public class Solution 
{
    public int MaxRepOpt1(string text) 
    {
        int max = 1;
        int start = 0;

        int[] seen = new int[26];
        foreach (char c in text) seen[c - 'a']++;

        while (start < text.Length - 1)
        {
            int end = start + 1;
            bool isSwap = false;
            char cur = text[start];
            int count = 1;
            int newStart = start;

            while (end < text.Length && ((text[end] == text[start]||!isSwap) && count < seen[cur - 'a']))
            {
                if (text[end] != cur)
                {
                    isSwap = !isSwap;
                    newStart = end;
                }
                count ++;
                end++;
            }
            if (newStart == start) start++;
            else start = newStart;
            max = count>max?count:max;
        }
        
        return max;
    }
}

//a b a b a
//0   2   3

//a a a a b a b b b b a c

// @lc code=end

