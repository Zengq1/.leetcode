using System;
/*
 * @lc app=leetcode id=200 lang=csharp
 *
 * [200] Number of Islands
 */

// @lc code=start
public class Solution 
{ 
    private int rowNum;
    private int colNum;
    
    public int NumIslands(char[][] grid) 
    {
        rowNum = grid.Length;
        colNum = grid[0].Length;
        int res = 0;
        for (int i = 0; i < rowNum; i++)
        {
            for (int j = 0; j < colNum; j++)
            {
                if (grid[i][j] == '1') 
                {
                    MarkIsland(grid,i,j);
                    res++;
                }
            }
        }
        return res;
    }

    private void MarkIsland (char[][] grid, int rowIndex, int colIndex)
    {
        grid[rowIndex][colIndex] = '0';
        if (rowIndex > 0 && grid[rowIndex - 1][colIndex] == '1') MarkIsland(grid,rowIndex - 1,colIndex);
        if (rowIndex < rowNum - 1 && grid[rowIndex + 1][colIndex] == '1') MarkIsland(grid, rowIndex + 1, colIndex);
        if (colIndex > 0 && grid[rowIndex][colIndex - 1] == '1') MarkIsland(grid,rowIndex,colIndex - 1);
        if (colIndex < colNum - 1 && grid[rowIndex][colIndex + 1] == '1') MarkIsland(grid,rowIndex,colIndex + 1);
    }
}
// @lc code=end

