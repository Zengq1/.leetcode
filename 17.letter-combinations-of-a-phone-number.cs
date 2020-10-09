using System;
/*
 * @lc app=leetcode id=17 lang=csharp
 *
 * [17] Letter Combinations of a Phone Number
 */

// @lc code=start
public class Solution 
{
    IList<string> res;
    public IList<string> LetterCombinations(string digits) 
    {
        res = new List<string>();
        
        if (digits.Length < 1) return res;
        GetCombination(0,"",digits);
        return res;
    }

    private void GetCombination(int curInd, string curS, string digits)
    {
        if (curInd == digits.Length)
        {
            res.Add(curS);
            return;
        }
        List<char> curCharList = GetChar(digits[curInd]);
        StringBuilder sb = new StringBuilder(curS);

        foreach (char c in curCharList)
        {
            sb.Append(c);
            GetCombination(curInd + 1, sb.ToString(), digits);
            sb.Length--;
        }
    }
    
    private List<char> GetChar (char c)
    {
        switch (c)
        {
            case '2':
                return new List<char>() {'a','b','c'};
            case '3':
                return new List<char>() {'d','e','f'};
            case '4':
                return new List<char>() {'g','h','i'};       
            case '5':
                return new List<char>() {'j','k','l'};       
            case '6':
                return new List<char>() {'m','n','o'};
            case '7':
                return new List<char>() {'p','q','r','s'};     
            case '8':
                return new List<char>() {'t','u','v'};      
            case '9':
                return new List<char>() {'w','x','y','z'};         
        }    
        return new List<char>();
    }
}
// @lc code=end

