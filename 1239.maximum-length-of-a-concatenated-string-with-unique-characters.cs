using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System;
/*
 * @lc app=leetcode id=1239 lang=csharp
 *
 * [1239] Maximum Length of a Concatenated String with Unique Characters
 */

// @lc code=start
public class Solution {
    public int MaxLength(IList<string> arr) 
    {
        int max = 0;

        GetMaxDFS(arr, 0, "", max);

        return max;    
    }

    private void GetMaxDFS(IList<string> arr, int currentIndex, string currentString, int max )
    {
        if (currentIndex == arr.Count && GetUniqueLength(currentString) > max)
        {
            max = currentString.Length;
            return;
        }
        if (currentIndex == arr.Count) return;

        GetMaxDFS(arr, currentIndex + 1, currentString, max);
        GetMaxDFS(arr, currentIndex + 1, currentString + arr[currentIndex], max);
    } 

    private int GetUniqueLength(string s)
    {
        int[] tempArray = new int[26];
        foreach (char c in s)
        {
            if (tempArray[c - 'a'] ++ > 0)
            {
                return -1;
            }
        }
        return s.Length;
    }
}
// @lc code=end

