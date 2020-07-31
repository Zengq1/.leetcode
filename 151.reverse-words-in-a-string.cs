using System.Linq;
using System.Text;
/*
 * @lc app=leetcode id=151 lang=csharp
 *
 * [151] Reverse Words in a String
 */

// @lc code=start
public class Solution 
{
    public string ReverseWords(string s) 
    {
        if (s == null || s == "") return s;
        
        string[] words = s.Split(' ');
        StringBuilder sb = new StringBuilder();
        bool hasRes = false;

        for (int i = words.Length - 1; i >= 0; i--)
        {
            if (words[i].Trim() != "")
            {
                if (!hasRes) hasRes = true;
                sb.Append(words[i].Trim());
                sb.Append(" ");
            }
        }
        if (hasRes) 
        {
            sb.Remove(sb.Length - 1,1);
            return sb.ToString();
        }
        else return "";
    }
}
// @lc code=end

