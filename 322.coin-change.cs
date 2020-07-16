using System;
using System.Reflection.Metadata.Ecma335;
using System.Net;
using System.Xml;
using System.Data.Common;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.CompilerServices;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Data;
using System.Runtime.ConstrainedExecution;
/*
 * @lc app=leetcode id=322 lang=csharp
 *
 * [322] Coin Change
 */

// @lc code=start
public class Solution 
{
    public int CoinChange(int[] coins, int amount) 
    {
        if (coins.Length == 0 && amount != 0) return -1;
        if (amount == 0) return 0;

        /*complete 2D DP
        //create dp to store previous data
        int[,] dp = new int[coins.Length + 1,amount + 1];
        
        //sort the coins set
        Array.Sort(coins);

        //variable to hold the answer
        int res = int.MaxValue;

        //when amount target is 0, it will only require 0 coin to reach target
        for (int i = 0; i < dp.GetLength(0);i++) dp[i,0] = 0;
        //when coin index is 0 means there are 0 coin, it can't reach any other targets except 0, therefore it's -1
        //since I already deal with [0,0], so I will start at 1
        for (int i = 1; i < dp.GetLength(1);i++) dp[0,i] = -1;

        //the coin index indicate which coin it is in that column, since I added 0 which means no coin, coinIndex
        //will need to +1 to get the correct coin. dp[coinIndex][amountIndex] indicate the min amount of coins to 
        //reach the amount index which is the temp target, if it cannot reach the target, insert -1;
        for (int coinIndex = 1; coinIndex < dp.GetLength(0); coinIndex++)
        {
            //amount index indicate the current amount, starts from 0 and ends at target amount
            for (int amountIndex = 1; amountIndex < dp.GetLength(1); amountIndex++)
            {
                //if current coin value is larger than the current target value, look up for the upper one coin index 
                //to se how many coins it used
                if (coins[coinIndex - 1] > amountIndex)
                {
                    dp[coinIndex,amountIndex] = dp[coinIndex - 1,amountIndex];
                }
                else
                {
                    //check what's the complement 
                    int comp = amountIndex - coins[coinIndex - 1];
                    if (comp == 0) dp[coinIndex,amountIndex] = 1;
                    else //if comp is not 0, we need to look for the previous recorded min number of coin to reach the comp target
                    {
                        if (dp[coinIndex - 1,amountIndex] != -1 && dp[coinIndex,comp] != -1)  
                        {
                            dp[coinIndex,amountIndex] = Math.Min(dp[coinIndex-1,amountIndex],dp[coinIndex,comp] + 1);
                        }
                        else if (dp[coinIndex - 1,amountIndex] == -1 && dp[coinIndex,comp] == -1) dp[coinIndex,amountIndex] = -1;
                        else if (dp[coinIndex - 1,amountIndex] != -1) dp[coinIndex,amountIndex] = dp[coinIndex - 1,amountIndex];
                        else dp[coinIndex,amountIndex] = dp[coinIndex,comp] + 1;
                    }
                }

                if (amountIndex == amount && dp[coinIndex,amountIndex] != -1) res = Math.Min(res,dp[coinIndex,amountIndex]);
            }
        }
        return res == int.MaxValue?-1:res;
        */

        //using one dimension array to track
        int[]dp = new int[amount + 1];

        for (int tempAmount = 0; tempAmount < dp.Length; tempAmount++)
        {
            //assume there's no match value
            dp[tempAmount] = int.MaxValue;
            for (int coinIndex = 0; coinIndex < coins.Length; coinIndex++)
            {
                if (coins[coinIndex] == tempAmount) dp[tempAmount] = 1;
                if (coins[coinIndex] < tempAmount) 
                {
                    int comp = tempAmount - coins[coinIndex];
                    dp[tempAmount] = Math.Min(dp[tempAmount],dp[comp] + 1);
                }
            }
        }
        return dp[dp.Length - 1] == int.MaxValue? -1:dp[dp.Length - 1];
    }
}
// @lc code=end

