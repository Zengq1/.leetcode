using System;
using System.Dynamic;
/*
 * @lc app=leetcode id=380 lang=csharp
 *
 * [380] Insert Delete GetRandom O(1)
 */

// @lc code=start
public class RandomizedSet 
{
    HashSet<int> set;
    int count;
    Random random;

    /** Initialize your data structure here. */
    public RandomizedSet() 
    {
        set = new HashSet<int>();
        count = 0;
        random = new Random();
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) 
    {
        if (set.Add(val))
        {
            count++;
            return true;
        }
        return false;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) 
    {
        if (set.Remove(val))
        {
            count--;
            return true;
        }
        return false;
    }
    
    /** Get a random element from the set. */
    public int GetRandom() 
    {
        int rd = random.Next(count);
        return set.ElementAt(rd);
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
// @lc code=end

