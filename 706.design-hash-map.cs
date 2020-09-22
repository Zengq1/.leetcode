using System.ComponentModel.DataAnnotations;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=706 lang=csharp
 *
 * [706] Design HashMap
 */

// @lc code=start
public class MyHashMap 
{
    Dictionary<int,int> dic;

    /** Initialize your data structure here. */
    public MyHashMap() 
    {
        dic = new Dictionary<int,int>();
    }
    
    /** value will always be non-negative. */
    public void Put(int key, int value) 
    {
        dic[key] = value;
    }
    
    /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
    public int Get(int key) 
    {
        if (!dic.ContainsKey(key)) return -1;
        else return dic[key];
    }
    
    /** Removes the mapping of the specified value key if this map contains a mapping for the key */
    public void Remove(int key) 
    {
        if (dic.ContainsKey(key)) dic.Remove(key);
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */
// @lc code=end

