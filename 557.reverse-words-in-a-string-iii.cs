/*
 * @lc app=leetcode id=557 lang=csharp
 *
 * [557] Reverse Words in a String III
 */

// @lc code=start
public class Solution 
{
    public string ReverseWords(string s) 
    {
        StringBuilder res = new StringBuilder();
        Stack<char> charStack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != ' ') charStack.Push(s[i]);
            if (i + 1 < s.Length && s[i + 1] == ' ')
            {
                while(charStack.Any())
                {
                    res.Append(charStack.Pop());
                }
                res.Append(s[i+1]);
            }
            if(i == s.Length - 1)
            {
                while(charStack.Any())
                {
                     res.Append(charStack.Pop());
                }
            }
        }

        return res.ToString();
    }
}
// @lc code=end

