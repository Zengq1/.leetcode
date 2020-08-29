using System.Text;
using System.Buffers.Text;
using System.Data.Common;
/*
 * @lc app=leetcode id=393 lang=csharp
 *
 * [393] UTF-8 Validation
 */

// @lc code=start
public class Solution
{
    public bool ValidUtf8(int[] data)
    {
        int left = 0;
        foreach (int num in data)
        {
            if (left == 0)
            {
                if (num>> 7 == 0) left = 0;
                else if (num>> 5 == 6) left = 1;
                else if (num>> 4 == 14) left = 2;
                else if (num>> 3 == 30) left = 3;
                else return false;
            }
            else
            {
                if (num >> 6 != 2) return false;
                left--;
            }
        }
        return left == 0;
    }
}
// @lc code=end

