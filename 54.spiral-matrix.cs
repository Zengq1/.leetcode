using System.Security.Authentication.ExtendedProtection;
using System;
using System.Reflection.Metadata;
using System.Net.Sockets;
using System.IO;
using System.Numerics;
/*
 * @lc app=leetcode id=54 lang=csharp
 *
 * [54] Spiral Matrix
 */

// @lc code=start
public class Solution 
{
    public IList<int> SpiralOrder(int[][] matrix) 
    {
         IList<int> res = new List<int>();
        if(matrix.Length == 0 || matrix[0].Length == 0) return res;
        
        //0: move right
        //1: move down
        //2: move left
        //3: move up
        int moveIndicator = 0; 
        int rowNum = matrix.GetLength(0);
        int colNum = matrix[0].Length;
        int totalNum = rowNum * colNum;
        int rowIndex = 0;
        int colIndex = 0;
        int count = 0;
        
        while(totalNum > 0)
        {
            Console.WriteLine("Total Num is " + totalNum);
            if (moveIndicator == 0) // move right
            {
                if (count == colNum) //reach end
                {
                    rowNum--;
                    moveIndicator = 1;
                    rowIndex++;
                    count = 0;
                    colIndex --;
                }
                else
                {
                    res.Add(matrix[rowIndex][colIndex]);
                    colIndex++;
                    count++;
                    totalNum --;
                }
            }
            if (moveIndicator == 1) //move down
            {
                if (count == rowNum) //reach end
                {
                    colNum--;
                    moveIndicator = 2;
                    colIndex--;
                    count = 0;
                    rowIndex--;
                }
                else
                {
                    res.Add(matrix[rowIndex][colIndex]);
                    rowIndex++;
                    count++;
                    totalNum --;
                }
            }
            if (moveIndicator == 2) //move left
            {
                if (count == colNum) //reach end
                {
                    rowNum--;
                    moveIndicator = 3;
                    rowIndex--;
                    count = 0;
                    colIndex++;
                }
                else
                {
                    res.Add(matrix[rowIndex][colIndex]);
                    colIndex--;
                    count++;
                    totalNum --;
                }
            }
            if (moveIndicator == 3) //move up
            {
                if (count == rowNum) //reach end
                {
                    colNum--;
                    moveIndicator = 0;
                    colIndex++;
                    count = 0;
                    rowIndex ++;
                }
                else
                {
                    res.Add(matrix[rowIndex][colIndex]);
                    rowIndex--;
                    count++;
                    totalNum --;
                }
            }
        }

        return res;
    }
}
// @lc code=end

