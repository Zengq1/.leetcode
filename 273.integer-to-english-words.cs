using System.Linq;
/*
 * @lc app=leetcode id=273 lang=csharp
 *
 * [273] Integer to English Words
 */

// @lc code=start
public class Solution
{
    public string NumberToWords(int num) 
    {
         if (num == 0) return "Zero";
        
        // list record the num seperate by 1000;
        List<int> record = new List<int>();
        StringBuilder sb = new StringBuilder();

        //seperate the num
        while (num > 0)
        {
            int temp = num%1000;
            record.Add(temp);
            num /= 1000;    
        }
        
        //loop from the back
        for (int i = record.Count - 1; i >= 0; i--)
        {
            int tempNum = record[i];
            
            if (tempNum > 99)
            {
                sb.Append(GetNumUnderTwenty(tempNum/100) + " Hundred");
                tempNum %= 100;
            }
            if (tempNum > 19)
            {
                sb.Append(GetNumAboveTwenty(tempNum/10));
                tempNum %= 10;
            }
            if (tempNum > 0)
            {
                sb.Append(GetNumUnderTwenty(tempNum));
            }

            if (i > 0 && record[i] != 0) sb.Append(GetUnit(i));
        }
        if (sb[0] == ' ') sb.Remove(0, 1);

        return sb.ToString();
    }
    
    private string GetNumUnderTwenty (int num)
    {
        switch (num)
        {
            case 1:
                return " One";
            case 2:
                return " Two";
            case 3:
                return " Three";
            case 4:
                return " Four";
            case 5:
                return " Five";
            case 6:
                return " Six";
            case 7:
                return " Seven";
            case 8:
                return " Eight";
            case 9:
                return " Nine";
            case 10:
                return " Ten";
            case 11:
                return " Eleven";
            case 12:
                return " Twelve";
            case 13:
                return " Thirteen";
            case 14:
                return " Fourteen";
            case 15:
                return " Fifteen";
            case 16:
                return " Sixteen";
            case 17:
                return " Seventeen";
            case 18:
                return " Eighteen";
            case 19:
                return " Nineteen";
        }
        return "";
    }

    private string GetNumAboveTwenty (int num)
    {
        switch (num)
        {
            case 2:
                return " Twenty";
            case 3:
                return " Thirty";
            case 4:
                return " Forty";
            case 5:
                return " Fifty";
            case 6:
                return " Sixty";
            case 7:
                return " Seventy";
            case 8:
                return " Eighty";
            case 9:
                return " Ninety";
        }
        return "";
    }


    private string GetUnit (int NumofSpace)
    {
        switch (NumofSpace)
        {
            case 1:
                return " Thousand";
            case 2:
                return " Million";
            case 3:
                return " Billion"; 
        }
        return "";
    }
}
// @lc code=end

