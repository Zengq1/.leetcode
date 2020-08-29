using System.Resources;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Schema;
using System.Runtime.InteropServices;
using System.Net;
using System.Xml;
using System.Data.Common;
using System.Numerics;
/*
 * @lc app=leetcode id=85 lang=csharp
 *
 * [85] Maximal Rectangle
 */

// @lc code=start
public class Solution 
{
    public int MaximalRectangle(char[][] matrix) 
    {
        int max = 0;
        if (matrix.Length == 0 || matrix[0].Length == 0) return 0;
        int[,] dp = new int[matrix.Length,matrix[0].Length];
        //loop through the matrix to get the height of each column
        for (int r = 0; r < matrix.Length; r++)
        {
            for (int c = 0; c < matrix[0].Length; c++)
            {
                if (matrix[r][c] == '0') dp[r,c] = 0;
                else
                {
                    if (r == 0) dp[r,c] = 1;
                    else dp[r,c] = dp[r - 1,c] + 1;
                }
            }
        } 
        
        Stack<int> leftStack = new Stack<int>();
        Stack<int> highStack = new Stack<int>();

        //loop through dp to get biggest area
        for (int r = 0; r < dp.GetLength(0); r++)
        {
            int cur = 0;
            while (cur < dp.GetLength(1)) //loop through column
            {   
                Console.WriteLine("r is " + r +",  cur is " + cur);
                if (dp[r,cur] == 0)
                {
                    while (leftStack.Any())
                    {
                        int leftIndex = leftStack.Pop();
                        int high = highStack.Pop();
                            
                        max = max>GetArea(high,leftIndex,cur)? max:GetArea(high,leftIndex,cur);
                    }
                    cur++;
                }
                else
                {
                    if (!leftStack.Any())
                    {
                        leftStack.Push(cur);
                        highStack.Push(dp[r,cur]);
                        cur++;
                    }
                    else
                    {
                        if (dp[r,cur] == highStack.Peek()) 
                        {
                            if(leftStack.Count > highStack.Count) leftStack.Pop();
                            cur++;
                        }
                        else if (dp[r,cur] > highStack.Peek())
                        {
                            if (leftStack.Count == highStack.Count) leftStack.Push(cur);
                            highStack.Push(dp[r,cur]);
                            cur++;
                        }
                        else if (dp[r,cur] < highStack.Peek()) //0 1 1 3 3 1
                        {
                            if (leftStack.Count > highStack.Count) leftStack.Pop();           
                            int leftIndex = leftStack.Peek();
                            int high = highStack.Pop();
                            
                            max = max>GetArea(high,leftIndex,cur)? max:GetArea(high,leftIndex,cur);
                        }
                    }
                }

                //reach end
                if (cur == dp.GetLength(1))
                {
                    while (leftStack.Any())
                    {
                        int leftIndex = leftStack.Pop();
                        int high = highStack.Pop();
                            
                        max = max>GetArea(high,leftIndex,cur)? max:GetArea(high,leftIndex,cur);
                    }
                }
            }
        }

        return max;
    }

    private int GetArea (int hight, int left, int right)
    {
        return hight * (right - left);
    }
}


/*
  [1,0,1,0,0]  [1,0,1,0,0] 
  [1,0,1,1,1]  [2,0,2,1,1]
  [1,1,1,1,1]  [3,1,3,2,2]
  [1,0,0,1,0]  [4,0,0,3,0]
*/
// @lc code=end

