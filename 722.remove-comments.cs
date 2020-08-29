using System.Transactions;
using System.Runtime.Versioning;
using System.Diagnostics.Tracing;
using System.Data.Common;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Data.SqlTypes;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection.Metadata;
using System;
using System.Text;
/*
 * @lc app=leetcode id=722 lang=csharp
 *
 * [722] Remove Comments
 */

// @lc code=start
public class Solution {
    public IList<string> RemoveComments(string[] source) 
    {
        IList<string> res = new List<string>();
        bool blockComment = false;
        StringBuilder sb = new StringBuilder();
        
        for (int i = 0; i < source.Length; i++)
        {
            if (!blockComment) sb = new StringBuilder();

            //loop through char
            for (int j = 0; j < source[i].Length; j++)
            {
                //inside blockComment
                if (blockComment && j < source[i].Length - 1 && source[i][j] == '*' && source[i][j + 1] == '/')
                {
                    blockComment = false;
                    j++;
                }
                else if (!blockComment) //not inside block comment
                {
                    if (j < source[i].Length - 1 && source[i][j] == '/' && source[i][j + 1] == '/')
                    {
                        break;
                    }
                    else if (j < source[i].Length - 1 && source[i][j] == '/' && source[i][j + 1] == '*')
                    {
                        blockComment = true;
                        j++;
                    }
                    else
                    {
                        sb.Append(source[i][j]);
                    }
                }
            }

            if (!blockComment && sb.Length != 0) res.Add(sb.ToString());
        }
        return res;
    }
}
// @lc code=end

