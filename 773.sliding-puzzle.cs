using System.ComponentModel.Design;
using System.Collections;
using System.Text;
using System.Security;
using System.Linq;
using System.Numerics;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Data.SqlTypes;
using System.Transactions;
using System.Net.Http.Headers;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Reflection.Metadata;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Data;
using Internal;
using System.Reflection;
using System.Text.RegularExpressions;
using System;
using System.Security.Authentication.ExtendedProtection;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=773 lang=csharp
 *
 * [773] Sliding Puzzle
 */

// @lc code=start
public class Solution
{
    public int SlidingPuzzle(int[][] board) 
    {
        StringBuilder sb = new StringBuilder();
        Queue<string> q = new Queue<string>();
        HashSet<string> seen = new HashSet<string>();
        string goal = "123450";
        
        for (int r = 0; r < 2; r++)
        {
            for (int c = 0; c < 3;c++) sb.Append(board[r][c]);
        }

        if (goal == sb.ToString()) return 0;
        int depth = 1;
        int qNum = 1; 
        int[][] moveAble = new int[][]{new int[]{1,3}, new int[]{0,2,4},new int[]{1,5},new int[]{0,4},new int[]{1,3,5},new int[]{2,4}};
        q.Enqueue(sb.ToString());
        seen.Add(sb.ToString());

        while (q.Any())
        {
            string curString = q.Dequeue();
            qNum--;

            //find 0
            for (int i = 0; i < 6; i++)
            {
                if (curString[i] == '0')
                {
                    foreach (int targetIndex in moveAble[i])
                    {
                        string newString = Swap(curString,i,targetIndex);
                        if (!seen.Contains(newString))
                        {
                            seen.Add(newString);
                            q.Enqueue(newString);
                            if (newString == goal) return depth;
                        }
                    }
                    break;
                }
            }

            if (qNum == 0)
            {
                depth++;
                qNum = q.Count;
            }
        }

        return -1;
    }

    private string Swap (string s, int curIndex, int targetIndex)
    {
        StringBuilder sb = new StringBuilder(s);
        char temp = s[targetIndex];
        sb[curIndex] = temp;
        sb[targetIndex] = '0';
        return sb.ToString();
    }
}

// @lc code=end

