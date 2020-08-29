using System.Reflection;
using System.Runtime;
/*
 * @lc app=leetcode id=89 lang=csharp
 *
 * [89] Gray Code
 */

// @lc code=start
public class Solution {
    public IList<int> GrayCode(int n)
    {
        IList<int> res = new List<int>();
        res.Add(0);
        if (n == 0) return res;
        List<int> target = new List<int>();

        //transform current num into binary
        while (n > 0)
        {
            int remainder = n%2;
            n /= 2;
            target.Add(remainder);
            if (n == 0) target.Add(1)
        }
        target.Reverse();
        int[] binaryArray = new int[target.Count];
        //set all to 0 first
        for (int i = 0; i < binaryArray.Length; i++) binaryArray[i] = 0;

    }

    private int GetDecimal (int)
}
// @lc code=end

