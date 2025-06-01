using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.FirstAttempts
{
    public class IsPalindromeSolution
    {
        // this was my first attempt.   Time Complexity: O(n), Space Complexity: O(1)

        public bool IsPalindrome(string s)
        {
            HashSet<char> validChars = new HashSet<char> ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789");
            int l = 0;
            int r = s.Length  - 1;
            while(l < r)
            {
                while (!validChars.Contains(s[l]) && l < r) l++;
                while (!validChars.Contains(s[r]) && r > l) r--;
                if (l > r) break;

                if (char.ToUpperInvariant(s[l]) != char.ToUpperInvariant(s[r])) return false;

                l++;
                r--;
            }
            
            return true;
        }
    }
}
