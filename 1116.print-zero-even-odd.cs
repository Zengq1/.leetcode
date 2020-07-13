using System.Text;
using System;

/*
 * @lc app=leetcode id=1116 lang=csharp
 *
 * [1116] Print Zero Even Odd
 */

// @lc code=start

using System.Threading;

public class ZeroEvenOdd 
{
    private int n;
    private AutoResetEvent printZero =new AutoResetEvent(true);
    private AutoResetEvent printOdd = new AutoResetEvent(false);
    private AutoResetEvent printEven = new AutoResetEvent(false);

    public ZeroEvenOdd(int n) 
    {
        this.n = n;
    }

    // printNumber(x) outputs "x", where x is an integer.
    public void Zero(Action<int> printNumber) 
    {
        int counter = 0;

        while (counter <= n/2)
        {
            printZero.WaitOne();
            printNumber(0);
            printOdd.Set();
            printZero.WaitOne();
            printNumber(0);
            printEven.Set();
            printZero.WaitOne();
            counter++;
        }
    }

    public void Even(Action<int> printNumber) 
    {
        int counter = 1;
        while (counter * 2 <= n)
        {
            printEven.WaitOne();
            printNumber(counter * 2);
            printZero.Set();
            counter++;
        }
    }

    public void Odd(Action<int> printNumber) 
    {
        int counter = 0;
        while (counter * 2 + 1 <= n)
        {
            printOdd.WaitOne();
            printNumber(counter * 2 + 1);
            printZero.Set();
            counter++;
        }
    }
}
// @lc code=end

