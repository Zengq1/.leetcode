/*
 * @lc app=leetcode id=844 lang=csharp
 *
 * [844] Backspace String Compare
 */

// @lc code=start
public class Solution {
    public bool BackspaceCompare(string S, string T) 
    {
        StringBuilder se = new StringBuilder();
        StringBuilder te = new StringBuilder();

        for (int i = 0; i < S.Length; i++)
        {
            if (S[i] != '#') se.Append(S[i]);
            else 
            {
                if (se.Length > 0) se.Remove(se.Length - 1,1);
            }
        }

        for (int i = 0; i < T.Length; i++)
        {
            if (T[i] != '#') te.Append(T[i]);
            else 
            {
                if (te.Length > 0) te.Remove(te.Length - 1,1);
            }
        }

        return se.ToString() == te.ToString();
    }
}
// @lc code=end

