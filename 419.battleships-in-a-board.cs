/*
 * @lc app=leetcode id=419 lang=csharp
 *
 * [419] Battleships in a Board
 */

// @lc code=start
public class Solution 
{
    //O(1) space O(n) time no modification
    public int CountBattleships(char[][] board) 
    {
        int x = board.Length;
        int y = board[0].Length;
        int res = 0;
        for (int r = 0; r < x; r++)
        {
            for (int c = 0; c < y; c++)
            {
                if (board[r][c] == 'X') 
                {
                    if ((r - 1 >= 0 && board[r - 1][c] == 'X') || (c - 1 >= 0 && board[r][c - 1] == 'X')) continue;
                    res++;            
                }
            }
        }
        return res;
    }
    

    /* modified the board
    char[][] board;
    int x;
    int y;

    public int CountBattleships(char[][] board) 
    {
        this.board = board;  
        x = board.Length;
        y = board[0].Length;
        int res = 0;
        for (int r = 0; r < x; r++)
        {
            for (int c = 0; c < y; c++)
            {
                if (board[r][c] == 'X') 
                {
                    GetShip(r,c);
                    res++;
                }
            }
        }
        return res;
    }

    public void GetShip (int r, int c)
    {
        while (r + 1 < x && board[r + 1][c] == 'X')
        {
            board[r + 1][c] = '.';
            r++;
        }
        while (c + 1 < y && board[r][c + 1] == 'X')
        {
            board[r][c + 1] = '.';
            c++;
        }
    }
    */
}
// @lc code=end

