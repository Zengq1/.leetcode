using System.Reflection.Metadata.Ecma335;
using System.Text;
using System;
using System.Globalization;
/*
 * @lc app=leetcode id=415 lang=csharp
 *
 * [415] Add Strings
 */

// @lc code=start
public class Solution 
{
    public string AddStrings(string num1, string num2) 
    {
        //get the larger length of string
        bool num1Longer = false;
        int difference = 0;
        if (num1.Length >= num2.Length)
        {
            num1Longer = true;
            difference = num1.Length - num2.Length;;
        }
        else 
        {
            difference = num2.Length - num1.Length;
        }
        
        string res = "";
        int carry = 0;
        

        //loop from back   
        for(int i = num1Longer?num1.Length - 1: num2.Length - 1; i >= 0; i--)
        {
            int temp = 0;

            if (num1Longer)
            {
                temp = carry + int.Parse(num1[i].ToString()); 
                if((i - difference) >= 0)
                {
                    temp += int.Parse(num2[i - difference].ToString());
                } 
                carry = 0;
            }
            else
            {
                temp = carry + int.Parse(num2[i].ToString()); 
                if((i - difference) >= 0)
                {
                    temp += int.Parse(num1[i - difference].ToString());
                } 
                carry = 0;
            }

            if (temp >= 10)
            {
                carry = temp / 10;
                temp = temp % 10;
            }

            res = temp.ToString() + res;

            if (i == 0 && carry != 0)
            {
                res = carry.ToString() + res;
            }
        }

        return res;
    }
}
// @lc code=end

