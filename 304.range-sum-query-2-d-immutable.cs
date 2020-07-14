using System.Runtime.InteropServices;
using System.Numerics;
/*
 * @lc app=leetcode id=304 lang=csharp
 *
 * [304] Range Sum Query 2D - Immutable
 */

// @lc code=start
public class NumMatrix 
{
    int[][] matrix;
    int[,] dp;
    public NumMatrix(int[][] matrix) 
    {
        this.matrix = matrix;
        if (matrix.Length != 0 && matrix[0].Length != 0)
        {
            dp = new int[matrix.Length + 1,matrix[0].Length + 1];
            for (int r = 0; r < dp.GetLength(0); r++)
            {
                for (int c = 0; c < dp.GetLength(1); c++)
                {   
                    if (r == 0 || c == 0) dp[r,c] = 0;
                    else dp[r,c] = dp[r - 1,c] + dp[r,c - 1] + matrix[r - 1][c - 1] - dp[r - 1,c - 1];
                }   
            }
        }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) 
    {
        return dp[row2 + 1,col2 + 1] - dp[row1,col2 + 1] - dp[row2 + 1,col1] + dp[row1,col1];
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */
// @lc code=end

