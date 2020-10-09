using System.Reflection.Emit;
/*
 * @lc app=leetcode id=48 lang=csharp
 *
 * [48] Rotate Image
 */

// @lc code=start
public class Solution
{
    public void Rotate(int[][] matrix) 
    {
        int start = 0, end = matrix[0].Length - 1;
        int temp = 0;

        for (int c = 0; c <= matrix.Length/2; c++)
        {
            for (int i = 0; i < end - start; i++)
            {
                temp = matrix[start][start + i];
                matrix[start][start + i] = matrix[end - i][start];
                matrix[end - i][start] = matrix[end][end - i];
                matrix[end][end - i] = matrix[start + i][end];
                matrix[start + i][end] = temp;
            }
            start++;
            end--;
        }
    }
}
// @lc code=end

