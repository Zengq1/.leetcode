using System.Data;
using Internal;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using System;
/*
 * @lc app=leetcode id=29 lang=csharp
 *
 * [29] Divide Two Integers
 */

// @lc code=start
public class Solution 
{
    
     public int Divide(int dividend, int divisor) 
    {
           //edge cases
        if (dividend == divisor) return 1;
        if (divisor == 1) return dividend;
        if (divisor == -1) return dividend == int.MinValue? int.MaxValue:dividend - dividend - dividend;
        if (divisor == 0) return 0;
        if (divisor == int.MinValue) 
        {
            if (dividend == int.MinValue) return 1;
            else return 0;
        }

        int quotient = 0; 
        if (dividend == int.MinValue)
        {
            quotient++;
            dividend = divisor > 0? dividend += divisor: dividend -= divisor;
        }

        bool positive = ((dividend < 0 && divisor < 0) || (dividend > 0 && divisor > 0));
        dividend = Math.Abs(dividend);
        divisor = Math.Abs(divisor);
         
        if (dividend < divisor) return positive?quotient: quotient - quotient - quotient;
         
        int res = GetQuotient(dividend, divisor,1);
         
        if (positive) res = res + quotient;
        else res = res - res - res - quotient;
        return res;
    }

    private int GetQuotient (int dividend, int divisor, int quotient)
    {
        int tempDivisor = divisor;
        int remain = dividend;
        int tempQuo = quotient;
        
        while (dividend >= tempDivisor  && tempDivisor > 0)
        {
            remain = dividend - tempDivisor;
            if (remain == 0) return quotient;
            tempDivisor <<= 1;
            tempQuo <<= 1;
            if (tempQuo == int.MinValue) break;
            quotient <<= 1;
        }
        
        if (tempQuo > 0) quotient >>= 1;
        if (remain >= divisor)
        {
            int te =  GetQuotient(remain, divisor, 1);
            //Console.WriteLine("remain is " + remain + " original quo is " + quotient + " te is " +  te);
            quotient += te;
                        
        }
        return quotient;
    }
}
// @lc code=end

