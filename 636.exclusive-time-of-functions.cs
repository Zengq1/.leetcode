using System.Linq;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=636 lang=csharp
 *
 * [636] Exclusive Time of Functions
 */

// @lc code=start
public class Solution 
{
    public int[] ExclusiveTime(int n, IList<string> logs) 
    {
        //record ID and executed time
        Dictionary<string,int> dic = new Dictionary<string, int>();
        //stack to hold time stamp
        Stack<string> idSta = new Stack<string>();
        int lastStamp = 0;
        foreach (string s in logs)
        {
            //split the string into [0]id [1]start|end and [2]enter time stamp
            string[] splitedString = s.Split(':'); 
            if(splitedString[1] == "start")
            {
                //first time have see this id
                if (!dic.ContainsKey(splitedString[0])) dic.Add(splitedString[0],0);
                if (idSta.Any()) dic[idSta.Peek()] += int.Parse(splitedString[2]) - lastStamp; //-1+1
                lastStamp = int.Parse(splitedString[2]);
                idSta.Push(splitedString[0]);
            }
            else
            {
                dic[idSta.Peek()] += int.Parse(splitedString[2]) - lastStamp + 1;
                idSta.Pop();
                lastStamp = int.Parse(splitedString[2]) + 1;
            }
        }

        int[] res = new int[n];
        dic.Values.CopyTo(res,0);

        return res;
    }
}
// @lc code=end

