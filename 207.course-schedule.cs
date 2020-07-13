using System.Xml.Linq;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=207 lang=csharp
 *
 * [207] Course Schedule
 */

// @lc code=start
public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) 
    {
        if (prerequisites.Length == 0||numCourses ==  1) return true;
        //indicate how many prerequisites the class require
        int[] prereqNum = new int[numCourses];
        //key is the prerequisites class number, the list is the class requre the prerequisits class
        Dictionary<int,List<int>> prereqDic = new Dictionary<int, List<int>>();
        for (int i = 0; i < prereqNum.Length; i++) 
        {
            prereqDic[i] = new List<int>();
            prereqNum[i] = 0;
        }

        foreach (int[] prereq in prerequisites)
        {
            prereqDic[prereq[1]].Add(prereq[0]);
            prereqNum[prereq[0]]++;
        }

        //record the classes that has no prerequisites or already finished prerequisites
        Queue<int> q = new Queue<int>();
        for (int i = 0; i < prereqNum.Length; i++) 
        {
            if (prereqNum[i] == 0) q.Enqueue(i);
        }

        //loop through the dictionary to see if all the prereq can be subtract to 0
        while (q.Any())
        {
            int finishedCourseID = q.Dequeue();
            foreach (int courseID in prereqDic[finishedCourseID]) 
            {
                prereqNum[courseID] --;
                if (prereqNum[courseID] == 0) q.Enqueue(courseID);
            }
        }

        //check for if there any course still require prerequistites
        foreach (int num in prereqNum) 
        {
            if (num > 0) return false;
        }

        return true;
    }
}

// 0,1  1,2  2,3  3,4  4,0
// 0,1  2,1  3,1  
// @lc code=end

