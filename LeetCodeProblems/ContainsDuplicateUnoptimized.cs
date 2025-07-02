using LeetCodeProblems.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems
{

    internal class ContainsDuplicateUnoptimized 
    {
        // I generated this one on the first attempt.  Time: O(n) Space: O(n)
        public bool hasDuplicateBruteForce(int[] nums)
        {
            HashSet<int> founds = new HashSet<int>();

            foreach (int value in nums)
            {
                if (founds.Contains(value)) return true;
                founds.Add(value);
            }
            return false;
        }

        // this one I looked up;   Faster because it sorts the array first.
        // Time: O(n log n) Space: O(1)

        public bool hasDuplicate(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1]) return true;
            }
            return false;
        }

    }
}
