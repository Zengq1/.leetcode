using System.Security.AccessControl;
/*
 * @lc app=leetcode id=208 lang=csharp
 *
 * [208] Implement Trie (Prefix Tree)
 */

// @lc code=start
public class Trie
{
    int count;
    TrieNode root;

    /** Initialize your data structure here. */
    public Trie() 
    {
        root = new TrieNode();
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) 
    {
        TrieNode temp = root;

        foreach (char c in word)
        {
            int i = c - 'a';
            if (temp.children[i] == null)
            {
                temp.children[i] = new TrieNode();
            }
            temp = temp.children[i];
        }
        temp.isEndWord = true;
        count++;
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) 
    {
        TrieNode temp = root;
        foreach(char c in word)
        {
            int i = c - 'a';
            if (temp.children[i] == null) return false;
            temp = temp.children[i];
        }
        return temp.isEndWord;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) 
    {
        TrieNode temp = root;
        foreach(char c in prefix)
        {
            int i = c - 'a';
            if (temp.children[i] == null) return false;
            temp = temp.children[i];
        }
        return true;
    }
}

public class TrieNode
{
    public bool isEndWord;
    public TrieNode[] children;

    public TrieNode()
    {
        isEndWord = false;
        children = new TrieNode[26];
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
// @lc code=end

