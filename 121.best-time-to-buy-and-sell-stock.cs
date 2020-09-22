/*
 * @lc app=leetcode id=121 lang=csharp
 *
 * [121] Best Time to Buy and Sell Stock
 */

// @lc code=start
public class Solution {
    public int MaxProfit(int[] prices) 
    {
        if (prices.Length == 0) return 0;
        int min = prices[0];
        int maxD = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] < min) min = prices[i];
            else maxD = prices[i] - min > maxD? prices[i] - min: maxD;
        }   
        return maxD;
    }
}
// @lc code=end

