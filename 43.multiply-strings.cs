using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.Security.Cryptography;
using System;
using System.Reflection.Metadata;
/*
 * @lc app=leetcode id=43 lang=csharp
 *
 * [43] Multiply Strings
 */

// @lc code=start
public class Solution 
{
    public string Multiply(string num1, string num2) 
    {
        int carry = 0;
        StringBuilder res = new StringBuilder("");
        int start = 1;

        for (int i = num2.Length - 1; i >= 0; i--)
        {
            int tempShift = res.Length - start ;
            
            for (int j = num1.Length - 1; j >= 0; j--)
            {
                int temp = int.Parse(num1[j].ToString()) * int.Parse(num2[i].ToString()) + carry;             
                carry = 0;

                if(tempShift < 0) 
                {       
                    if (temp >= 10)
                    {
                        carry = temp/10;
                        temp %= 10;
                    }
                    res.Insert(0,temp.ToString());
                }
                else
                {

                    temp += int.Parse(res[tempShift].ToString());
                    if (temp >= 10)
                    {
                        carry = temp/10;
                        temp %= 10;
                    }
                    res[tempShift] = (char)(temp + 48);
                    tempShift--;
                                    
                }

                if (j == 0 && carry != 0)
                {
                     res.Insert(0,carry.ToString());
                    carry = 0;
                }
            }
            start ++;      

        }

        if (res[0] == '0') 
        {
            return "0";
        }
        return res.ToString();
   ｝
}
/*
num1 123
num2  45
     615
    492
    5535 
*/
// @lc code=end

