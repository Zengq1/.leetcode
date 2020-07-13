using System.Runtime.Serialization;
using System.Resources;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Net.Http;
using Microsoft.Win32;
using System.Collections.Specialized;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Diagnostics.Contracts;
using System.Reflection.Emit;
using System.Transactions;
using System.Collections;
using System.Runtime.Versioning;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;
using System.Dynamic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design.Serialization;
using System.Data.Common;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using System;
using System.Security.Principal;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Linq;
using System.Collections.Generic;
/*
 * @lc app=leetcode id=212 lang=csharp
 *
 * [212] Word Search II
 */

// @lc code=start
public class Solution 
{
    public int colNum;
    public int rowNum;

    public IList<string> FindWords(char[][] board, string[] words) 
    {
        IList<string> res = new List<string>();
        colNum = board[0].Length;
        rowNum = board.Length;

        //edge case
        if (words == null || words.Length == 0 || rowNum == 0 || colNum == 0) return res;

        TrieNode root = new TrieNode();

        //create the trie node for each word in words
        foreach (string word in words)
        {
            BuildTrie(root, word);
        }

        //loop row and col index of the board
        for (int rowIndex = 0; rowIndex < rowNum; rowIndex++)
        {
            for (int colIndex = 0; colIndex < colNum; colIndex++)
            {
                GetString(board, res, rowIndex, colIndex,root);
            }
        }

        return res;
    }

    public void GetString(char[][] board,IList<string> res, int rowIndex, int colIndex, TrieNode root)
    {
        int aI = board[rowIndex][colIndex] - 'a';

        if (root.children[aI] == null || board[rowIndex][colIndex] == '$') return;
        root = root.children[aI];
        if (root.isEnd) 
        {
            root.isEnd = false;
            res.Add(root.curWord);
        }

        char c = board[rowIndex][colIndex];
        board[rowIndex][colIndex] = '$';
        if (rowIndex - 1 >= 0) GetString(board, res, rowIndex - 1, colIndex, root);
        if (rowIndex + 1 < rowNum) GetString(board, res, rowIndex + 1, colIndex, root);
        if (colIndex - 1 >= 0) GetString(board, res, rowIndex, colIndex - 1, root);
        if (colIndex + 1 < colNum) GetString(board, res, rowIndex, colIndex + 1, root);
        board[rowIndex][colIndex] = c;
    }

    public void BuildTrie (TrieNode root, string s)
    {
        TrieNode cur = root;
        for (int i = 0; i < s.Length; i++)
        {
            int aI = s[i] - 'a';
            if (cur.children[aI] == null)
            {
                cur.children[aI] = new TrieNode();
                cur.children[aI].curWord = s.Substring(0,i + 1);
            }
            cur = cur.children[aI];
        }
        cur.isEnd = true;
    }
}

public class TrieNode
{
    public bool isEnd;
    public string curWord;
    public TrieNode[] children;

    public TrieNode()
    {
        isEnd = false;
        children = new TrieNode[26];
    }
}


// @lc code=end

