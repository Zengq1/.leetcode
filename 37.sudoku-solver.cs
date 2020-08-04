using System.Data.SqlTypes;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
/*
 * @lc app=leetcode id=37 lang=csharp
 *
 * [37] Sudoku Solver
 */

// @lc code=start
public class Solution 
{
    char[] NUM = new char[]{'1','2','3','4','5','6','7','8','9'};
    char[][] board;    
    
    public void SolveSudoku(char[][] board) 
    {
        this.board = board;
        CheckPossibleSolution(0,0);
    }

    private bool CheckPossibleSolution(int r, int c)
    { 
        if (r == 9) return true;
        if (c == 9) return CheckPossibleSolution(r + 1,0);

        if (board[r][c] != '.') return CheckPossibleSolution(r,c + 1);
        else
        {
            foreach (char n in NUM)
            {
                if (CheckValid(r,c,n))
                {
                    board[r][c] = n;
                    if (CheckPossibleSolution(r,c + 1)) return true;
                    board[r][c] = '.';
                }
            }
        }
        return false;
    }


    

    //method to scan row and column to get possible number for the target cell cell
    private bool CheckValid(int r, int c,char curNum)
    {
        //check row
        for (int col = 0; col < 9; col++)
        {
            if (board[r][col] == curNum) return false;
        }

        //check col
        for (int row = 0; row < 9; row++)
        {
            if (board[row][c] == curNum) return false;
        }

        int rB = (r/3) * 3;
        int cB = (c/3) * 3;

        for (int row = rB; row < rB + 3; row++)
        {
            for (int col = cB; col < cB + 3; col++)
            {
                if (board[row][col] == curNum) return false;
            }
        }

        return true;
    }
}
// @lc code=end

