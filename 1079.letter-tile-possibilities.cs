using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Globalization;
/*
 * @lc app=leetcode id=1079 lang=csharp
 *
 * [1079] Letter Tile Possibilities
 */

// @lc code=start
public class Solution 
{
    public int NumTilePossibilities(string tiles) 
    {
        if (tiles.Length < 2) return tiles.Length;

        int[] charArray = new int[26];
        int numOfChar = 0;

        //record the number of each char
        foreach (char c in tiles)
        {
            if (charArray[c - 'A'] == 0) numOfChar++;
            charArray[c - 'A']++;
        }

        return BFS(charArray);
    }
    
    private int BFS (int[] charArray)
    {
        int res = 0;
        for (int i = 0; i < 26; i++)
        {
            if (charArray[i] != 0)
            {
                charArray[i]--;
                res++;
                res += BFS(charArray);
                charArray[i]++;
            }
        }

        return res;
    }
}
// @lc code=end

