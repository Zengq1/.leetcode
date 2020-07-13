using System.Runtime.InteropServices;
using System.Data.SqlTypes;
using System.Reflection;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;
using Internal;
using System.Reflection.Metadata;
using System.ComponentModel;
using System;
using System.Text;
/*
 * @lc app=leetcode id=168 lang=csharp
 *
 * [168] Excel Sheet Column Title
 */

// @lc code=start
public class Solution 
{
    public string ConvertToTitle(int n) 
    {
        Stack<char> sta = new Stack<char>();
        StringBuilder sb = new StringBuilder();
        while (n > 0)
        {
            n = n - 1;
            sta.Push((char)('A' + (n%26)));
            n /=26;
        }
        while (sta.Any())
        {
            sb.Append(sta.Pop());
        }
        return sb.ToString();
    }
}
// @lc code=end

