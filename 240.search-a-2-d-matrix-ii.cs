/*
 * @lc app=leetcode id=240 lang=csharp
 *
 * [240] Search a 2D Matrix II
 */

// @lc code=start
public class Solution 
{
    public bool SearchMatrix(int[,] matrix, int target) 
    {
        //search to right first it right is end or right is larger than target , move down,if down is larger, move left, 
        int r = 0, c = 0, rowB = matrix.GetLength(0), colB = matrix.GetLength(1);
        if (rowB == 0 || colB == 0) return false;

        while (r < rowB && c >= 0)
        {
            if (matrix[r,c] == target) return true;
            if (matrix[r,c] < target) 
            {
                c++;
                if (c == colB)
                {
                    c--;
                    r++;
                }
            }
            if (matrix[r,c] > target)
            {
                c--;
                if (c >= 0 && matrix[r,c] <  target) r++;
            }
        }

        return false;
    }
}
// @lc code=end

