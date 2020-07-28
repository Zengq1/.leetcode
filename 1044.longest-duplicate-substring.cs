using System.Runtime.Versioning;
using System.Reflection.Metadata;
using System.Threading;
using System.Xml.Xsl.Runtime;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Dynamic;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel;
using System;
using System.Security.Principal;
using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
/*
 * @lc app=leetcode id=1044 lang=csharp
 *
 * [1044] Longest Duplicate Substring
 */

// @lc code=start
public class Solution 
{
    public string LongestDupSubstring(string S) 
    {
        int low = 2;
        int high = S.Length;
        int med = 0;
        
		// last successful serch results
        int lastLen = -1;
        int lastIdx = -1;
        
        while (low <= high)
        {
            med = low + (high - low) / 2;
            
			// serch current length duplicates ~O(N)
            var res = SearchString(S, med);
            
            if(res != -1)
            {
                lastLen = med;
                lastIdx = res;
                
                low = med + 1;
            }
            else
            {
                high = med - 1;
            }
        }
        
        return lastIdx != -1 ? S.Substring(lastIdx, lastLen) : "";
    }
    
    
    private static int SearchString(string A, int len)
    {
        ulong hash = 0;
        ulong prime = 100007;
		
		// we are going to have only lowercase eng letters (alphabet сardinality)
        ulong ac = 26;
        
		// dictionary to store pairs <hash , idx>
		// You may notice that I don't care abut collisions. You're right. For this task it could be avoided because of lack of test cases.
		// In a good way it should be Dictionary<ulong, List<int>>
        var dic = new Dictionary<ulong, int>();

        for (int i = 0; i < len; ++i)
        {
            hash = (hash * ac + (ulong)A[i]) % prime;
        }
        
        dic[hash] = 0;
        
        ulong pow = 1;

        for (int k = 1; k <= len - 1; ++k)
        {
            pow = (pow * ac) % prime;
        }
        
		
        for (int j = 1; j <= A.Length - len; ++j)
        {
            hash = (hash + prime - pow * (ulong)A[j - 1] % prime) % prime;
            hash = (hash * ac + (ulong)A[j + len - 1]) % prime;

			// if current hash is in the dictionary then we probably found one we need
            if (dic.TryGetValue(hash, out var idx))
            {
                if (CompareFromIdx(A, idx, len, j))
                {
                    return idx;
                }
            }
            else
            {
                dic.Add(hash, j);
            }
        }

        return -1;
    }
    
    private static bool CompareFromIdx(string s, int dicIdx, int len, int curIdx)
    {           
        for(int i = 0; i < len; i++)
        {
            if (s[curIdx+i] != s[dicIdx+i])
            {
                return false;
            }
        }

        return true; 
    }
}

/* exceed memory limit
public class Trie
{
    private TrieNode root;
    public Trie()
    {
        root = new TrieNode("");
    }

    public void AddString(string s)
    {
        TrieNode temp = root;
    
        for (int i = 0; i < s.Length; i++)
        {
            if (temp.children[s[i] - 'a'] == null) temp.children[s[i] - 'a'] =  new TrieNode(s.Substring(0,i+1)); 
            temp = temp.children[s[i] - 'a'];
        }
        temp.isEnd = true;
    }

    public bool Contains(string s)
    {
        TrieNode temp = root;
        foreach (char c in s)
        {
            if (temp.children[c - 'a'] == null) return false;
            temp = temp.children[c - 'a'];
        }
        return temp.isEnd?true:false;
    }
}

public class TrieNode
{
    public string val;
    public TrieNode[] children;
    public bool isEnd;
    public TrieNode(string val)
    {
        this.val = val;
        children = new TrieNode[26];
        isEnd = false;
    }
}
*/
// @lc code=end

