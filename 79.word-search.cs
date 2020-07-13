/*
 * @lc app=leetcode id=79 lang=csharp
 *
 * [79] Word Search
 */

// @lc code=start
public class Solution 
{
    public bool Exist(char[][] board, string word) 
    {
        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c <board[0].Length; c++)
            {
                if (BackTracking(board,word,0,r,c)) return true;
            }
        }
        return false;
    }

    private bool BackTracking (char[][] board,string target, int curTargetIndex, int rowIndex, int colIndex)
    {
        if (rowIndex < 0 || rowIndex >= board.Length || colIndex < 0 || colIndex >= board[0].Length || target[curTargetIndex] != board[rowIndex][colIndex]) return false;
        if (curTargetIndex == target.Length - 1) return true;
        board[rowIndex][colIndex] = '$';
        bool res = BackTracking(board, target, curTargetIndex + 1, rowIndex - 1, colIndex) || BackTracking(board,target,curTargetIndex + 1, rowIndex + 1, colIndex) ||
                    BackTracking(board, target, curTargetIndex + 1, rowIndex, colIndex - 1) || BackTracking(board, target,curTargetIndex + 1,rowIndex, colIndex + 1);
        board[rowIndex][colIndex] = target[curTargetIndex];
        return res;
    }
}
// @lc code=end

