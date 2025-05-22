using LeetCodeProblems.Shared;
using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;

namespace LeetCodeProblems.FirstAttempts
{

    public class FindMedianSortedArraysUnoptimized : IFindMedianSortedArrays
    {
        // leetcode stats: 15.4% in runtime, 6.02% in memory

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var combined = nums1.Concat(nums2).OrderBy(x => x).ToList();
            double returnable = 0;
            if (combined.Count % 2 == 0) 
            { 
                var upperIndex = combined.Count / 2;
                var lowerIndex = upperIndex - 1;

                var upperValue = combined[upperIndex];
                var lowerValue = combined[lowerIndex];

                returnable = (double)(upperValue + (double)lowerValue) / 2;
                
            }
            else
                returnable = combined[combined.Count / 2];
            return returnable;
        }
    }
}