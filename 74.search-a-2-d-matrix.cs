/*
 * @lc app=leetcode id=74 lang=csharp
 *
 * [74] Search a 2D Matrix
 */

// @lc code=start
public class Solution 
{
    public bool SearchMatrix(int[][] matrix, int target) 
    {
        int colMax = matrix[0].Length - 1;
        int rowUp = 0, rowDown = matrix.Length - 1, colLeft = 0, colRight = colMax;
        //using two binary search to find target
        //first find the target row
        while (rowUp < rowDown)
        {
            int rowMid = (rowUp + rowDown)/2;
            //if target is less than the first number in the row, move down to mid
            if (matrix[rowMid][0] > target) rowDown = rowMid - 1;

            //if target is larger than the last number in the row, move up to mid
            else if (matrix[rowMid][colMax] < target) rowUp = rowMid + 1;
            else if (target >= matrix[rowMid][0] && target <= matrix[rowMid][colMax])//found the target row which target is larger than [row][0] and less than [row][rowMax]
            {
                while (colLeft < colRight)
                {
                    int colMid = (colLeft + colRight)/2;
                    if (matrix[rowMid][colMid] == target) return true;
                    else if (target < matrix[rowMid][colMid]) colRight = colMid - 1;
                    else if  (target > matrix[rowMid][colMid]) colLeft = colMid + 1;           
                }
                break;
            }
        }

        return false;
    }
}
// @lc code=end

