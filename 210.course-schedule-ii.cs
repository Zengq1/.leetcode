using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
/*
 * @lc app=leetcode id=210 lang=csharp
 *
 * [210] Course Schedule II
 */

// @lc code=start
public class Solution 
{
    public int[] FindOrder(int numCourses, int[][] prerequisites) 
    {
        int[] res = new int[numCourses];
        int curI = 0;
        HashSet<int> needReq = new HashSet<int>();
        Dictionary<int,HashSet<int>> courses = new Dictionary<int,HashSet<int>>();
        int[] numOfReq = new int[numCourses];
        Queue<int> canTake = new Queue<int>();

        //create a dictionary to hold all prerequistes course. Key is the course num for the value(classes that require the key class)
        for (int i = 0; i < prerequisites.Length; i++)
        {
            if (!courses.ContainsKey(prerequisites[i][1])) courses[prerequisites[i][1]] = new HashSet<int>();
            courses[prerequisites[i][1]].Add(prerequisites[i][0]);
            numOfReq[prerequisites[i][0]]++;
            if (!needReq.Contains(prerequisites[i][0])) needReq.Add(prerequisites[i][0]);
        }

        //check which class has no prerequisites
        for (int i = 0; i < numCourses; i++)
        {
            if (!needReq.Contains(i))canTake.Enqueue(i);
        }

        if (!canTake.Any()) return new int[0];

        while (canTake.Any())
        {
            int curCourse = canTake.Dequeue();
            if (courses.ContainsKey(curCourse))
            {
                foreach (int c in courses[curCourse])
                {
                    numOfReq[c]--;
                    if (numOfReq[c] == 0) canTake.Enqueue(c);
                }
                courses.Remove(curCourse);
            }
            res[curI] = curCourse;
            curI++;
        }

        return curI != numCourses? new int[0]:res;    
    }
}
// @lc code=end

