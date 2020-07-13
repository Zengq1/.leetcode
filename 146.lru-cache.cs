using System.Resources;
using System.Text;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Linq;
using System.Numerics;
using System.Security.AccessControl;
using System;
using System.Collections;
using System.Reflection.Metadata;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=146 lang=csharp
 *
 * [146] LRU Cache
 */

// @lc code=start
public class LRUCache 
{
      Dictionary<int,int> cacheDic;
    LinkedList<int> rank;
    int cap;

    public LRUCache(int capacity)
    {
        cacheDic = new Dictionary<int,int>();
        rank = new LinkedList<int>();
        cap = capacity;
    }
    
    public int Get(int key) 
    {
        if (!cacheDic.ContainsKey(key)) return -1;
        rank.Remove(key);
        rank.AddLast(key);
        return cacheDic[key];
    }
    
    public void Put(int key, int value) 
    {
        if (cacheDic.ContainsKey(key))
        {
            rank.Remove(key);
            rank.AddLast(key);
            cacheDic[key] = value;
            return;
        }
        if (cacheDic.Count == cap)
        {
            cacheDic.Remove(rank.First.Value);
            rank.RemoveFirst();
        }
        cacheDic.Add(key,value);
        rank.AddLast(key);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
// @lc code=end

