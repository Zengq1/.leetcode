using System.Data;
using System.Text;
/*
 * @lc app=leetcode id=93 lang=csharp
 *
 * [93] Restore IP Addresses
 */

// @lc code=start
public class Solution 
{
    public IList<string> RestoreIpAddresses(string s) 
    {
        IList<string> res = new List<string>();
        StringBuilder sb = new StringBuilder();
        DFS(sb,res,0,s);
        return res;
    }

    private void DFS (StringBuilder sb, IList<string> res, int curIntegers, string remain)
    {
        curIntegers += 1;
        if (curIntegers == 5 && remain.Length == 0)
        {
            res.Add(sb.ToString());
            return;
        }
        else if (curIntegers ==5 && remain.Length > 0) return;
        
        for (int i = 1; i <= 3; i++)
        {
            if (i > remain.Length) break;
            string curString = remain.Substring(0,i);
            if ((curString.Length > 1 && curString.StartsWith('0')) || int.Parse(curString) > 255) break;
            if (curIntegers == 1) 
            {
                sb.Append(curString);
                DFS(sb,res,curIntegers,remain.Substring(i,remain.Length - i));
                sb.Remove(sb.Length - i, i);
            }
            else 
            {
                sb.Append('.');
                sb.Append(curString);
                DFS(sb, res,curIntegers,remain.Substring(i,remain.Length-i));
                sb.Remove(sb.Length - i - 1, i + 1);
            }
        }
    }
}
// @lc code=end

