/*
 * @lc app=leetcode id=17 lang=csharp
 *
 * [17] Letter Combinations of a Phone Number
 */

// @lc code=start
public class Solution {
    public IList<string> LetterCombinations(string digits) 
    {
        IList<string> res = new List<string>();
        
        if (digits.Length < 1) return res;
       
        int count = 0;
        int totalNum = 1;

        //create list to record index
        List<int> digitIndex = new List<int>();

        //get the total number of element and insert 0 for each digit in the digits strign
        foreach (char c in digits)
        {
            totalNum *= GetChar(c).Count;
            digitIndex.Add(0);
        }

        StringBuilder sb = new StringBuilder();

        while (totalNum > 0)
        {
            string tempS = "";
            for (int i = 0; i < digits.Length; i++)
            {
                tempS += GetChar(digits[i])[digitIndex[i]];
            }
            sb.Append(tempS);

            digitIndex[digitIndex.Count - 1] ++;
            if (digitIndex[digitIndex.Count - 1] == GetChar(digits[digits.Length-1]).Count)
            {
                for (int i = digitIndex.Count - 1; i > 0; i--)
                {
                    if (i < digitIndex.Count && digitIndex[i] == GetChar(digits[i]).Count)
                    {
                        digitIndex = 0;
                        digitIndex[i - 1]++;
                    }
                    else break;
                }
            }
            
            totalNum--;
        }
        return res;  
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
                return new List<char>() {'p','r','r','s'};     
            case '8':
                return new List<char>() {'t','u','v'};      
            case '9':
                return new List<char>() {'w','x','y','z'};         
        }    
        return new List<char>();
    }
}
// @lc code=end

