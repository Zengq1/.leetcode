using System.Collections.Generic;
using System.Linq;
/*
 * @lc app=leetcode id=443 lang=csharp
 *
 * [443] String Compression
 */

// @lc code=start
public class Solution 
{
    public int Compress(char[] chars) 
    {
        if (chars.Length == 0 || chars == null) return 0;
        if (chars.Length == 1) return 1;

        int res = 0;
        int continueCount = 0;
        char preChar =chars[0];
        int insertIndex = 0;
        int stringCount = 0;
        StringBuilder digitString = new StringBuilder();

        for (int i = 0; i < chars.Length; i ++)
        {
            if (chars[i] == preChar)
            {
                continueCount++;

                //last case
                if(i != chars.Length - 1) continue;
            }
            chars[insertIndex] = preChar;
            insertIndex++;
            res++;

            if (continueCount > 1)
            {
                digitString.Append(continueCount.ToString());
                for (int j = 0; j < digitString.Length; j++)
                {
                    chars[insertIndex] = digitString[j];
                    insertIndex++;
                    res++;
                }
                digitString.Clear();
                continueCount = 1;
            }

            if(i == chars.Length - 1 && chars[i] != preChar)
            {
                chars[insertIndex] = chars[i];
                res++;
            }
            
            preChar = chars[i];
        }
        
        return res;
    }
}

// a a b c c c d
// @lc code=end

