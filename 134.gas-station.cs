using System.Reflection.Emit;
/*
 * @lc app=leetcode id=134 lang=csharp
 *
 * [134] Gas Station
 */

// @lc code=start
public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost) 
    {
        for (int i = 0; i < gas.Length; i ++)
        {
            int startIndex = i == 0? gas.Length - 1: i - 1;
            if (DFS(i,0,startIndex,gas,cost)) return startIndex;
        }
        return -1;
    }

    private bool DFS (int nextStationIndex, int curGas, int startIndex, int[] gas, int[] cost)
    {
        if (nextStationIndex == gas.Length) nextStationIndex = 0;
        int curGasIndex = nextStationIndex == 0? cost.Length - 1:nextStationIndex - 1;
        curGas = curGas + gas[curGasIndex] - cost[curGasIndex];
        if (curGas < 0) return false;
        if (nextStationIndex == startIndex) return true;
        return DFS(nextStationIndex + 1,curGas,startIndex,gas,cost);
    }
}
// @lc code=end

