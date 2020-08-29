using System.Data.Common;
using System.Runtime.CompilerServices;
/*
 * @lc app=leetcode id=36 lang=csharp
 *
 * [36] Valid Sudoku
 */

// @lc code=start
public class Solution 
{
    public bool IsValidSudoku(char[][] board) 
    {
        bool[,] rowRecord = new bool[9,9];//first index indicate the row number, second index indicate if the number has been used 
        bool[,] colRecord = new bool[9,9];//first index indicate the col number
        bool[,] subRecord = new bool[9,9];//first index indicate which subset of it

        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col ++)
            {
                if (board[row][col] != '.')
                {
                    int digit = board[row][col] - '1';
                    int subNum = GetSubIndex(row,col);

                    //check row
                    if (rowRecord[row,digit] == true) return false;
                    else rowRecord[row,digit] = true;
                    //check col
                    if (colRecord[col,digit] == true) return false;
                    else colRecord[col,digit] = true;
                    //check subcell
                    if (subRecord[subNum,digit] == true) return false;
                    else subRecord[subNum,digit] = true;
                }
            }
        }

        return true;
    }

    private int GetSubIndex (int r, int c)
    {
        if (r < 3)
        {
            if (c < 3) return 0;
            else if (c < 6) return 1;
            else return 2;
        }
        else if (r < 6)
        {
            if (c < 3) return 3;
            else if (c < 6) return 4;
            else return 5;
        }
        else
        {
            if (c < 3) return 6;
            else if (c < 6) return 7;
            else return 8;
        }
    }
}
// @lc code=end

