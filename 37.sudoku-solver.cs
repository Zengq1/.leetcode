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
    //hold the list of possible number in the dictionary
    Dictionary<int,bool[]> possible;//[1][1] is 22, [2][4] is 35
    
    //array to hold which number was seen before
    bool[] seenNum;

    char[][] board;    
    
    public void SolveSudoku(char[][] board) 
    {
        this.board = board;
        possible = new Dictionary<int,bool[]>();
        seenNum = new bool[9];
        for (int i = 0; i < 9; i++) seenNum[i] = false;

        //pre scan 
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (char[i][j] != '.') continue;
                else GetPossibleNum(i,j);
            }
        }
    }


    

    //method to scan row and column to get possible number for each cell
    private void GetPossibleNum(int r, int c)
    {
        //check row
        for (int col = 0; col < 9; col++)
        {
            if (board[r][col] != '.') seenNum[board[r][col]] = true;
        }

        //check col
        for (int row = 0; row < 9; row++)
        {
            if (board[row][c] != '.') seenNum[board[row][c]] = true;
        }

        //check sub box
        int rB = 0; int cB = 0;

        if (r >5) rB = 6;
        else if (r > 2) rB = 3;
        if (c > 5) cB = 6;
        else if (c > 2) cB = 3;

        for (int row = rB; row < rB + 3; row++)
        {
            for (int col = cB; col < cB + 3; col++)
            {
                if (board[row][col] != '.') seenNum[board[row][col]] = true;
            }
        }

        int curIndex = (r + 1) * 10 + (c + 1);
        for (int i = 0; i < 9; i ++)
        {
            if (seenNum[i] == false) possible[curIndex].Add(i + 1);
            else seenNum[i] = false; //set true back to false for the next column
        }
    }
}
// @lc code=end

