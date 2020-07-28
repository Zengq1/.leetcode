using System;
using System.Linq;
/*
 * @lc app=leetcode id=179 lang=csharp
 *
 * [179] Largest Number
 */

// @lc code=start
public class Solution 
{
    public string LargestNumber(int[] nums) 
    {
        //sort the list by the first number of the list, if first number are the same, compare the second number
        //first loop through the nums
        for (int i = 0; i < nums.Length - 1; i++)
        {
            //start another loop to find the biggest and switch the position
            for (int j = i + 1; j < nums.Length; j++)
            {
                //num [i] <= num [j]
                if (!IsBiggerThan(nums[i],nums[j]))
                {
                    int temp = nums[j];
                    nums[j] = nums[i];
                    nums[i] = temp;
                }
            }
        }

        return string.Join("",nums);
    }

    //record the seen pair
    private Dictionary<int[],bool> seen = new Dictionary<int[], bool>();

    //method to indicate if n1 is larger than n2
    private bool IsBiggerThan (int n1, int n2)
    {
        int numOfDigit1 = 0;
        int temp1 = n1;
        while (temp1 > 0)
        {
            temp1 /= 10;
            numOfDigit1++;
        }

        int numOfDigit2 = 0;
        int temp2 = n2;
        while (temp2 > 0)
        {
            temp2 /= 10;
            numOfDigit2++;
        }

        //n1 at beginning
        double sum1 = n1 * Math.Pow(10,numOfDigit2) + n2;
        //n2 at beginning 
        double sum2 = n2 * Math.Pow(10,numOfDigit1) + n1;

        return sum1 > sum2;

        /* stupid way to compare
        int[] curArray;
        if (n1 < n2) curArray = new int[]{n1,n2};
        else curArray = new int[]{n2,n1};

        if (seen.ContainsKey(curArray)) return seen[curArray];
        
        //if the two number are the same return false;
        if (n1 == n2) 
        {
            seen[curArray] = false;
            return false;
        }

        List<int> l1 = new List<int>();
        List<int> l2 = new List<int>();
        //seperate n1 and n2 to single digit and store them into list.
        while (n1 > 0)
        {
            l1.Add(n1%10);
            n1 /= 10;
        }

        while (n2 > 0)
        {
            l2.Add(n2%10);
            n2/=10;
        }

        //8683 > 86       864 < 86
        //868386 > 868683   86486 < 86864
        //compare the two list from the back 
        int i1 = l1.Count - 1, i2 = l2.Count - 1;
        while (i1 >= 0 && i2 >= 0)
        {
            if (l1[i1] > l2[i2]) 
            {
                seen[curArray] = true;
                return true;
            }
            else if (l1[i1] < l2[i2])
            {
                seen[curArray] = false;
                return false;
            }
            else if (l1[i1] == l2[i2])
            {
                if (i1 == 0 && i2 == 0) break;
                if (i1 != 0 && i2 != 0) 
                {
                    i1 --;
                    i2 --;
                }
                else if (i1 == 0)
                {
                    i2 --;
                    if (l2[i2] > l1[l1.Count - 1])
                    {
                        seen[curArray] = false;
                        return false;
                    }
                    else if (l2[i2] < l1[l1.Count - 1])
                    {
                        seen[curArray] = true;
                        return true;
                    }
                    else 
                    {
                        i2 --;
                        i1 = l1.Count - 2;
                    }
                }
                else if (i2 == 0)
                {
                    i1 --;
                    if (l1[i1] > l2[l2.Count - 1])
                    {
                        seen[curArray] = true;
                        return true;
                    }
                    else if (l1[i1] < l2[l2.Count - 1])
                    {
                        seen[curArray] = false;
                        return false;
                    }
                    else
                    {
                        i1 --;
                        i2 = l2.Count - 2;
                    }
                }
            }
        }

        //the method will only reach here whehn the end of one list is the same as the other one's beginning
        //121 12   12(1) same as 12   12(1) is the same as (1)2
        seen[curArray] = false;
        return false;
        */
    }
}
// @lc code=end

