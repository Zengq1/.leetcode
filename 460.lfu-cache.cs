using System.Security.AccessControl;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Xsl.Runtime;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=460 lang=csharp
 *
 * [460] LFU Cache
 */

// @lc code=start
public class LFUCache 
{
    int cap;
    //key is key, in int array index 0 is value, index 1 is the number of it's call frequence
    Dictionary<int,int[]> dic;

    //key is key, value is linkedlistnode key
    Dictionary<int,LinkedListNode<int>> nodeDic;

    //key is the frequence of the linkedlist 
    Dictionary<int, LinkedList<int>> numDic;

    //record lowest freq
    int lowestFre;

    public LFUCache(int capacity) 
    {
        cap = capacity;
        dic = new Dictionary<int, int[]>();
        nodeDic = new Dictionary<int,LinkedListNode<int>>();
        numDic = new Dictionary<int,LinkedList<int>>();
        lowestFre = 0;
    }
    
    public int Get(int key) 
    {
        if (!dic.ContainsKey(key)) return -1;
        int curFre = dic[key][1];
        dic[key][1]++;
        numDic[curFre].Remove(nodeDic[key]);
        if (numDic[curFre].First == null)
        {
            if (curFre == lowestFre) lowestFre++;
            numDic.Remove(curFre);
        }
        if (!numDic.ContainsKey(curFre + 1)) numDic[curFre + 1] = new LinkedList<int>();
        numDic[curFre + 1].AddLast(nodeDic[key]);

        return dic[key][0];
    }
    
    public void Put(int key, int value) 
    {
        if (cap == 0) return;
        if (!dic.ContainsKey(key))
        {
            //remove least freq element from all the dictionary
            if (dic.Count == cap)
            {
                int removingKey = numDic[lowestFre].First.Value;
                numDic[lowestFre].RemoveFirst();
                if (numDic[lowestFre].First == null ) numDic.Remove(lowestFre);
                dic.Remove(removingKey);
                nodeDic.Remove(removingKey);
            }

            dic.Add(key,new int[]{value,1});
            if (!numDic.ContainsKey(1)) numDic[1] = new LinkedList<int>();
            nodeDic.Add(key,new LinkedListNode<int>(key));
            numDic[1].AddLast(nodeDic[key]);
            lowestFre = 1;
        }
        else
        {
            dic[key][0] = value;
            Get(key);
        }
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
// @lc code=end

