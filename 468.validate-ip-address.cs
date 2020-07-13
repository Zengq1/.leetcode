using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Text;
/*
 * @lc app=leetcode id=468 lang=csharp
 *
 * [468] Validate IP Address
 */

// @lc code=start
public class Solution 
{
    public string ValidIPAddress(string IP) 
    {
        const string IPV4 = "IPv4";
        const string IPV6 = "IPv6";
        const string NEITHER = "Neither";
        bool probv4 =  true;
        
        //tried to see if it's v4 or v6
        if (IP.Contains(':')) probv4 = false;

        if (probv4)
        {
            string[] splitedIP = IP.Split('.');
            if (splitedIP.Length != 4) return NEITHER;
            foreach (string s in splitedIP)
            {
                if (s.Length < 1||s.Length > 3) return NEITHER;
                foreach(char c in s)
                {
                    if (c < '0' || c> '9') return NEITHER;
                }
                if (int.Parse(s) > 255 || (s.Length == 2 && s[0] == '0') || (s.Length == 3 && s[0] == '0')) return NEITHER;
            }
        }
        else
        {
            string[] splitedIP = IP.Split(':');
            if (splitedIP.Length!= 8) return NEITHER;
            foreach (string s in splitedIP)
            {
                if (s.Length > 4 || s.Length < 1) return NEITHER;
                foreach(char c in s)
                {
                    if ((c >= 'A' && c <= 'F') ||(c >= 'a' && c <= 'f') || (c >= '0' && c <= '9')) continue;
                    else return NEITHER;
                }

            }
        }

        return probv4?IPV4:IPV6;
    }
}
// @lc code=end

