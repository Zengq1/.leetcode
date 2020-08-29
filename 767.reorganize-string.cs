using Internal;
using System.Text;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System;
/*
 * @lc app=leetcode id=767 lang=csharp
 *
 * [767] Reorganize String
 */

// @lc code=start
public class Solution
 {
    public string ReorganizeString(string S) 
    {
        char[] charArray = new char[26];
        char[] res = new char[S.Length];
        for (int i = 0; i < 26;i++) charArray[i] = (char)(i + 'a');

        int[] charNum = new int[26];
        foreach (char c in S)charNum[c - 'a']++;

        Array.Sort(charNum,charArray);

        int numOfMax = 0;
        int max = charNum[25];
        for (int i = 25; i >= 0 && charNum[i] == max; i--) numOfMax++;

        //set up the space 
        int space = numOfMax == 1? 2:numOfMax;
        if ((max - 1) * space + numOfMax > S.Length) return "";
        int startIndex = numOfMax - 1;
        int charIndex = 25;

        //fill the max fre char first
        for (int i = numOfMax; i > 0; i--)
        {
            res[startIndex] = charArray[charIndex];
            charNum[charIndex]--;
            startIndex--;
            charIndex--;
        }

        startIndex = numOfMax + space - 1;
        charIndex = 25;

        if (charNum[charIndex] != 0)
        {
            while (startIndex >= numOfMax)
            {
                for (int curIndex = startIndex; curIndex < S.Length; curIndex += space)
                {
                    res[curIndex] = charArray[charIndex];
                    Console.WriteLine(curIndex);
                    charNum[charIndex]--;
                    if (charNum[charIndex] == 0) charIndex--;
                }
                startIndex--;
            }
        }
        return string.Join("",res);
    }
}
// @lc code=end

