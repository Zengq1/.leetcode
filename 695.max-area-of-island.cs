using System.Threading.Tasks.Dataflow;
/*
 * @lc app=leetcode id=695 lang=csharp
 *
 * [695] Max Area of Island
 */

// @lc code=start
public class Solution {
        private int resMax;
    private int rowNum;
    private int colNum;   
    public int MaxAreaOfIsland(int[][] grid) 
    {
        resMax = 0;
        rowNum = grid.Length;
        colNum = grid[0].Length;
        for (int i = 0; i < rowNum; i++)
        {
            for (int j = 0; j < colNum; j++)
            {
                DFS(grid,i,j,0);
            }
        }
        return resMax;
    }

    public void DFS (int[][] grid, int rowIndex, int colIndex, int curMax)
    {
        if (grid[rowIndex][colIndex] == 0)
        {
            return;
        }
        curMax += 1;
        resMax = Math.Max(resMax,curMax);
        grid[rowIndex][colIndex] = 0;
        if (rowIndex > 0) DFS(grid,rowIndex - 1,colIndex,curMax);
        if (rowIndex < rowNum - 1) DFS(grid, rowIndex + 1, colIndex, curMax);
        if (colIndex > 0) DFS(grid, rowIndex, colIndex - 1, curMax);
        if (colIndex < colNum - 1) DFS(grid, rowIndex, colIndex + 1, curMax);
        grid[rowIndex][colIndex] = 1;
    }
}
// @lc code=end

