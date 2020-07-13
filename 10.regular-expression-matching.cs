/*
 * @lc app=leetcode id=10 lang=csharp
 *
 * [10] Regular Expression Matching
 */

// @lc code=start
public class Solution 
{
    public bool IsMatch(string s, string p) 
    {
        //创造一个2D array去存储之前计算的dp的资料，因为需要创建多一个空string，所以array的长度要加一
        //因为只需要存储当前substring是否符合pattern，所以只需要boolean格式的array
        //横是pattern，竖是string
        bool[,] dp = new bool[s.Length + 1,p.Length + 1];
        //先记录当string未空时，因为空string肯定等于空string所有0，0是true
        dp[0,0] = true;

        //因为0，0已经几率了所以从第一格开始，pattern的index 从col-1 = 0开始记录
        for (int col = 1; col < dp.GetLength(1); col++)
        {
            if(p[col - 1] == '*' && dp[0,col - 2]) dp[0,col] = true;
            else dp[0,col] = false;
        }

        //因为row 0已经录入，所以从row 1开始
        for (int row = 1; row < dp.GetLength(0);row++)
        {
            for (int col = 0; col< dp.GetLength(1); col++)
            {
                //因为没有string可以match空的pattern，所以都是false
                if (col == 0) 
                {
                    dp[row,col] = false;
                    continue;
                }

                //主要有四种可能，一个是pattern和string的字母一样，pattern为*，pattern为.，或者不相同，不相同就直接填入false
                //当当前pattern字母与string字母相同检查左上角的一格，也就是之前的是否也相同，之前也相同就为相同
                if ((p[col - 1] == s[row - 1]||p[col - 1] == '.') && dp[row - 1,col - 1]) dp[row,col] = true;
                //当前pattern为*的话，有两种可能，一个是作为0消除前面一位的字母，一个是作为复数存在
                else if (p[col - 1] == '*')
                {
                    //假如作为0消除前一个字母的存在，检查col往左挪两位，看看消除后是否符合
                    if (dp[row,col - 2]) dp[row,col] = true;
                    //作为复数存在检查前一个pattern前字母和现在的字母是否相同然后再检查上面一格是否符合
                    if ((p[col - 2] == s[row - 1]||p[col - 2] =='.') && dp[row - 1,col]) dp[row,col] = true;
                }
                else dp[row,col] = false;
            }
        }     

        return dp[dp.GetLength(0) - 1,dp.GetLength(1) - 1];
    }
}
// @lc code=end

