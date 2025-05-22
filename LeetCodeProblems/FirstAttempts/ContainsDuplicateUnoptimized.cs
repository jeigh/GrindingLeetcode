using LeetCodeProblems.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.FirstAttempts
{

    internal class ContainsDuplicateUnoptimized : IContainsDuplicate
    {
        // I generated this one on the first attempt.  Time: O(n) Space: O(n)
        public bool hasDuplicate(int[] nums)
        {
            HashSet<int> founds = new HashSet<int>();

            foreach (int value in nums)
            {
                if (founds.Contains(value)) return true;
                founds.Add(value);
            }
            return false;
        }

    }
}
