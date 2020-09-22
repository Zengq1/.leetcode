using Internal;
using System.Runtime.InteropServices;
using System.Reflection.PortableExecutable;
using System.Data.SqlTypes;
using System.Runtime.Intrinsics.Arm.Arm64;
using System.Threading;
using System.Text.RegularExpressions;
using System;
using System.ComponentModel;
/*
 * @lc app=leetcode id=67 lang=csharp
 *
 * [67] Add Binary
 */

// @lc code=start
public class Solution {
    public string AddBinary(string a, string b) 
    {
        StringBuilder sb = new StringBuilder();
        int remain = 0;
        int maxLength = Math.Max(a.Length,b.Length);
        if (b.Length > a.Length) return AddBinary(b, a);
        int aI = a.Length - 1, bI = b.Length - 1;
        while(aI >= 0)
        {
            int temp =  bI >= 0? (a[aI] - '0') + (b[bI] - '0') + remain: (a[aI] - '0') + remain;
            remain = 0;
            if (temp > 1 ) 
            {
                temp -= 2;
                remain = 1;
            }

            sb.Insert(0,temp);

            aI--;
            bI--;
        }
        
        if (remain == 1) sb.Insert(0,'1');
        return sb.ToString();
    }
}
// @lc code=end

