using System.ComponentModel;
using System.Reflection.Metadata;
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
         //need a dictionary? to keep track of the current box, using both x value and heigh value
        //store all x and height value, if the point is the right point, store height as negative
        //use sorted set to store int[2] [0] will be the height, and [1] is the number it shows,while reach -x
        //the height -1, if the number of height reach 0 then remove it
        //first need to store all x height into an array of array
        IList<IList<int>> res = new List<IList<int>>();
        if (buildings.Length == 0 || buildings[0].Length == 0) return res;
        List<int[]> lines = new List<int[]>();
        foreach (int[] dimension in buildings)
        {
            lines.Add(new int[]{dimension[0],dimension[2]});
            lines.Add(new int[]{dimension[1],(-1) * dimension[2]});
        }

        //sort the list by [0] if the value are the same compare the height which is [1]
        //sorted by [0] ascending, and height [1] descending
        lines.Sort(delegate (int[] x, int[] y)
        {
            if (x[0] < y[0]) return -1;
            else if (x[0] == y[0])
            {
                if (Math.Abs(x[1]) > Math.Abs(y[1])) return -1;
                if (Math.Abs(x[1]) == Math.Abs(y[1]) && x[1] != y[1]) //then they are the same but one is negative and one is positive put negative first
                {
                    if (x[1] < 0) return -1;
                    else return 1;
                }
                else return 1;
            }
            else return 1;
        });

        //start to loop each line using sorteddictionary to store the current height. 
        Dictionary<int,int> dic = new Dictionary<int, int>();
        
        //set pre x to recorde the previous x to prevent the edge case where the end point x the same and height keep decreasing
        //it's also use to prevent when two building are right next to each other
        int preX = 0;
        int preH = 0;

        //loop through the lines to add the result
        for (int i = 0; i < lines.Count; i++)
        {
            int[] curLine = lines[i];   
            //when height is positive means thats the start line so record it into the dictionary
            if (curLine[1] > 0)
            {
                //check if the pre x is the same as cur x which means the current building is right next to the previous one
                //if not, add the previous point
                if (i != 0 && dic.Count == 0 && curLine[0] != preX) 
                {
                    res.Add(new List<int>{preX,0}); 
                    //reset pre height
                    preH = 0;
                }
                //in case dictionary is empty
                if (dic.Count == 0 && ((curLine[0] ==preX && curLine[1] != preH)|| curLine[0] != preX))
                {
                    res.Add(curLine.ToList());
                }
                else if (dic.Count != 0 && curLine[1] > dic.Keys.Max()) 
                {
                    res.Add(curLine.ToList());
                }

                //add height to the sorted dictionary
                if (!dic.ContainsKey(curLine[1]))
                {
                    dic[curLine[1]] = 1;
                }
                else dic[curLine[1]] ++; //if the current height existed, Add one to it means there are two building with the same height now
            }
            else
            {
                int curHeight = Math.Abs(curLine[1]);
                //deduct the height from dictionary if the num of current height is 0, remove it
                dic[curHeight]--;
                if (dic[curHeight] == 0) dic.Remove(curHeight);

                //if the removed height is the max before, then need to record it into result

                if (i != lines.Count - 1 && curLine[0] != lines[i + 1][0] //<---make sure not in the different end point height are not on the same x
                && dic.Count != 0 && preX != curLine[0] && curHeight > dic.Keys.Max())  res.Add(new List<int>{curLine[0],dic.Keys.Max()});
                if (i == lines.Count - 1) res.Add(new List<int>{curLine[0],0});
            }
            
            //only record preh when x changes
            if (curLine[0] != preX) preH = Math.Abs(curLine[1]);
            preX = curLine[0];
        }

        return res;
    }
}
// @lc code=end

