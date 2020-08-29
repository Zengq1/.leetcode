using System.Reflection.PortableExecutable;
using System.ComponentModel;
/*
 * @lc app=leetcode id=122 lang=csharp
 *
 * [122] Best Time to Buy and Sell Stock II
 */

// @lc code=start
public class Solution 
{
    public int MaxProfit(int[] prices) 
    {
        int res = 0;
        int lowestPrice = prices[0];
        int prePrice = prices[0];
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] <= prePrice) 
            {
                res += prePrice - lowestPrice > 0? prePrice - lowestPrice:0;
                lowestPrice = prices[i];
                prePrice = prices[i];
            }
            else
            {
                prePrice = prices[i];
                if (i == prices.Length - 1)
                {
                    res += prePrice - lowestPrice > 0? prePrice - lowestPrice:0;
                }
            }
        }
        return res;
    }
}
// @lc code=end

