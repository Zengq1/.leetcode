using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=218 lang=csharp
 *
 * [218] The Skyline Problem
 */

// @lc code=start
public class Solution 
{
    public IList<IList<int>> GetSkyline(int[][] buildings) 
    {
        IList<IList<int>> res = new List<IList<int>>();
        IList<IList<int>> lines = new List<IList<int>>();
        bool insertLeft = true;

        for (int buildIndex = 0; buildIndex < buildings.Length; buildIndex++)
        {
            IList<int> left = new List <int>{buildings[buildIndex][0],buildings[buildIndex][2]};
            IList<int> right = new List<int>{buildings[buildIndex][1],(-1) *  buildings[buildIndex][2]};
            
            if (lines.Count == 0)
            {
                lines.Add(left);
                lines.Add(right);
            }
            else
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    if (insertLeft)
                    {
                        if (lines[i][0] == left[0] && Math.Abs(lines[i][1]) < Math.Abs(left[1])) lines.Insert(i,left);
                        if (lines[i][0] > left[0]) 
                        {
                            lines.Insert(i,left);
                            insertLeft = false;
                        }
                    }
                    else
                    {
                        if (lines[i][0] == right[0] && Math.Abs(lines[i][1]) < Math.Abs(right[1])) lines.Insert(i,right);
                        if (lines[i][0] > right[0]) 
                        {
                            lines.Insert(i,right);
                            insertLeft = true;
                            break;
                        }   
                    }
                }
            }
        }

        MaxQueue curMaxHeight = new MaxQueue();
        int preX = 0;

        //[1,-3],[1,-2],[2,-5],[3,2],[5,3],[6,5]
        foreach (IList<int> line in lines)
        {
            int newH = line[1];
            int curX = line[0];

            if (!curMaxHeight.Any())
            {
                res.Add(line);
                curMaxHeight.Enqueue(newH);
                preX = curX;
            }    
            else
            {
                if (preX == (-1) * curX)
                {

                }
            }

        }
        return res;
    }
}
// @lc code=end

