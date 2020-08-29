using System.Runtime.InteropServices;
using System.Data;
using System.Resources;
using System;
using System.Diagnostics;
using System.Xml.Schema;
using System.ComponentModel;
using System.Net.Security;
using System.Runtime.CompilerServices;
/*
 * @lc app=leetcode id=295 lang=csharp
 *
 * [295] Find Median from Data Stream
 */

// @lc code=start
public class MedianFinder 
{
    int count;
    SortedSet<int[]> lowSet;
    SortedSet<int[]> highSet;

    /** initialize your data structure here. */
    public MedianFinder() 
    {
        count = 1;
        //in case if there are duplicate number [0] is the number [1] is when it was added
        lowSet = new SortedSet<int[]>(Comparer<int[]>.Create((a,b) => a[0] == b[0]? a[1] - b[1] : a[0] - b[0]));
        highSet = new SortedSet<int[]>(Comparer<int[]>.Create((a,b) => a[0] == b[0]? a[1] - b[1] : a[0] - b[0]));
    }
    
    public void AddNum(int num) 
    {
        count++;
        int[] curNum = new int[]{num,count};
        if (count == 0) 
        {
            lowSet.Add(curNum);
        }
        else
        {
            if (lowSet.Count > highSet.Count)
            {
                if (num < lowSet.Max[0]) 
                {
                    highSet.Add(lowSet.Max);
                    lowSet.Remove(lowSet.Max);
                    lowSet.Add(curNum);
                }
                else highSet.Add(curNum);
            }
            else //when the two set has same amount of elements
            {
                //if count is even (lowset count == high set count) lowset can have one more element than high set
                if (num <= highSet.Min[0])
                {
                    lowSet.Add(curNum);
                }
                else
                {
                    lowSet.Add(highSet.Min);
                    highSet.Remove(highSet.Min);
                    highSet.Add(curNum);
                }
            }
        }


    }
    
    public double FindMedian() 
    {
        return count%2 == 0? (double)lowSet.Max[0]/2d + (double)highSet.Min[0]/2d:(double)lowSet.Max[0];
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */
// @lc code=end

