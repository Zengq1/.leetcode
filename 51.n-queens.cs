/*
 * @lc app=leetcode id=51 lang=csharp
 *
 * [51] N-Queens
 */

// @lc code=start
public class Solution {
    public IList<IList<string>> SolveNQueens(int n)
    {
        IList<IList<string>> res = new List<IList<string>>();
        char[,] board = new char[n,n];
        if (n < 1) return res;
                for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                board[i,j] = '.';
            }
        }

        DFS(0,n,board,res);
        return res;
    }

    private void DFS (int row, int n, char[,] board, IList<IList<string>> res)
    {
        if (row == n) return;

        for (int c = 0; c < n; c++)
        {
            if (IsValid(board,row,c,n))
            {
                board[row,c] = 'Q';

                if (row != n - 1)
                {
                    DFS(row + 1, n, board, res);
                }
                else
                {
                    res.Add(GetString(board));
                }

                board[row,c] = '.';
            }
        }    
    }

    private IList<string> GetString(char[,] board)
    {
        IList<string> res = new List<string>();
        for (int i = 0; i < board.GetLength(0);i++)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < board.GetLength(1);j++)
            {
                sb.Append(board[i,j]);
            }
            res.Add(sb.ToString());
        }
        return res;
    }
    private bool IsValid(char[,] board, int r, int c, int n)
    {
        for (int i = 0; i < n; i++)
        {   
            if (board[i,c] != '.' || board[r,i] != '.') return false;
        }

        int lr = 0, rr = 0, lc = 0, rc = 0;

        if (c - (r - 0) >= 0)
        {
            lr = 0;
            lc = c - (r - 0);
        }
        else
        {
            lc = 0;
            lr = r - (c - 0);
        }
        if (c + (r - 0) < n)
        {
            rr = 0;
            rc = c + (r - 0);
        }
        else
        {
            rc = n - 1;
            rr = r - (n - 1 - c);
        }

        while (lr < n && lc < n)
        {
            if (board[lr,lc] != '.') return false;
            lr++;
            lc++;
        }

        while (rr < n && rc >= 0)
        {
            if (board[rr,rc] != '.') return false;
            rr++;
            rc--;
        }
        return true;
    }
}


// @lc code=end

