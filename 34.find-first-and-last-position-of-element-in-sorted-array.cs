using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
/*
 * @lc app=leetcode id=34 lang=csharp
 *
 * [34] Find First and Last Position of Element in Sorted Array
 */

// @lc code=start
public class Solution 
{
    public int[] SearchRange(int[] nums, int target) 
    {
        if (nums.Length < 1) return new int[2]{-1,-1};
        int l = 0; int h = nums.Length - 1;
        int[] res = new int[]{-1,-1};
        int secondP = nums.Length - 1;
        int mid = 0;
        //find left edge
        while (l <= h)
        {
            mid = l + (h - l)/2;
            if (nums[mid] > target) 
            {
                h = mid - 1;
                secondP = h;
            }
            else if (nums[mid] < target)
            {
                l = mid + 1;
            }
            else
            {
                if (mid == 0) 
                {
                    res[0] = mid;
                    l = mid;
                    break;
                }
                else
                {
                    if (nums[mid - 1] != target) 
                    {
                        res[0] = mid;
                        l = mid;
                        break;
                    }
                    else
                    {
                        h = mid - 1;
                    }
                }
            }
        }

        //find right point
        while (l <= secondP)
        {
            mid = l + (secondP - l)/2;
            if (nums[mid] > target) secondP = mid - 1;
            else 
            {
                if (mid == nums.Length - 1)
                {
                    res[1] = mid;
                    break;
                }
                else
                {
                    if (nums[mid + 1] != target)
                    {
                        res[1] = mid;
                        break;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }
            }
        }

        return res;
    }
}
// @lc code=end

